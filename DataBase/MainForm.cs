using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace DataBase
{
    public partial class MainForm : Form
    {
      //static public int RowInd;
        /*void ConnectTo() //Нужно ли?
        {
            //connStringBuilder = new SqlConnectionStringBuilder();
            //connStringBuilder.DataSource = "LAPTOP-8BSFAANR\\SQLEXPRESS";
            //connStringBuilder.InitialCatalog = "Книги";
            //connStringBuilder.IntegratedSecurity = true;

            //conn = new SqlConnection(connStringBuilder.ToString());
        }*/

        int UserID;
        string Login;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadToList()
        {

            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            conn.Open();
            SqlCommand sc = new SqlCommand("SELECT Books.Name FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID"; param.Value = UserID; param.SqlDbType = SqlDbType.Int; sc.Parameters.Add(param);

            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("GenreID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Load(reader);

            listBox1.ValueMember = "GenreID";
            listBox1.DisplayMember = "Name";
            listBox1.DataSource = dt;

            conn.Close();
        }

        private static void InsertToTable(SqlConnection conn)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Users" +
                        "(Name,Password,Level) Values (@Name,@Password,@Level)", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = "admin"; param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Password"; param.Value = "admin"; param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Level"; param.Value = 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                Console.WriteLine("Вставляем запись");
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    return;
                }
            }
            using (SqlCommand cmd2 = new SqlCommand("INSERT INTO Genres" +
        "(Name) Values (@Name)", conn))
            {
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Name"; param2.Value = "Фантастика"; param2.SqlDbType = SqlDbType.VarChar; cmd2.Parameters.Add(param2);

                Console.WriteLine("Вставляем запись");
                try
                {
                    cmd2.ExecuteNonQuery();
                }
                catch (SqlException se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    return;
                }
            }
            using (SqlCommand cmd3 = new SqlCommand("INSERT INTO Publishs" +
        "(Name) Values (@Name)", conn))
            {
                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Name"; param3.Value = "Миф"; param3.SqlDbType = SqlDbType.VarChar; cmd3.Parameters.Add(param3);

                Console.WriteLine("Вставляем запись");
                try
                {
                    cmd3.ExecuteNonQuery();
                }
                catch (SqlException se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    return;
                }
            }
            using (SqlCommand cmd4 = new SqlCommand("INSERT INTO Autors" +
            "(Surname,Name,Patronymic) Values (@Surname,@Name,@Patronymic)", conn))
            {
                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@SurName"; param4.Value = "Пушкин"; param4.SqlDbType = SqlDbType.VarChar; cmd4.Parameters.Add(param4);
                param4 = new SqlParameter();
                param4.ParameterName = "@Name"; param4.Value = "Александр"; param4.SqlDbType = SqlDbType.VarChar; cmd4.Parameters.Add(param4);
                param4 = new SqlParameter();
                param4.ParameterName = "@Patronymic"; param4.Value = "Сергеевич"; param4.SqlDbType = SqlDbType.VarChar; cmd4.Parameters.Add(param4);

                Console.WriteLine("Вставляем запись");
                try
                {
                    cmd4.ExecuteNonQuery();
                }
                catch (SqlException se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    return;
                }
            }
            conn.Close();
        }

        private static void CreateNewTable(SqlConnection conn)
        {
            conn.Open();

            string CreatePublishs = "CREATE TABLE Publishs (PublishID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null)";
            string CreateGenres = "CREATE TABLE Genres (GenreID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null); ";
            string CreateUsers = "CREATE TABLE Users (UserID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null, Password VarChar(30) not null, Level int not null); ";
            string CreateAutors = "CREATE TABLE Autors (AutorID int IDENTITY(1,1) PRIMARY KEY, Surname VarChar(30) not null, Name VarChar(30) not null, Patronymic VarChar(30)); ";
            string CreateBooks = "CREATE TABLE Books (BookID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null, GenreID int FOREIGN KEY REFERENCES Genres(GenreID)," +
         "  AutorID int FOREIGN KEY REFERENCES Autors(AutorID), Year int not null, PublishID int FOREIGN KEY REFERENCES Publishs(PublishID), Price int not null, Count int not null, Exist int not null); ";
            string CreateBaskets = "CREATE TABLE Baskets (UserID int FOREIGN KEY REFERENCES Users(UserID), BookID int FOREIGN KEY REFERENCES Books(BookID))";


            using (SqlCommand cmdCreateTable = new SqlCommand(CreatePublishs + CreateGenres + CreateUsers + CreateAutors + CreateBooks + CreateBaskets, conn))
            {
                Console.WriteLine("Создаем таблицы");
                try
                {
                    cmdCreateTable.ExecuteNonQuery();
                }
                catch (SqlException se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    return;
                }
            }
            
            conn.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(353, 404); //Размер авторизации формы
            this.MaximumSize = new System.Drawing.Size(353, 404);
            this.MinimumSize = new System.Drawing.Size(353, 404);

            groupBoxSignIn.Visible = true;
            groupBoxMain.Visible = false;

            groupBoxSignIn.Size = new System.Drawing.Size(334, 356);
            groupBoxMain.Size = new System.Drawing.Size(1079, 415);

            groupBoxSignIn.Location = new Point(1, 2);
            groupBoxMain.Location = new Point(1, 2);

            /*this.tabControl1.Size = new System.Drawing.Size(799, 487); //Размер окна с элементами
            this.dataGridView1.Size = new System.Drawing.Size(720, 220); //Размер dataGridView
            */

            //this.SizeToContent = SizeToContent.WidthAndHeight; //Для автоизменения размеров окна под элементы

            string connStr = @"Data Source=LAPTOP-8BSFAANR\SQLEXPRESS;
                            Initial Catalog=BookShop;
                            Integrated Security=True";
            SqlConnection connection = new SqlConnection(connStr);
            try
            {
                connection.Open();
            }
            catch (SqlException se)
            {
                if (se.Number == 4060)
                {
                    //connection.Close(); //Видимо нету смысла это делать
                    connection = new SqlConnection(@"Data Source=LAPTOP-8BSFAANR\SQLEXPRESS;Integrated Security=True");
                    SqlCommand cmdCreateDataBase = new SqlCommand(string.Format("CREATE DATABASE [{0}]", "BookShop"), connection);
                    connection.Open();
                    Console.WriteLine("Создаем Базу Данных");
                    cmdCreateDataBase.ExecuteNonQuery();
                    connection.Close();
                    Thread.Sleep(10000);

                    SqlConnection connection2 = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
                    CreateNewTable(connection2);

                    connection2.Close();

                    InsertToTable(connection2);

                    connection = new SqlConnection(connStr);
                    connection.Open();
                }
            }
            finally
            {
                Console.WriteLine("Соединение успешно произведено");
                connection.Close();
                //connection.Dispose();
            }
        }

        private void RefreshData()
        {
            SqlConnection connection = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            connection.Open();

            var selectBooks = "SELECT BookID as Номер, Books.Name as Название, CONCAT (Autors.Surname, ' ', Left (Autors.Name,1), '. ', Left (Autors.Patronymic,1), '.') as Автор, Year as Год, Genres.Name as Жанр, Publishs.Name as Издательство, Books.Price as Стоимость, Books.Exist as Наличие FROM Books INNER JOIN Autors ON Books.AutorID = Autors.AutorID INNER JOIN Genres ON Books.GenreID=Genres.GenreID INNER JOIN Publishs ON Publishs.PublishID=Books.PublishID";

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(
            selectBooks, connection))
            {
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
            }
            connection.Close();
        } 

        private void OutDataButton_Click(object sender, EventArgs e)
        {
            RefreshData();

            LoadToList();
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            conn.Open();
            if (textBoxLogin.Text.ToString() != "" && textBoxPass.Text.ToString() != "")
            {
                string Name = textBoxLogin.Text.ToString();
                string pass = "";
                string Level = "";
                string getP = "SELECT Password, Level, UserID FROM Users WHERE Name = @Name";

                SqlCommand commandBrands = new SqlCommand(getP, conn);

                commandBrands.Parameters.AddWithValue("@Name", Name);

                using (SqlDataReader reader = commandBrands.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pass = reader["Password"].ToString();
                        Level = reader["Level"].ToString();
                        UserID = Convert.ToInt32(reader["UserID"]);
                    }
                }
                if (pass == textBoxPass.Text.ToString())
                {
                    Login = textBoxLogin.Text;

                    groupBoxSignIn.Visible = false;
                    groupBoxMain.Visible = true;

                    this.Size = new System.Drawing.Size(1105, 469);
                    this.MaximumSize = new System.Drawing.Size(1105, 469);
                    this.MinimumSize = new System.Drawing.Size(1105, 469);

                    if (Level == "0")
                    {
                        buttonAdd.Enabled = false;
                        buttonEdit.Enabled = false;
                        buttonDelete.Enabled = false;
                    }

                    //MessageBox.Show(UserID.ToString(), "UserID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Что-то введено не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conn.Close();
        }

        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");

            bool flag = false;

            conn.Open();
            if (textBoxLogin.Text.ToString() != "" && textBoxPass.Text.ToString() != "")
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Users" +
                "(Name,Password,Level) Values (@Name,@Password,@Level)", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = textBoxLogin.Text.ToString(); param.SqlDbType = SqlDbType.Text; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Password"; param.Value = textBoxPass.Text.ToString(); param.SqlDbType = SqlDbType.Text; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Level"; param.Value = 0; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                Console.WriteLine("Вставляем запись");
                try
                {
                    cmd.ExecuteNonQuery();
                    flag = true;

                    Login = textBoxLogin.Text;
                }
                catch (Exception se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    return;
                }
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (flag == true)
                using (SqlCommand sqlout = new SqlCommand("SELECT UserID FROM Users WHERE Name = @Name", conn))
                {
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@Name"; param2.Value = textBoxLogin.Text.ToString(); param2.SqlDbType = SqlDbType.VarChar; sqlout.Parameters.Add(param2);

                    try
                    {
                        sqlout.ExecuteNonQuery();
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка подключения: {0}", se.Message);
                        return;
                    }

                    UserID = (int)sqlout.ExecuteScalar();

                    //MessageBox.Show(UserID.ToString(), "UserID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            conn.Close();
            groupBoxSignIn.Visible = false;
            groupBoxMain.Visible = true;

            this.Size = new System.Drawing.Size(1105, 469);
            this.MaximumSize = new System.Drawing.Size(1105, 469);
            this.MinimumSize = new System.Drawing.Size(1105, 469);

            buttonAdd.Enabled = false;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EditForm editForm = new EditForm(dataGridView1.CurrentCell.RowIndex + 1);
                editForm.ShowDialog();
            }
            catch (Exception se)
            {
                Console.WriteLine("Ошибка: {0}", se.Message);
                MessageBox.Show("Выберите строку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Books" +
                   " SET Exist = @Exist, Count = @Count WHERE BookID = @BookID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Exist"; param.Value = 0; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Count"; param.Value = 0; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@BookID"; param.Value = dataGridView1.CurrentCell.RowIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                Console.WriteLine("Изменяем запись");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка подключения: {0}", se.Message);
                        return;
                    }
                }
            }
            conn.Close();
            MessageBox.Show("Книга успешно удалена", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonBuy_Click(object sender, EventArgs e) //Может отказаться от exist??
        { 
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            conn.Open();

            int count;

            using (SqlCommand sqlout = new SqlCommand("SELECT Count FROM Books WHERE BookID = @BookID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@BookID"; param.Value = dataGridView1.CurrentCell.RowIndex + 1; param.SqlDbType = SqlDbType.Int; sqlout.Parameters.Add(param);

                try
                {
                    sqlout.ExecuteNonQuery();
                }
                catch (Exception se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    return;
                }

                count = (int)sqlout.ExecuteScalar();
            }
            if (count > 0)
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Books" +
                     " SET Exist = @Exist, Count = Count - 1 WHERE BookID = @BookID", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Exist"; param.Value = (count - 1) > 0 ? 1 : 0; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@BookID"; param.Value = dataGridView1.CurrentCell.RowIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                    Console.WriteLine("Изменяем запись");
                    {
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Книга добавлена в корзину", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception se)
                        {
                            Console.WriteLine("Ошибка подключения: {0}", se.Message);
                            return;
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Baskets" +
                  "(UserID, BookID) Values (@UserID, @BookID)", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@UserID"; param.Value = UserID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@BookID"; param.Value = dataGridView1.CurrentCell.RowIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                    Console.WriteLine("Вставляем запись");
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка подключения: {0}", se.Message);
                        return;
                    }
                }

                RefreshData();
                LoadToList();
            }
            else MessageBox.Show("Книги в наличии нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conn.Close();
        }

        private void buttonGoToBasket_Click(object sender, EventArgs e)
        {
            BasketForm basketForm = new BasketForm(UserID, Login);
            basketForm.ShowDialog();
        }
    }
}