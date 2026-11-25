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
            this.Text = "Добавить клиента";
        }

        public ClientEditForm(string fullName, string phone) : this()
        {
            this.Text = "Редактировать клиента";
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

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}