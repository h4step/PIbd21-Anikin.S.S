using System;
using System.Windows.Forms;

namespace ComputerSales
{
    public partial class MainForm : Form
    {
        // Конструкторы, которые мы уже сделали (по умолчанию и с DI)
        public MainForm()
        {
            InitializeComponent();
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void операцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        public MainForm(Repositories.IProductRepository productRepository, Repositories.ICategoryRepository categoryRepository) : this()
        {
            // Сохраняем зависимости, если понадобятся для передачи в дочерние формы
        }

        private void КатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открытие справочника: Категории", "Справочники", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ТоварыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открытие справочника: Товары", "Справочники", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void КлиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открытие справочника: Клиенты", "Справочники", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ПродажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Открытие операции: Продажи", "Операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Раздел отчетов пока пуст.", "Отчеты", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}