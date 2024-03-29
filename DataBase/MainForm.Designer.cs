﻿namespace DataBase
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
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.книгиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookShopDataSet = new DataBase.BookShopDataSet();
            this.книгиTableAdapter = new DataBase.BookShopDataSetTableAdapters.КнигиTableAdapter();
            this.groupBoxBasket = new System.Windows.Forms.GroupBox();
            this.listBoxBasket = new System.Windows.Forms.ListBox();
            this.buttonGoToBasket = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.ButtonSignIn = new System.Windows.Forms.Button();
            this.ButtonSignUp = new System.Windows.Forms.Button();
            this.groupBoxSignIn = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxServerName = new System.Windows.Forms.GroupBox();
            this.textBoxInputServer = new System.Windows.Forms.TextBox();
            this.buttonServerIn = new System.Windows.Forms.Button();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet)).BeginInit();
            this.groupBoxBasket.SuspendLayout();
            this.groupBoxSignIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxMain.SuspendLayout();
            this.groupBoxServerName.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutDataButton
            // 
            this.OutDataButton.BackColor = System.Drawing.Color.Silver;
            this.OutDataButton.Location = new System.Drawing.Point(566, 344);
            this.OutDataButton.Name = "OutDataButton";
            this.OutDataButton.Size = new System.Drawing.Size(94, 38);
            this.OutDataButton.TabIndex = 9;
            this.OutDataButton.Text = "Обновить";
            this.OutDataButton.UseVisualStyleBackColor = false;
            this.OutDataButton.Click += new System.EventHandler(this.OutDataButton_Click);
            // 
            // buttonBuy
            // 
            this.buttonBuy.BackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBuy.Location = new System.Drawing.Point(666, 344);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(95, 38);
            this.buttonBuy.TabIndex = 8;
            this.buttonBuy.Text = "Купить";
            this.buttonBuy.UseVisualStyleBackColor = false;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(6, 29);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.RowTemplate.Height = 24;
            this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBooks.Size = new System.Drawing.Size(755, 292);
            this.dataGridViewBooks.TabIndex = 2;
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
            this.groupBoxBasket.Controls.Add(this.listBoxBasket);
            this.groupBoxBasket.Controls.Add(this.buttonGoToBasket);
            this.groupBoxBasket.Location = new System.Drawing.Point(786, 16);
            this.groupBoxBasket.Name = "groupBoxBasket";
            this.groupBoxBasket.Size = new System.Drawing.Size(255, 387);
            this.groupBoxBasket.TabIndex = 3;
            this.groupBoxBasket.TabStop = false;
            this.groupBoxBasket.Text = "Корзина";
            // 
            // listBoxBasket
            // 
            this.listBoxBasket.FormattingEnabled = true;
            this.listBoxBasket.ItemHeight = 16;
            this.listBoxBasket.Location = new System.Drawing.Point(15, 56);
            this.listBoxBasket.Name = "listBoxBasket";
            this.listBoxBasket.Size = new System.Drawing.Size(225, 244);
            this.listBoxBasket.TabIndex = 1;
            // 
            // buttonGoToBasket
            // 
            this.buttonGoToBasket.BackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonGoToBasket.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGoToBasket.Location = new System.Drawing.Point(40, 342);
            this.buttonGoToBasket.Name = "buttonGoToBasket";
            this.buttonGoToBasket.Size = new System.Drawing.Size(173, 38);
            this.buttonGoToBasket.TabIndex = 10;
            this.buttonGoToBasket.Text = "Перейти к корзине";
            this.buttonGoToBasket.UseVisualStyleBackColor = false;
            this.buttonGoToBasket.Click += new System.EventHandler(this.buttonGoToBasket_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(54, 115);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(70, 20);
            this.labelLogin.TabIndex = 5;
            this.labelLogin.Text = "Логин:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(40, 163);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(84, 20);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(163, 115);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(100, 22);
            this.textBoxLogin.TabIndex = 1;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(163, 163);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(100, 22);
            this.textBoxPass.TabIndex = 2;
            // 
            // ButtonSignIn
            // 
            this.ButtonSignIn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ButtonSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSignIn.Location = new System.Drawing.Point(74, 215);
            this.ButtonSignIn.Name = "ButtonSignIn";
            this.ButtonSignIn.Size = new System.Drawing.Size(174, 41);
            this.ButtonSignIn.TabIndex = 3;
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
            this.ButtonSignUp.TabIndex = 4;
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
            this.groupBoxSignIn.Controls.Add(this.labelLogin);
            this.groupBoxSignIn.Controls.Add(this.labelPassword);
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
            this.groupBoxMain.Controls.Add(this.comboBoxSearch);
            this.groupBoxMain.Controls.Add(this.textBoxSearch);
            this.groupBoxMain.Controls.Add(this.buttonSearch);
            this.groupBoxMain.Controls.Add(this.OutDataButton);
            this.groupBoxMain.Controls.Add(this.buttonDelete);
            this.groupBoxMain.Controls.Add(this.buttonEdit);
            this.groupBoxMain.Controls.Add(this.buttonAdd);
            this.groupBoxMain.Controls.Add(this.groupBoxBasket);
            this.groupBoxMain.Controls.Add(this.dataGridViewBooks);
            this.groupBoxMain.Controls.Add(this.buttonBuy);
            this.groupBoxMain.Location = new System.Drawing.Point(1, 2);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(1079, 415);
            this.groupBoxMain.TabIndex = 12;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Магазин";
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearch.FormattingEnabled = true;
            this.comboBoxSearch.Location = new System.Drawing.Point(261, 352);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(103, 24);
            this.comboBoxSearch.TabIndex = 12;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(377, 352);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(102, 22);
            this.textBoxSearch.TabIndex = 11;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.Location = new System.Drawing.Point(485, 344);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 38);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Искать";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Silver;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(172, 344);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(77, 38);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.Silver;
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEdit.Location = new System.Drawing.Point(89, 344);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(77, 38);
            this.buttonEdit.TabIndex = 6;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Silver;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(6, 344);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(77, 38);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupBoxServerName
            // 
            this.groupBoxServerName.Controls.Add(this.labelStatus);
            this.groupBoxServerName.Controls.Add(this.textBoxInputServer);
            this.groupBoxServerName.Controls.Add(this.buttonServerIn);
            this.groupBoxServerName.Controls.Add(this.labelInput);
            this.groupBoxServerName.Location = new System.Drawing.Point(502, 433);
            this.groupBoxServerName.Name = "groupBoxServerName";
            this.groupBoxServerName.Size = new System.Drawing.Size(334, 356);
            this.groupBoxServerName.TabIndex = 13;
            this.groupBoxServerName.TabStop = false;
            this.groupBoxServerName.Text = "Название сервера";
            // 
            // textBoxInputServer
            // 
            this.textBoxInputServer.Location = new System.Drawing.Point(60, 158);
            this.textBoxInputServer.Name = "textBoxInputServer";
            this.textBoxInputServer.Size = new System.Drawing.Size(217, 22);
            this.textBoxInputServer.TabIndex = 1;
            // 
            // buttonServerIn
            // 
            this.buttonServerIn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonServerIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonServerIn.Location = new System.Drawing.Point(82, 220);
            this.buttonServerIn.Name = "buttonServerIn";
            this.buttonServerIn.Size = new System.Drawing.Size(174, 41);
            this.buttonServerIn.TabIndex = 3;
            this.buttonServerIn.Text = "Ввод";
            this.buttonServerIn.UseVisualStyleBackColor = false;
            this.buttonServerIn.Click += new System.EventHandler(this.buttonServerIn_Click);
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInput.Location = new System.Drawing.Point(48, 115);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(271, 20);
            this.labelInput.TabIndex = 5;
            this.labelInput.Text = "Введите название сервера:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(43, 276);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(276, 17);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Идёт настройка, пожалуйста подождите";
            this.labelStatus.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1177, 735);
            this.Controls.Add(this.groupBoxServerName);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.groupBoxSignIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "BookShop";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.книгиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookShopDataSet)).EndInit();
            this.groupBoxBasket.ResumeLayout(false);
            this.groupBoxSignIn.ResumeLayout(false);
            this.groupBoxSignIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.groupBoxServerName.ResumeLayout(false);
            this.groupBoxServerName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OutDataButton;
        private System.Windows.Forms.BindingSource bookShopDataSetBindingSource;
        private BookShopDataSet bookShopDataSet;
        private System.Windows.Forms.BindingSource книгиBindingSource;
        private BookShopDataSetTableAdapters.КнигиTableAdapter книгиTableAdapter;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.GroupBox groupBoxBasket;
        private System.Windows.Forms.ListBox listBoxBasket;
        private System.Windows.Forms.Button buttonGoToBasket;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Button ButtonSignIn;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ButtonSignUp;
        private System.Windows.Forms.GroupBox groupBoxSignIn;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.GroupBox groupBoxServerName;
        private System.Windows.Forms.TextBox textBoxInputServer;
        private System.Windows.Forms.Button buttonServerIn;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelStatus;
    }
}

