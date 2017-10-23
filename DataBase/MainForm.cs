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
      static public int RowInd;
        /*void ConnectTo() //Нужно ли?
        {
            //connStringBuilder = new SqlConnectionStringBuilder();
            //connStringBuilder.DataSource = "LAPTOP-8BSFAANR\\SQLEXPRESS";
            //connStringBuilder.InitialCatalog = "Книги";
            //connStringBuilder.IntegratedSecurity = true;

            //conn = new SqlConnection(connStringBuilder.ToString());
        }*/

        public MainForm()
        {
            InitializeComponent();
        }

        private static void InsertToTable(SqlConnection conn, string tbl)
        {
            conn.Open();
            switch (tbl)
            {
                case "start":
                    {
                        using (SqlCommand cmd = new SqlCommand("Insert into Users" +
                        "(Name,Password,Level) Values (@Name,@Password,@Level)", conn))
                        {
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@Name"; param.Value = "admin"; param.SqlDbType = SqlDbType.VarChar;
                            cmd.Parameters.Add(param);
                            param = new SqlParameter();
                            param.ParameterName = "@Password"; param.Value = "admin"; param.SqlDbType = SqlDbType.VarChar;
                            cmd.Parameters.Add(param);
                            param = new SqlParameter();
                            param.ParameterName = "@Level"; param.Value = 1; param.SqlDbType = SqlDbType.Int;
                            cmd.Parameters.Add(param);

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
                            using (SqlCommand cmd2 = new SqlCommand("Insert into Genres" +
                        "(Name) Values (@Name)", conn))
                            {
                                SqlParameter param2 = new SqlParameter();
                                param2.ParameterName = "@Name"; param2.Value = "Фантастика"; param2.SqlDbType = SqlDbType.VarChar;
                                cmd2.Parameters.Add(param2);

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
                        using (SqlCommand cmd3 = new SqlCommand("Insert into Publishs" +
                    "(Name) Values (@Name)", conn))
                        {
                            SqlParameter param3 = new SqlParameter();
                            param3.ParameterName = "@Name"; param3.Value = "Миф"; param3.SqlDbType = SqlDbType.VarChar;
                            cmd3.Parameters.Add(param3);

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
                        using (SqlCommand cmd4 = new SqlCommand("Insert into Autors" +
                        "(Surname,Name,Patronymic) Values (@Surname,@Name,@Patronymic)", conn))
                        {
                            SqlParameter param4 = new SqlParameter();
                            param4.ParameterName = "@SurName"; param4.Value = "Пушкин"; param4.SqlDbType = SqlDbType.VarChar;
                            cmd4.Parameters.Add(param4);
                            param4 = new SqlParameter();
                            param4.ParameterName = "@Name"; param4.Value = "Александр"; param4.SqlDbType = SqlDbType.VarChar;
                            cmd4.Parameters.Add(param4);
                            param4 = new SqlParameter();
                            param4.ParameterName = "@Patronymic"; param4.Value = "Сергеевич"; param4.SqlDbType = SqlDbType.VarChar;
                            cmd4.Parameters.Add(param4);

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
                        break; }
                        default:
                    break;
                    }

                    conn.Close();
            }

        private static void CreateNewTable(SqlConnection conn)
        {
            conn.Open();

            using (SqlCommand cmdCreateTable = new SqlCommand("CREATE TABLE " +
         " Publishs (PublishID int IDENTITY(1,1) PRIMARY KEY" +
         ", Name VarChar(30) not null)", conn))
            {
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

            using (SqlCommand cmdCreateTable = new SqlCommand("CREATE TABLE " +
         " Genres (GenreID int IDENTITY(1,1) PRIMARY KEY" +
         ", Name VarChar(30) not null)", conn))
            {
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

            using (SqlCommand cmdCreateTable = new SqlCommand("CREATE TABLE " +
         " Users (UserID int IDENTITY(1,1) PRIMARY KEY" +
         ", Name VarChar(30) not null," +
         "  Password VarChar(30) not null," +
         "  Level int not null)", conn))
            {
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

            using (SqlCommand cmdCreateTable = new SqlCommand("CREATE TABLE " +
         " Autors (AutorID int IDENTITY(1,1) PRIMARY KEY" +
         ", Surname VarChar(30) not null," +
         "  Name VarChar(30) not null," +
         "  Patronymic VarChar(30))", conn))
            {
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

            using (SqlCommand cmdCreateTable = new SqlCommand("CREATE TABLE " +
         " Books (BookID int IDENTITY(1,1) PRIMARY KEY" +
         ", Name VarChar(30) not null," +
         "  GenreID int FOREIGN KEY REFERENCES Genres(GenreID)," +
         "  AutorID int FOREIGN KEY REFERENCES Autors(AutorID)," +
         "  Year int not null," +
         "  PublishID int FOREIGN KEY REFERENCES Publishs(PublishID)," +
         "  Price int not null," +
         "  Count int not null)", conn))
            {
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

            // LAST
            //SqlConnection connection = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            //connection.Open();

            //var selectBooks = "SELECT * FROM Books";
            //using (SqlDataAdapter dataAdapter = new SqlDataAdapter(
            //selectBooks, connection))
            //{
            //    DataTable dt = new DataTable();
            //    dataAdapter.Fill(dt);

            //    dataGridView1.DataSource = dt.DefaultView;
            //}
            //connection.Close();

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
                    connection.Close();
                    connection = new SqlConnection(@"Data Source=LAPTOP-8BSFAANR\SQLEXPRESS;Integrated Security=True");
                    SqlCommand cmdCreateDataBase = new SqlCommand(string.Format("CREATE DATABASE [{0}]", "BookShop"), connection);
                    connection.Open();
                    cmdCreateDataBase.ExecuteNonQuery();
                    connection.Close();
                    Thread.Sleep(10000);

                    SqlConnection connection2 = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
                    CreateNewTable(connection2);
                    InsertToTable(connection2, "start");

                    connection = new SqlConnection(connStr);
                    connection.Open();
                }
            }
            finally
            {
                Console.WriteLine("Соедение успешно произведено");
                connection.Close();
                //connection.Dispose();
            }

            //connection.Open();

            //connection = new SqlConnection(@"Data Source=LAPTOP-8BSFAANR\SQLEXPRESS;Integrated Security=True");

            //connection.Open();

            //CreateNewTable(connection);

            //connection.Close();

            //var selectBooks = "SELECT * FROM Books";
            //using (SqlDataAdapter dataAdapter = new SqlDataAdapter(
            //selectBooks, connection))
            //{
            //    DataTable dt = new DataTable();
            //    dataAdapter.Fill(dt);

            //    dataGridView1.DataSource = dt.DefaultView;
            //}
            //connection.Close();

        }
    // TODO: данная строка кода позволяет загрузить данные в таблицу "bookShopDataSet.Книги". При необходимости она может быть перемещена или удалена.
    //this.книгиTableAdapter.Fill(this.bookShopDataSet.Книги);


    //private void EnterDataButton_Click(object sender, EventArgs e)
    //    {
    //        if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "" && textBox3.Text.ToString() != "" && textBox4.Text.ToString() != "" && textBox5.Text.ToString() != "" && textBox6.Text.ToString() != "")
    //        {   

    //            SqlConnection connection = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
    //            connection.Open();

    //            SqlCommand cmd = new SqlCommand("INSERT INTO " +
    //        "Books (название,автор,издательство,жанр,дата_выхода,цена) " +
    //        "VALUES (@название,@автор,@издательство,@жанр,@дата_выхода,@цена)", connection);


    //            cmd.Parameters.AddWithValue("@название", textBox1.Text);
    //            cmd.Parameters.AddWithValue("@автор", textBox2.Text);
    //            cmd.Parameters.AddWithValue("@издательство", textBox3.Text);
    //            cmd.Parameters.AddWithValue("@жанр", textBox4.Text);
    //            cmd.Parameters.AddWithValue("@дата_выхода", textBox5.Text);
    //            cmd.Parameters.AddWithValue("@цена", textBox6.Text);


    //            try //Как проверить на ошибки?
    //            {
    //                //cmd.ExecuteNonQuery();
    //                MessageBox.Show("Данные успешно добавлены!", "Запрос выполнен", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //            }
    //            catch (Exception se)
    //            {
    //                MessageBox.Show("Ошибка, при выполнении запроса на добавление записи " + se.Message + "", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                return;
    //            }

    //            connection.Close();
    //            connection.Dispose();
    //        }
    //        else
    //        {
    //            MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }

        private void OutDataButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            connection.Open();

            var selectBooks = "SELECT * FROM Books";
            //var selectBooks = "SELECT Name as Название, CONCAT (Surname, Left (Name,1), Left (Patronymic,1)) AS Автор, Price as Цена FROM Books";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(
            selectBooks, connection))
            {
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
            }
            connection.Close();
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
                string getP = "SELECT Password, Level FROM Users where Name = @Name";

                SqlCommand commandBrands = new SqlCommand(getP, conn);

                commandBrands.Parameters.AddWithValue("@Name", Name);

                using (SqlDataReader reader = commandBrands.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pass = reader["Password"].ToString();
                        Level = reader["Level"].ToString();
                    }
                }
                if (pass == textBoxPass.Text.ToString())
                {
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
                }
                else MessageBox.Show("Что-то введено не так!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conn.Close();
        }

        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            conn.Open();
            if (textBoxLogin.Text.ToString() != "" && textBoxPass.Text.ToString() != "")
            using (SqlCommand cmd = new SqlCommand("Insert into Users" +
                "(Name,Password,Level) Values (@Name,@Password,@Level)", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = textBoxLogin.Text.ToString(); param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Password"; param.Value = textBoxPass.Text.ToString(); param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Level"; param.Value = 0; param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                Console.WriteLine("Вставляем запись");
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Ошибка, при выполнении запроса на добавление записи");
                    return;
                }
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            AddForm form2 = new AddForm();
            form2.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            //conn.Open();
            //using (SqlCommand cmd = new SqlCommand("Update Students" +
            //       " Set ID = @ID where FIO = @FIO", conn))
            //{
            //    SqlParameter param = new SqlParameter();
            //    param.ParameterName = "@ID";
            //    param.Value = dataGridView1.CurrentCell.RowIndex;
            //    param.SqlDbType = SqlDbType.Int;
            //    cmd.Parameters.Add(param);
            //    param = new SqlParameter();
            //    param.ParameterName = "@FIO";
            //    param.Value = "Иванов Иван";
            //    param.SqlDbType = SqlDbType.Text;
            //    cmd.Parameters.Add(param);

            //    Console.WriteLine("Изменяем запись(и)");
            //    {
            //        try
            //        {
            //            cmd.ExecuteNonQuery();
            //        }
            //        catch
            //        {
            //            Console.WriteLine("Ошибка, при выполнении запроса на изменение записи(ей)");

            //            return;
            //        }
            //    }
            //}

            EditForm editForm = new EditForm();
            editForm.ShowDialog();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("Delete From Books" +
                 " where BookID = @BookID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@BookID";
                param.Value = dataGridView1.CurrentCell.RowIndex; //Обработать
                MessageBox.Show(param.Value.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                Console.WriteLine("Удаляем запись");
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Ошибка, при выполнении запроса на удаление записи");
                    Console.WriteLine("Возможно запись уже удалена");
                    return;
                }
            }
            conn.Close();
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            //param.Value = dataGridView1.CurrentCell.RowIndex;
        }
    }
}
