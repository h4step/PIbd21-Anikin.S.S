using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ComputerSales.Models;

namespace ComputerSales.Forms
{
    public partial class SaleEditForm : Form
    {
        public class SaleDraftItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Count { get; set; }
            public decimal PriceAtSale { get; set; }
            public decimal LineTotal => Count * PriceAtSale;
        }

        private readonly BindingList<SaleDraftItem> _items = new BindingList<SaleDraftItem>();

        public int SelectedClientId => (int)cmbClient.SelectedValue;
        public DateTime SaleDate => dtpSaleDate.Value;
        public decimal TotalAmount => _items.Sum(i => i.LineTotal);
        public IReadOnlyList<SaleDraftItem> SelectedItems => _items.ToList();

        public SaleEditForm(List<Client> clients, List<Product> products)
        {
            InitializeComponent();
            Text = "Новая продажа";

            cmbClient.DataSource = clients;
            cmbClient.DisplayMember = "FullName";
            cmbClient.ValueMember = "Id";

            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";

            numCount.Minimum = 1;
            numCount.Maximum = 100000;
            numCount.Value = 1;

            dataGridViewItems.DataSource = _items;
            ConfigureItemsGrid();
            UpdateTotalLabel();
        }

        private void ConfigureItemsGrid()
        {
            if (dataGridViewItems.Columns["ProductId"] != null)
                dataGridViewItems.Columns["ProductId"].Visible = false;
            if (dataGridViewItems.Columns["ProductName"] != null)
                dataGridViewItems.Columns["ProductName"].HeaderText = "Товар";
            if (dataGridViewItems.Columns["Count"] != null)
                dataGridViewItems.Columns["Count"].HeaderText = "Кол-во";
            if (dataGridViewItems.Columns["PriceAtSale"] != null)
                dataGridViewItems.Columns["PriceAtSale"].HeaderText = "Цена";
            if (dataGridViewItems.Columns["LineTotal"] != null)
                dataGridViewItems.Columns["LineTotal"].HeaderText = "Сумма";
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem is not Product selectedProduct)
                return;

            int count = (int)numCount.Value;
            if (count <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existing = _items.FirstOrDefault(i => i.ProductId == selectedProduct.Id);
            if (existing != null)
            {
                existing.Count += count;
                _items.ResetBindings();
            }
            else
            {
                _items.Add(new SaleDraftItem
                {
                    ProductId = selectedProduct.Id,
                    ProductName = selectedProduct.Name,
                    Count = count,
                    PriceAtSale = selectedProduct.Price
                });
            }

            UpdateTotalLabel();
        }

        private void UpdateTotalLabel()
        {
            lblTotalAmount.Text = $"Итого: {TotalAmount:N2}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_items.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один товар в продажу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}