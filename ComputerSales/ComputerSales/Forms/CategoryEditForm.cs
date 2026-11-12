using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ComputerSales.Forms
{
    public partial class CategoryEditForm : Form
    {
        // Публичные свойства, через которые CategoriesForm забирает введенные данные
        public string CategoryName => txtName.Text.Trim();
        public string CategoryDescription => txtDescription.Text.Trim();

        // Конструктор для режима добавления новой категории
        public CategoryEditForm()
        {
            InitializeComponent();
            this.Text = "Добавить категорию";
        }

        // Конструктор для режима редактирования (передаем старые данные в поля)
        public CategoryEditForm(string name, string description) : this()
        {
            this.Text = "Редактировать категорию";
            txtName.Text = name;
            txtDescription.Text = description;
        }

        // Кнопка «Сохранить»
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Простейшая проверка на пустое поле прямо на форме
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Название категории не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Указываем успешный результат и закрываем форму
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Кнопка «Отмена»
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}