namespace ComputerSales.Forms
{
    partial class ProductEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtCostPrice = new TextBox();
            cmbCategory = new ComboBox();
            cmbOrigin = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            clbFeatures = new CheckedListBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(26, 21);
            txtName.Name = "txtName";
            txtName.Size = new Size(130, 23);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(220, 21);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(130, 23);
            txtPrice.TabIndex = 1;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // txtCostPrice
            // 
            txtCostPrice.Location = new Point(413, 21);
            txtCostPrice.Name = "txtCostPrice";
            txtCostPrice.Size = new Size(130, 23);
            txtCostPrice.TabIndex = 2;
            txtCostPrice.TextChanged += txtCostPrice_TextChanged;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(26, 146);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(126, 23);
            cmbCategory.TabIndex = 3;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // cmbOrigin
            // 
            cmbOrigin.FormattingEnabled = true;
            cmbOrigin.Location = new Point(204, 146);
            cmbOrigin.Name = "cmbOrigin";
            cmbOrigin.Size = new Size(126, 23);
            cmbOrigin.TabIndex = 4;
            cmbOrigin.SelectedIndexChanged += cmbOrigin_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 47);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 5;
            label1.Text = "Название";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(262, 47);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 6;
            label2.Text = "Цена";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(436, 47);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 7;
            label3.Text = "Себестоимость";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 172);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 8;
            label4.Text = "Выбор категории";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(220, 172);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 9;
            label5.Text = "Перечисление";
            // 
            // clbFeatures
            // 
            clbFeatures.FormattingEnabled = true;
            clbFeatures.Location = new Point(400, 146);
            clbFeatures.Name = "clbFeatures";
            clbFeatures.Size = new Size(213, 94);
            clbFeatures.TabIndex = 10;
            clbFeatures.SelectedIndexChanged += clbFeatures_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(29, 367);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(184, 33);
            btnSave.TabIndex = 11;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(245, 367);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(184, 33);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ProductEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(clbFeatures);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbOrigin);
            Controls.Add(cmbCategory);
            Controls.Add(txtCostPrice);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Name = "ProductEditForm";
            Text = "ProductEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtCostPrice;
        private ComboBox cmbCategory;
        private ComboBox cmbOrigin;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private CheckedListBox clbFeatures;
        private Button btnSave;
        private Button btnCancel;
    }
}