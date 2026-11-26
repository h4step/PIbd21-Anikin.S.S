using System;
using System.Windows.Forms;

namespace ComputerSales.Forms
{
    public partial class CategoryEditForm : Form
    {
        public string CategoryName => txtName.Text.Trim();
        public string CategoryDescription => txtDescription.Text.Trim();

        public CategoryEditForm()
        {
            InitializeComponent();
            Text = "Добавить категорию";
        }

        public CategoryEditForm(string name, string description) : this()
        {
            Text = "Редактировать категорию";
            txtName.Text = name;
            txtDescription.Text = description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Название категории не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}