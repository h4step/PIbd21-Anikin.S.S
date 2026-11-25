using System;
using System.Linq;
using System.Windows.Forms;
using ComputerSales.Models;
using ComputerSales.Repositories;

namespace ComputerSales.Forms
{
    public partial class ClientForm : Form
    {
        private readonly IClientRepository _clientRepository;

        public ClientForm(IClientRepository clientRepository)
        {
            InitializeComponent();
            _clientRepository = clientRepository;
            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                dataGridViewClients.DataSource = _clientRepository.GetAll().ToList();

                if (dataGridViewClients.Columns["Id"] != null)
                    dataGridViewClients.Columns["Id"].HeaderText = "ID";
                if (dataGridViewClients.Columns["FullName"] != null)
                    dataGridViewClients.Columns["FullName"].HeaderText = "ФИО";
                if (dataGridViewClients.Columns["Phone"] != null)
                    dataGridViewClients.Columns["Phone"].HeaderText = "Телефон";
                if (dataGridViewClients.Columns["Sales"] != null)
                    dataGridViewClients.Columns["Sales"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки клиентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var editForm = new ClientEditForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newClient = Client.CreateEntity(0, editForm.FullName, editForm.Phone);
                        _clientRepository.Add(newClient);
                        LoadClients();
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
            if (dataGridViewClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedClient = (Client)dataGridViewClients.SelectedRows[0].DataBoundItem;

            using (var editForm = new ClientEditForm(selectedClient.FullName, selectedClient.Phone))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var updatedClient = Client.CreateEntity(selectedClient.Id, editForm.FullName, editForm.Phone);
                        _clientRepository.Update(updatedClient);
                        LoadClients();
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
            if (dataGridViewClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedClient = (Client)dataGridViewClients.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show(
                $"Удалить клиента «{selectedClient.FullName}»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _clientRepository.Delete(selectedClient.Id);
                    LoadClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось удалить клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}