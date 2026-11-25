using System;
using System.Windows.Forms;

namespace ComputerSales.Forms
{
    public partial class ClientEditForm : Form
    {
        public string FullName => txtFullName.Text.Trim();
        public string Phone => txtPhone.Text.Trim();

        public ClientEditForm()
        {
            InitializeComponent();
            Text = "Добавить клиента";
        }

        public ClientEditForm(string fullName, string phone) : this()
        {
            Text = "Редактировать клиента";
            txtFullName.Text = fullName;
            txtPhone.Text = phone;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("ФИО не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Телефон не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}