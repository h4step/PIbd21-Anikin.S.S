using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ComputerSales.Models;
using ComputerSales.Repositories;

namespace ComputerSales.Forms
{
    public partial class SalesForm : Form
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        private List<SaleProduct> _allSaleProducts = new List<SaleProduct>();
        private Dictionary<int, string> _productNames = new Dictionary<int, string>();

        public SalesForm(
            ISaleRepository saleRepository,
            ISaleProductRepository saleProductRepository,
            IClientRepository clientRepository,
            IProductRepository productRepository)
        {
            InitializeComponent();
            _saleRepository = saleRepository;
            _saleProductRepository = saleProductRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;

            dataGridViewSales.SelectionChanged += dataGridViewSales_SelectionChanged;
            LoadSales();
        }

        private void LoadSales()
        {
            try
            {
                _productNames = _productRepository.GetAll().ToDictionary(p => p.Id, p => p.Name);
                _allSaleProducts = _saleProductRepository.GetAll().ToList();
                var sales = _saleRepository.GetAll().ToList();

                dataGridViewSales.DataSource = sales;

                if (dataGridViewSales.Columns["Id"] != null)
                    dataGridViewSales.Columns["Id"].HeaderText = "№ продажи";
                if (dataGridViewSales.Columns["ClientId"] != null)
                    dataGridViewSales.Columns["ClientId"].HeaderText = "ID клиента";
                if (dataGridViewSales.Columns["SaleDate"] != null)
                    dataGridViewSales.Columns["SaleDate"].HeaderText = "Дата продажи";
                if (dataGridViewSales.Columns["TotalAmount"] != null)
                    dataGridViewSales.Columns["TotalAmount"].HeaderText = "Сумма";

                LoadSaleItemsForSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продаж: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSales_SelectionChanged(object sender, EventArgs e)
        {
            LoadSaleItemsForSelected();
        }

        private void LoadSaleItemsForSelected()
        {
            if (dataGridViewSales.CurrentRow?.DataBoundItem is not Sale selectedSale)
            {
                dataGridViewSaleItems.DataSource = null;
                return;
            }

            var items = _allSaleProducts
                .Where(sp => sp.SaleId == selectedSale.Id)
                .Select(sp => new
                {
                    ProductId = sp.ProductId,
                    ProductName = _productNames.TryGetValue(sp.ProductId, out var name) ? name : $"Товар #{sp.ProductId}",
                    Count = sp.Count,
                    PriceAtSale = sp.PriceAtSale,
                    LineTotal = sp.Count * sp.PriceAtSale
                })
                .ToList();

            dataGridViewSaleItems.DataSource = items;

            if (dataGridViewSaleItems.Columns["ProductId"] != null)
                dataGridViewSaleItems.Columns["ProductId"].HeaderText = "ID товара";
            if (dataGridViewSaleItems.Columns["ProductName"] != null)
                dataGridViewSaleItems.Columns["ProductName"].HeaderText = "Товар";
            if (dataGridViewSaleItems.Columns["Count"] != null)
                dataGridViewSaleItems.Columns["Count"].HeaderText = "Кол-во";
            if (dataGridViewSaleItems.Columns["PriceAtSale"] != null)
                dataGridViewSaleItems.Columns["PriceAtSale"].HeaderText = "Цена";
            if (dataGridViewSaleItems.Columns["LineTotal"] != null)
                dataGridViewSaleItems.Columns["LineTotal"].HeaderText = "Итого";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var clients = _clientRepository.GetAll().ToList();
            var products = _productRepository.GetAll().ToList();

            if (clients.Count == 0)
            {
                MessageBox.Show("Сначала добавьте хотя бы одного клиента.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (products.Count == 0)
            {
                MessageBox.Show("Сначала добавьте хотя бы один товар.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var editForm = new SaleEditForm(clients, products);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sale = Sale.CreateEntity(
                        0,
                        editForm.SelectedClientId,
                        editForm.SaleDate,
                        editForm.TotalAmount);

                    _saleRepository.Add(sale);

                    // Если репозиторий после Add проставляет sale.Id, используем его; иначе берём максимальный Id из GetAll()
                    int saleId = sale.Id > 0
                        ? sale.Id
                        : _saleRepository.GetAll().OrderByDescending(s => s.Id).First().Id;

                    foreach (var item in editForm.SelectedItems)
                    {
                        var saleProduct = SaleProduct.CreateEntity(
                            0,
                            saleId,
                            item.ProductId,
                            item.Count,
                            item.PriceAtSale);

                        _saleProductRepository.Add(saleProduct);
                    }

                    LoadSales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения продажи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}