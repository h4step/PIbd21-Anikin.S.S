using System;
using System.Windows.Forms;
using ComputerSales.Forms;
using ComputerSales.Repositories;

namespace ComputerSales
{
    public partial class MainForm : Form
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleProductRepository _saleProductRepository;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(
            ICategoryRepository categoryRepository,
            IClientRepository clientRepository,
            IProductRepository productRepository,
            ISaleRepository saleRepository,
            ISaleProductRepository saleProductRepository) : this()
        {
            _categoryRepository = categoryRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _saleRepository = saleRepository;
            _saleProductRepository = saleProductRepository;
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void операцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void КатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new CategoriesForm(_categoryRepository);
            form.ShowDialog();
        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new ClientForm(_clientRepository);
            form.ShowDialog();
        }

        private void ТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new ProductForms(_productRepository, _categoryRepository);
            form.ShowDialog();
        }

        private void ПродажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new SalesForm(
                _saleRepository,
                _saleProductRepository,
                _clientRepository,
                _productRepository);
            form.ShowDialog();
        }

        private void ОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Раздел отчетов пока пуст.", "Отчеты", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}