namespace ComputerSales.Forms
{
    partial class SalesForm
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
            dataGridViewSales = new DataGridView();
            dataGridViewSaleItems = new DataGridView();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSaleItems).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSales
            // 
            dataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSales.Location = new Point(12, 22);
            dataGridViewSales.Name = "dataGridViewSales";
            dataGridViewSales.Size = new Size(296, 210);
            dataGridViewSales.TabIndex = 0;
            // 
            // dataGridViewSaleItems
            // 
            dataGridViewSaleItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSaleItems.Location = new Point(379, 22);
            dataGridViewSaleItems.Name = "dataGridViewSaleItems";
            dataGridViewSaleItems.Size = new Size(347, 210);
            dataGridViewSaleItems.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 369);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(190, 69);
            btnAdd.TabIndex = 2;
            btnAdd.Text = " Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewSaleItems);
            Controls.Add(dataGridViewSales);
            Name = "SalesForm";
            Text = "SalesForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSaleItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewSales;
        private DataGridView dataGridViewSaleItems;
        private Button btnAdd;
    }
}