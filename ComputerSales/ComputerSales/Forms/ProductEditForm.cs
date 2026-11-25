using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ComputerSales.Models;
using ComputerSales.Models.Enums;

namespace ComputerSales.Forms
{
    public partial class ProductEditForm : Form
    {
        public string ProductName => txtName.Text.Trim();
        public decimal Price { get; private set; }
        public decimal CostPrice { get; private set; }
        public int CategoryId => (int)cmbCategory.SelectedValue;
        public ProductOrigin Origin => (ProductOrigin)cmbOrigin.SelectedItem;
        public ProductFeatures Features { get; private set; }

        public ProductEditForm(List<Category> categories)
        {
            InitializeComponent();
            Text = "Добавить товар";
            InitControls(categories);
        }

        public ProductEditForm(List<Category> categories, Product product) : this(categories)
        {
            Text = "Редактировать товар";
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString(CultureInfo.CurrentCulture);
            txtCostPrice.Text = product.CostPrice.ToString(CultureInfo.CurrentCulture);
            cmbCategory.SelectedValue = product.CategoryId;
            cmbOrigin.SelectedItem = product.Origin;
            SetSelectedFeatures(product.Features);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e) { }
        private void txtCostPrice_TextChanged(object sender, EventArgs e) { }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbOrigin_SelectedIndexChanged(object sender, EventArgs e) { }
        private void clbFeatures_SelectedIndexChanged(object sender, EventArgs e) { }
        private void InitControls(List<Category> categories)
        {
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            cmbOrigin.DataSource = Enum.GetValues(typeof(ProductOrigin));

            clbFeatures.Items.Clear();
            foreach (ProductFeatures feature in Enum.GetValues(typeof(ProductFeatures)))
            {
                if (feature != ProductFeatures.None)
                    clbFeatures.Items.Add(feature);
            }
        }

        private void SetSelectedFeatures(ProductFeatures features)
        {
            for (int i = 0; i < clbFeatures.Items.Count; i++)
            {
                var item = (ProductFeatures)clbFeatures.Items[i];
                clbFeatures.SetItemChecked(i, features.HasFlag(item));
            }
        }

        private ProductFeatures GetSelectedFeatures()
        {
            ProductFeatures result = ProductFeatures.None;
            foreach (var checkedItem in clbFeatures.CheckedItems)
            {
                result |= (ProductFeatures)checkedItem;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out var price) || price < 0)
            {
                MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtCostPrice.Text.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out var costPrice) || costPrice < 0)
            {
                MessageBox.Show("Введите корректную себестоимость.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbCategory.SelectedValue == null || cmbOrigin.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию и происхождение товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Price = price;
            CostPrice = costPrice;
            Features = GetSelectedFeatures();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}