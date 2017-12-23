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
using System.Security.Cryptography;

namespace DataBase
{
    public partial class MainForm : Form
    {
        int userID;
        string login;

        SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");

        public MainForm()
        {
            InitializeComponent();
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        private void loadToList()
        {
            conn.Open();

            SqlCommand sc = new SqlCommand("SELECT Books.Name FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID"; param.Value = userID; param.SqlDbType = SqlDbType.Int; sc.Parameters.Add(param);

            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("GenreID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Load(reader);

            listBoxBasket.ValueMember = "GenreID";
            listBoxBasket.DisplayMember = "Name";
            listBoxBasket.DataSource = dt;

            conn.Close();
        }

        private static void insertToTable(SqlConnection conn)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Users" +
                        "(Name,Password,Level) Values (@Name,@Password,@Level)", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = "admin"; param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Password"; param.Value = HashPassword("admin"); param.SqlDbType = SqlDbType.Text; cmd.Parameters.Add(param);
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
                    conn.Close();
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
                    conn.Close();
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
                    conn.Close();
                    return;
                }
            }
            conn.Close();
        }

        private static void createNewTable(SqlConnection conn)
        {
            conn.Open();

            string CreatePublishs = "CREATE TABLE Publishs (PublishID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null)";
            string CreateGenres = "CREATE TABLE Genres (GenreID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null); ";
            string CreateUsers = "CREATE TABLE Users (UserID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null, Password Text not null, Level int not null); ";
            string CreateAutors = "CREATE TABLE Autors (AutorID int IDENTITY(1,1) PRIMARY KEY, Surname VarChar(30) not null, Name VarChar(30) not null, Patronymic VarChar(30)); ";
            string CreateBooks = "CREATE TABLE Books (BookID int IDENTITY(1,1) PRIMARY KEY, Name VarChar(30) not null, GenreID int FOREIGN KEY REFERENCES Genres(GenreID)," +
         "  AutorID int FOREIGN KEY REFERENCES Autors(AutorID), PublishID int FOREIGN KEY REFERENCES Publishs(PublishID), Year int not null, Price int not null, Count int not null); ";
            string CreateBaskets = "CREATE TABLE Baskets (UserID int FOREIGN KEY REFERENCES Users(UserID), BookID int FOREIGN KEY REFERENCES Books(BookID)); ";
            string CreateOrders = "CREATE TABLE Orders (OrderID int IDENTITY(1,1) PRIMARY KEY, UserID int FOREIGN KEY REFERENCES Users(UserID))";

            using (SqlCommand cmdCreateTable = new SqlCommand(CreatePublishs + CreateGenres + CreateUsers + CreateAutors + CreateBooks + CreateBaskets + CreateOrders, conn))
            {
                Console.WriteLine("Создаем таблицы");
                try
                {
                    cmdCreateTable.ExecuteNonQuery();
                }
                catch (SqlException se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    conn.Close();
                    return;
                }
            }
            
            conn.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(353, 404);
            this.MaximumSize = new System.Drawing.Size(353, 404);
            this.MinimumSize = new System.Drawing.Size(353, 404);

            groupBoxSignIn.Visible = true;
            groupBoxMain.Visible = false;

            groupBoxSignIn.Size = new System.Drawing.Size(334, 356);
            groupBoxMain.Size = new System.Drawing.Size(1079, 415);

            groupBoxSignIn.Location = new Point(1, 2);
            groupBoxMain.Location = new Point(1, 2);

            try
            {
                conn.Open();
            }
            catch (SqlException se)
            {
                if (se.Number == 4060)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-8BSFAANR\SQLEXPRESS;Integrated Security=True");
                    SqlCommand cmdCreateDataBase = new SqlCommand(string.Format("CREATE DATABASE [{0}]", "BookShop"), connection);
                    connection.Open();
                    Console.WriteLine("Создаем Базу Данных");
                    cmdCreateDataBase.ExecuteNonQuery();
                    Thread.Sleep(5000);
                    connection.Close();
                    connection.Dispose();

                    createNewTable(conn);
                    insertToTable(conn);
                }
            }
            finally
            {
                Console.WriteLine("Соединение успешно произведено");
                conn.Close();
            }

            refreshData();
            loadToList();

            comboBoxSearch.Items.Add("Название");
            comboBoxSearch.Items.Add("Автор");
            comboBoxSearch.SelectedIndex = 0;
        }

        private void refreshData()
        {
            conn.Open();

            var selectBooks = "SELECT BookID as ID, Books.Name as Название, CONCAT (Autors.Surname, ' ', Left (Autors.Name,1), '. ', Left (Autors.Patronymic,1), '.') as Автор, Year as Год, Genres.Name as Жанр, Publishs.Name as Издательство, Books.Price as Стоимость, Books.Count as Количество FROM Books INNER JOIN Autors ON Books.AutorID = Autors.AutorID INNER JOIN Genres ON Books.GenreID=Genres.GenreID INNER JOIN Publishs ON Publishs.PublishID=Books.PublishID";

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectBooks, conn))
            {
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridViewBooks.DataSource = dt.DefaultView;
            }

            conn.Close();

            DataGridViewColumn column = dataGridViewBooks.Columns[0];
            column.Width = 25;
        } 

        private void OutDataButton_Click(object sender, EventArgs e)
        {
            refreshData();
            loadToList();
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            conn.Open();

            if (textBoxLogin.Text.ToString() != "" && textBoxPass.Text.ToString() != "")
            {
                string Name = textBoxLogin.Text.ToString();
                string pass = "";
                string Level = "";
                string cmd = "SELECT Password, Level, UserID FROM Users WHERE Name = @Name";

                SqlCommand sc = new SqlCommand(cmd, conn);

                sc.Parameters.AddWithValue("@Name", Name);

                using (SqlDataReader reader = sc.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pass = reader["Password"].ToString();
                        Level = reader["Level"].ToString();
                        userID = Convert.ToInt32(reader["UserID"]);
                    }
                }
                if (VerifyHashedPassword(pass, textBoxPass.Text.ToString()))
                {
                    login = textBoxLogin.Text;

                    groupBoxSignIn.Visible = false;
                    groupBoxMain.Visible = true;

                    this.Size = new System.Drawing.Size(1105, 469);
                    this.MaximumSize = new System.Drawing.Size(1105, 469);
                    this.MinimumSize = new System.Drawing.Size(1105, 469);

                    if (Level == "0")
                    {
                        buttonAdd.Visible = false;
                        buttonEdit.Visible = false;
                        buttonDelete.Visible = false;
                    }
                }
                else MessageBox.Show("Что-то введено не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conn.Close();
        }

        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            bool flag = false;

            conn.Open();

            if (textBoxLogin.Text.ToString() != "" && textBoxPass.Text.ToString() != "")
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Users" +
                "(Name,Password,Level) Values (@Name,@Password,@Level)", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = textBoxLogin.Text.ToString(); param.SqlDbType = SqlDbType.Text; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Password"; param.Value = HashPassword(textBoxPass.Text.ToString()); param.SqlDbType = SqlDbType.Text; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Level"; param.Value = 0; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                
                Console.WriteLine("Вставляем запись");
                try
                {
                    cmd.ExecuteNonQuery();
                    flag = true;
                    login = textBoxLogin.Text;
                }
                catch (Exception se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    conn.Close();
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
                        conn.Close();
                        return;
                    }

                    userID = (int)sqlout.ExecuteScalar();
                }

            conn.Close();
            groupBoxSignIn.Visible = false;
            groupBoxMain.Visible = true;

            this.Size = new System.Drawing.Size(1105, 469);
            this.MaximumSize = new System.Drawing.Size(1105, 469);
            this.MinimumSize = new System.Drawing.Size(1105, 469);

            buttonAdd.Visible = false;
            buttonEdit.Visible = false;
            buttonDelete.Visible = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(conn);
            addForm.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EditForm editForm = new EditForm(dataGridViewBooks.CurrentCell.RowIndex + 1, conn);
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
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("UPDATE Books SET Count = @Count WHERE BookID = @BookID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Count"; param.Value = 0; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@BookID"; param.Value = dataGridViewBooks.CurrentCell.RowIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                Console.WriteLine("Изменяем запись");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка подключения: {0}", se.Message);
                        conn.Close();
                        return;
                    }
                }
            }

            conn.Close();

            MessageBox.Show("Книга успешно удалена", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        { 
            conn.Open();

            int count;

            using (SqlCommand sqlout = new SqlCommand("SELECT Count FROM Books WHERE BookID = @BookID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@BookID"; param.Value = dataGridViewBooks[0, dataGridViewBooks.CurrentCell.RowIndex].Value; param.SqlDbType = SqlDbType.Int; sqlout.Parameters.Add(param);

                try
                {
                    sqlout.ExecuteNonQuery();
                }
                catch (Exception se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    conn.Close();
                    return;
                }

                count = (int)sqlout.ExecuteScalar();
            }
            if (count > 0)
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Books SET Count = Count - 1 WHERE BookID = @BookID", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@BookID"; param.Value = dataGridViewBooks[0, dataGridViewBooks.CurrentCell.RowIndex].Value; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

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
                            conn.Close();
                            return;
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Baskets (UserID, BookID) Values (@UserID, @BookID)", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@UserID"; param.Value = userID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@BookID"; param.Value = dataGridViewBooks[0, dataGridViewBooks.CurrentCell.RowIndex].Value; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                    Console.WriteLine("Вставляем запись");
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка подключения: {0}", se.Message);
                        conn.Close();
                        return;
                    }
                }
            }
            else MessageBox.Show("Книги в наличии нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            conn.Close();
            textBoxSearch.Text = "";
            refreshData();
            loadToList();
        }

        private void buttonGoToBasket_Click(object sender, EventArgs e)
        {
            BasketForm basketForm = new BasketForm(userID, login, conn);
            basketForm.ShowDialog();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.ToString() != "")
            {
                SqlCommand sc = new SqlCommand();
                conn.Open();

                if (comboBoxSearch.SelectedIndex == 0)
                {
                    sc = new SqlCommand("SELECT BookID as ID, Books.Name as Название, CONCAT (Autors.Surname, ' ', Left (Autors.Name,1), '. ', Left (Autors.Patronymic,1), '.') as Автор, Year as Год, Genres.Name as Жанр, Publishs.Name as Издательство, Books.Price as Стоимость, Books.Count as Количество FROM Books INNER JOIN Autors ON Books.AutorID = Autors.AutorID INNER JOIN Genres ON Books.GenreID=Genres.GenreID INNER JOIN Publishs ON Publishs.PublishID = Books.PublishID WHERE Books.Name = @Name", conn);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Name"; param.Value = textBoxSearch.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; sc.Parameters.Add(param);
                }
                else if (comboBoxSearch.SelectedIndex == 1)
                {
                    sc = new SqlCommand("SELECT BookID as ID, Books.Name as Название, CONCAT (Autors.Surname, ' ', Left (Autors.Name,1), '. ', Left (Autors.Patronymic,1), '.') as Автор, Year as Год, Genres.Name as Жанр, Publishs.Name as Издательство, Books.Price as Стоимость, Books.Count as Количество FROM Books INNER JOIN Autors ON Books.AutorID = Autors.AutorID INNER JOIN Genres ON Books.GenreID=Genres.GenreID INNER JOIN Publishs ON Publishs.PublishID = Books.PublishID WHERE Autors.Surname = @Autor", conn);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Autor"; param.Value = textBoxSearch.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; sc.Parameters.Add(param);
                }

                SqlDataReader reader;

                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewBooks.DataSource = dt;

                conn.Close();
            }
            else MessageBox.Show("Заполните поле поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}