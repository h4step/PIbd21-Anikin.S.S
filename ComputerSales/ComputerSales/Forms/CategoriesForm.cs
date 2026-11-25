using System;
using System.Linq;
using System.Windows.Forms;
using ComputerSales.Models;
using ComputerSales.Repositories;

namespace ComputerSales.Forms
{
    public partial class CategoriesForm : Form
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesForm(ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            _categoryRepository = categoryRepository;
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _categoryRepository.GetAll().ToList();
                dataGridViewCategories.DataSource = categories;

                if (dataGridViewCategories.Columns["Id"] != null)
                    dataGridViewCategories.Columns["Id"].HeaderText = "ID";
                if (dataGridViewCategories.Columns["Name"] != null)
                    dataGridViewCategories.Columns["Name"].HeaderText = "Название";
                if (dataGridViewCategories.Columns["Description"] != null)
                    dataGridViewCategories.Columns["Description"].HeaderText = "Описание";

                if (dataGridViewCategories.Columns["Products"] != null)
                    dataGridViewCategories.Columns["Products"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new CategoryEditForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newCategory = Category.CreateEntity(0, editForm.CategoryName, editForm.CategoryDescription);
                        _categoryRepository.Add(newCategory);
                        LoadCategories();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите категорию для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedCategory = (Category)dataGridViewCategories.SelectedRows[0].DataBoundItem;

            using (var editForm = new CategoryEditForm(selectedCategory.Name, selectedCategory.Description))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var updatedCategory = Category.CreateEntity(selectedCategory.Id, editForm.CategoryName, editForm.CategoryDescription);
                        _categoryRepository.Update(updatedCategory);
                        LoadCategories();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите категорию для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedCategory = (Category)dataGridViewCategories.SelectedRows[0].DataBoundItem;

            var confirmResult = MessageBox.Show(
                $"Вы действительно хотите удалить категорию «{selectedCategory.Name}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _categoryRepository.Delete(selectedCategory.Id);
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить категорию: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}