namespace ComputerSales.Forms
{
    partial class SaleEditForm
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
            cmbClient = new ComboBox();
            dtpSaleDate = new DateTimePicker();
            cmbProduct = new ComboBox();
            numCount = new NumericUpDown();
            btnAdd = new Button();
            dataGridViewItems = new DataGridView();
            lblTotalAmount = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            SuspendLayout();
            // 
            // cmbClient
            // 
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(2, 14);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(288, 23);
            cmbClient.TabIndex = 0;
            // 
            // dtpSaleDate
            // 
            dtpSaleDate.Location = new Point(310, 14);
            dtpSaleDate.Name = "dtpSaleDate";
            dtpSaleDate.Size = new Size(83, 23);
            dtpSaleDate.TabIndex = 1;
            // 
            // cmbProduct
            // 
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(2, 67);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(288, 23);
            cmbProduct.TabIndex = 2;
            // 
            // numCount
            // 
            numCount.Location = new Point(310, 68);
            numCount.Name = "numCount";
            numCount.Size = new Size(83, 23);
            numCount.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(456, 35);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(168, 36);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Location = new Point(12, 137);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.Size = new Size(432, 185);
            dataGridViewItems.TabIndex = 5;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(12, 119);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(166, 15);
            lblTotalAmount.TabIndex = 6;
            lblTotalAmount.Text = "Отображение общей суммы";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(32, 344);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(171, 52);
            btnSave.TabIndex = 7;
            btnSave.Text = "Провести продажу";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(241, 344);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(190, 52);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // SaleEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblTotalAmount);
            Controls.Add(dataGridViewItems);
            Controls.Add(btnAdd);
            Controls.Add(numCount);
            Controls.Add(cmbProduct);
            Controls.Add(dtpSaleDate);
            Controls.Add(cmbClient);
            Name = "SaleEditForm";
            Text = "SaleEditForm";
            ((System.ComponentModel.ISupportInitialize)numCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbClient;
        private DateTimePicker dtpSaleDate;
        private ComboBox cmbProduct;
        private NumericUpDown numCount;
        private Button btnAdd;
        private DataGridView dataGridViewItems;
        private Label lblTotalAmount;
        private Button btnSave;
        private Button btnCancel;
    }
}