namespace DataBase
{
    partial class BasketForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewBasket = new System.Windows.Forms.DataGridView();
            this.buttonBuyBooks = new System.Windows.Forms.Button();
            this.buttonRemoveBook = new System.Windows.Forms.Button();
            this.labelFullPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(148, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Корзина";
            // 
            // dataGridViewBasket
            // 
            this.dataGridViewBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBasket.Location = new System.Drawing.Point(34, 82);
            this.dataGridViewBasket.Name = "dataGridViewBasket";
            this.dataGridViewBasket.RowTemplate.Height = 24;
            this.dataGridViewBasket.Size = new System.Drawing.Size(349, 181);
            this.dataGridViewBasket.TabIndex = 1;
            // 
            // buttonBuyBooks
            // 
            this.buttonBuyBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBuyBooks.Location = new System.Drawing.Point(245, 335);
            this.buttonBuyBooks.Name = "buttonBuyBooks";
            this.buttonBuyBooks.Size = new System.Drawing.Size(138, 51);
            this.buttonBuyBooks.TabIndex = 2;
            this.buttonBuyBooks.Text = "Купить";
            this.buttonBuyBooks.UseVisualStyleBackColor = true;
            this.buttonBuyBooks.Click += new System.EventHandler(this.buttonBuyBooks_Click);
            // 
            // buttonRemoveBook
            // 
            this.buttonRemoveBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRemoveBook.Location = new System.Drawing.Point(34, 335);
            this.buttonRemoveBook.Name = "buttonRemoveBook";
            this.buttonRemoveBook.Size = new System.Drawing.Size(138, 51);
            this.buttonRemoveBook.TabIndex = 3;
            this.buttonRemoveBook.Text = "Убрать";
            this.buttonRemoveBook.UseVisualStyleBackColor = true;
            this.buttonRemoveBook.Click += new System.EventHandler(this.buttonRemoveBook_Click);
            // 
            // labelFullPrice
            // 
            this.labelFullPrice.AutoSize = true;
            this.labelFullPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFullPrice.Location = new System.Drawing.Point(90, 288);
            this.labelFullPrice.Name = "labelFullPrice";
            this.labelFullPrice.Size = new System.Drawing.Size(59, 20);
            this.labelFullPrice.TabIndex = 4;
            this.labelFullPrice.Text = "label2";
            // 
            // BasketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 442);
            this.Controls.Add(this.labelFullPrice);
            this.Controls.Add(this.buttonRemoveBook);
            this.Controls.Add(this.buttonBuyBooks);
            this.Controls.Add(this.dataGridViewBasket);
            this.Controls.Add(this.label1);
            this.Name = "BasketForm";
            this.Text = "Корзина";
            this.Load += new System.EventHandler(this.BasketForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBasket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewBasket;
        private System.Windows.Forms.Button buttonBuyBooks;
        private System.Windows.Forms.Button buttonRemoveBook;
        private System.Windows.Forms.Label labelFullPrice;
    }
}