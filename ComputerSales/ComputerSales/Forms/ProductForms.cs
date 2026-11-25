using System;
using System.Linq;
using System.Windows.Forms;
using ComputerSales.Models;
using ComputerSales.Repositories;

namespace ComputerSales.Forms
{
    public partial class ProductForms : Form
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductForms(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            LoadProducts();
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void LoadProducts()
        {
            try
            {
                dataGridViewProducts.DataSource = _productRepository.GetAll().ToList();

                if (dataGridViewProducts.Columns["Id"] != null)
                    dataGridViewProducts.Columns["Id"].HeaderText = "ID";
                if (dataGridViewProducts.Columns["Name"] != null)
                    dataGridViewProducts.Columns["Name"].HeaderText = "Наименование";
                if (dataGridViewProducts.Columns["Price"] != null)
                    dataGridViewProducts.Columns["Price"].HeaderText = "Цена";
                if (dataGridViewProducts.Columns["CostPrice"] != null)
                    dataGridViewProducts.Columns["CostPrice"].HeaderText = "Себестоимость";
                if (dataGridViewProducts.Columns["CategoryId"] != null)
                    dataGridViewProducts.Columns["CategoryId"].HeaderText = "ID категории";
                if (dataGridViewProducts.Columns["Origin"] != null)
                    dataGridViewProducts.Columns["Origin"].HeaderText = "Происхождение";
                if (dataGridViewProducts.Columns["Features"] != null)
                    dataGridViewProducts.Columns["Features"].HeaderText = "Характеристики";

                if (dataGridViewProducts.Columns["Category"] != null)
                    dataGridViewProducts.Columns["Category"].Visible = false;
                if (dataGridViewProducts.Columns["SaleProducts"] != null)
                    dataGridViewProducts.Columns["SaleProducts"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var categories = _categoryRepository.GetAll().ToList();
            if (categories.Count == 0)
            {
                MessageBox.Show("Сначала добавьте хотя бы одну категорию.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var editForm = new ProductEditForm(categories);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newProduct = Product.CreateEntity(
                    0,
                    editForm.CategoryId,
                    editForm.ProductName,
                    editForm.Origin,
                    editForm.Features,
                    editForm.Price,
                    editForm.CostPrice);

                    _productRepository.Add(newProduct);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = (Product)dataGridViewProducts.SelectedRows[0].DataBoundItem;
            var categories = _categoryRepository.GetAll().ToList();

            using var editForm = new ProductEditForm(categories, selected);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var updatedProduct = Product.CreateEntity(
                    selected.Id,
                    editForm.CategoryId,
                    editForm.ProductName,
                    editForm.Origin,
                    editForm.Features,
                    editForm.Price,
                    editForm.CostPrice);

                    _productRepository.Update(updatedProduct);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = (Product)dataGridViewProducts.SelectedRows[0].DataBoundItem;
            var confirm = MessageBox.Show(
                $"Удалить товар «{selected.Name}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _productRepository.Delete(selected.Id);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить товар: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}