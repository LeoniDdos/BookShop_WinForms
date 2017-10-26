namespace DataBase
{
    partial class CheckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForm));
            this.groupBoxCheck = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFullPrice = new System.Windows.Forms.Label();
            this.labelBookCount = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelCheck = new System.Windows.Forms.Label();
            this.buttonPrintCheck = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBoxCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCheck
            // 
            this.groupBoxCheck.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxCheck.Controls.Add(this.label5);
            this.groupBoxCheck.Controls.Add(this.labelFullPrice);
            this.groupBoxCheck.Controls.Add(this.labelBookCount);
            this.groupBoxCheck.Controls.Add(this.labelLogin);
            this.groupBoxCheck.Controls.Add(this.labelCheck);
            this.groupBoxCheck.Location = new System.Drawing.Point(0, -22);
            this.groupBoxCheck.Name = "groupBoxCheck";
            this.groupBoxCheck.Size = new System.Drawing.Size(326, 302);
            this.groupBoxCheck.TabIndex = 0;
            this.groupBoxCheck.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(313, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Предъявите данный чек в пункте самовывоза";
            // 
            // labelFullPrice
            // 
            this.labelFullPrice.AutoSize = true;
            this.labelFullPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFullPrice.Location = new System.Drawing.Point(69, 184);
            this.labelFullPrice.Name = "labelFullPrice";
            this.labelFullPrice.Size = new System.Drawing.Size(123, 20);
            this.labelFullPrice.TabIndex = 3;
            this.labelFullPrice.Text = "Стоимость: ";
            // 
            // labelBookCount
            // 
            this.labelBookCount.AutoSize = true;
            this.labelBookCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBookCount.Location = new System.Drawing.Point(69, 145);
            this.labelBookCount.Name = "labelBookCount";
            this.labelBookCount.Size = new System.Drawing.Size(125, 20);
            this.labelBookCount.TabIndex = 2;
            this.labelBookCount.Text = "Число книг: ";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(116, 112);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(76, 20);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Логин: ";
            // 
            // labelCheck
            // 
            this.labelCheck.AutoSize = true;
            this.labelCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCheck.Location = new System.Drawing.Point(133, 31);
            this.labelCheck.Name = "labelCheck";
            this.labelCheck.Size = new System.Drawing.Size(59, 29);
            this.labelCheck.TabIndex = 0;
            this.labelCheck.Text = "Чек";
            // 
            // buttonPrintCheck
            // 
            this.buttonPrintCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPrintCheck.Location = new System.Drawing.Point(98, 314);
            this.buttonPrintCheck.Name = "buttonPrintCheck";
            this.buttonPrintCheck.Size = new System.Drawing.Size(133, 38);
            this.buttonPrintCheck.TabIndex = 1;
            this.buttonPrintCheck.Text = "Напечатать";
            this.buttonPrintCheck.UseVisualStyleBackColor = true;
            this.buttonPrintCheck.Click += new System.EventHandler(this.buttonPrintCheck_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 377);
            this.Controls.Add(this.buttonPrintCheck);
            this.Controls.Add(this.groupBoxCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CheckForm";
            this.Text = "Чек";
            this.Load += new System.EventHandler(this.CheckForm_Load);
            this.groupBoxCheck.ResumeLayout(false);
            this.groupBoxCheck.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelFullPrice;
        private System.Windows.Forms.Label labelBookCount;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelCheck;
        private System.Windows.Forms.Button buttonPrintCheck;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}