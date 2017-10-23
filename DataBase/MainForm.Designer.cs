namespace DataBase
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OutDataButton = new System.Windows.Forms.Button();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.книгиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopDataSet = new DataBase.BookShopDataSet();
            this.книгиTableAdapter = new DataBase.BookShopDataSetTableAdapters.КнигиTableAdapter();
            this.groupBoxBasket = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonGoToBasket = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.ButtonSignIn = new System.Windows.Forms.Button();
            this.ButtonSignUp = new System.Windows.Forms.Button();
            this.groupBoxSignIn = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet)).BeginInit();
            this.groupBoxBasket.SuspendLayout();
            this.groupBoxSignIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutDataButton
            // 
            this.OutDataButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.OutDataButton.Location = new System.Drawing.Point(663, 343);
            this.OutDataButton.Name = "OutDataButton";
            this.OutDataButton.Size = new System.Drawing.Size(98, 39);
            this.OutDataButton.TabIndex = 1;
            this.OutDataButton.Text = "Обновить";
            this.OutDataButton.UseVisualStyleBackColor = false;
            this.OutDataButton.Click += new System.EventHandler(this.OutDataButton_Click);
            // 
            // buttonBuy
            // 
            this.buttonBuy.BackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonBuy.Location = new System.Drawing.Point(546, 343);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(95, 38);
            this.buttonBuy.TabIndex = 3;
            this.buttonBuy.Text = "Купить";
            this.buttonBuy.UseVisualStyleBackColor = false;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(755, 292);
            this.dataGridView1.TabIndex = 2;
            // 
            // книгиBindingSource
            // 
            this.книгиBindingSource.DataMember = "Книги";
            this.книгиBindingSource.DataSource = this.bookShopDataSetBindingSource;
            // 
            // bookShopDataSetBindingSource
            // 
            this.bookShopDataSetBindingSource.DataSource = this.bookShopDataSet;
            this.bookShopDataSetBindingSource.Position = 0;
            // 
            // bookShopDataSet
            // 
            this.bookShopDataSet.DataSetName = "BookShopDataSet";
            this.bookShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // книгиTableAdapter
            // 
            this.книгиTableAdapter.ClearBeforeFill = true;
            // 
            // groupBoxBasket
            // 
            this.groupBoxBasket.Controls.Add(this.listBox1);
            this.groupBoxBasket.Controls.Add(this.buttonGoToBasket);
            this.groupBoxBasket.Location = new System.Drawing.Point(786, 16);
            this.groupBoxBasket.Name = "groupBoxBasket";
            this.groupBoxBasket.Size = new System.Drawing.Size(255, 387);
            this.groupBoxBasket.TabIndex = 3;
            this.groupBoxBasket.TabStop = false;
            this.groupBoxBasket.Text = "Корзина";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(15, 56);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(225, 244);
            this.listBox1.TabIndex = 1;
            // 
            // buttonGoToBasket
            // 
            this.buttonGoToBasket.BackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonGoToBasket.Location = new System.Drawing.Point(40, 342);
            this.buttonGoToBasket.Name = "buttonGoToBasket";
            this.buttonGoToBasket.Size = new System.Drawing.Size(173, 38);
            this.buttonGoToBasket.TabIndex = 0;
            this.buttonGoToBasket.Text = "Перейти к корзине";
            this.buttonGoToBasket.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(54, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(40, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(163, 115);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(100, 22);
            this.textBoxLogin.TabIndex = 7;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(163, 163);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(100, 22);
            this.textBoxPass.TabIndex = 8;
            // 
            // ButtonSignIn
            // 
            this.ButtonSignIn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ButtonSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSignIn.Location = new System.Drawing.Point(74, 215);
            this.ButtonSignIn.Name = "ButtonSignIn";
            this.ButtonSignIn.Size = new System.Drawing.Size(174, 41);
            this.ButtonSignIn.TabIndex = 4;
            this.ButtonSignIn.Text = "Авторизация";
            this.ButtonSignIn.UseVisualStyleBackColor = false;
            this.ButtonSignIn.Click += new System.EventHandler(this.ButtonSignIn_Click);
            // 
            // ButtonSignUp
            // 
            this.ButtonSignUp.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ButtonSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSignUp.Location = new System.Drawing.Point(74, 272);
            this.ButtonSignUp.Name = "ButtonSignUp";
            this.ButtonSignUp.Size = new System.Drawing.Size(174, 41);
            this.ButtonSignUp.TabIndex = 10;
            this.ButtonSignUp.Text = "Регистрация";
            this.ButtonSignUp.UseVisualStyleBackColor = false;
            this.ButtonSignUp.Click += new System.EventHandler(this.ButtonSignUp_Click);
            // 
            // groupBoxSignIn
            // 
            this.groupBoxSignIn.Controls.Add(this.pictureBox1);
            this.groupBoxSignIn.Controls.Add(this.ButtonSignUp);
            this.groupBoxSignIn.Controls.Add(this.textBoxLogin);
            this.groupBoxSignIn.Controls.Add(this.ButtonSignIn);
            this.groupBoxSignIn.Controls.Add(this.textBoxPass);
            this.groupBoxSignIn.Controls.Add(this.label1);
            this.groupBoxSignIn.Controls.Add(this.label2);
            this.groupBoxSignIn.Location = new System.Drawing.Point(852, 433);
            this.groupBoxSignIn.Name = "groupBoxSignIn";
            this.groupBoxSignIn.Size = new System.Drawing.Size(334, 356);
            this.groupBoxSignIn.TabIndex = 11;
            this.groupBoxSignIn.TabStop = false;
            this.groupBoxSignIn.Text = "Авторизация";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DataBase.Properties.Resources.coollogo_com_4973850;
            this.pictureBox1.Location = new System.Drawing.Point(41, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.buttonDelete);
            this.groupBoxMain.Controls.Add(this.buttonEdit);
            this.groupBoxMain.Controls.Add(this.buttonAdd);
            this.groupBoxMain.Controls.Add(this.groupBoxBasket);
            this.groupBoxMain.Controls.Add(this.dataGridView1);
            this.groupBoxMain.Controls.Add(this.buttonBuy);
            this.groupBoxMain.Controls.Add(this.OutDataButton);
            this.groupBoxMain.Location = new System.Drawing.Point(1, 2);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(1079, 415);
            this.groupBoxMain.TabIndex = 12;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Магазин";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Silver;
            this.buttonAdd.Location = new System.Drawing.Point(6, 343);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(119, 38);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.Silver;
            this.buttonEdit.Location = new System.Drawing.Point(145, 343);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(119, 38);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Изменение";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Silver;
            this.buttonDelete.Location = new System.Drawing.Point(283, 344);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(119, 38);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Удаление";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1177, 735);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.groupBoxSignIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "BookShop";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet)).EndInit();
            this.groupBoxBasket.ResumeLayout(false);
            this.groupBoxSignIn.ResumeLayout(false);
            this.groupBoxSignIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OutDataButton;
        private System.Windows.Forms.BindingSource bookShopDataSetBindingSource;
        private BookShopDataSet bookShopDataSet;
        private System.Windows.Forms.BindingSource книгиBindingSource;
        private BookShopDataSetTableAdapters.КнигиTableAdapter книгиTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxBasket;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonGoToBasket;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Button ButtonSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ButtonSignUp;
        private System.Windows.Forms.GroupBox groupBoxSignIn;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
    }
}

