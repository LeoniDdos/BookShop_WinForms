using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class AddForm : Form
    {
        SqlConnection conn;
        public AddForm(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void DataRefresh()
        {
            //SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            conn.Open();
            SqlCommand sc = new SqlCommand("SELECT GenreID, Name FROM Genres", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("GenreID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Load(reader);

            comboBoxBooksGenre.ValueMember = "GenreID";
            comboBoxBooksGenre.DisplayMember = "Name";
            comboBoxBooksGenre.DataSource = dt;

            SqlCommand sc2 = new SqlCommand("SELECT AutorID, CONCAT (Autors.Surname, ' ', Left (Autors.Name,1), '. ', Left (Autors.Patronymic,1), '.') AS FIO FROM Autors", conn);
            SqlDataReader reader2;

            reader2 = sc2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("AutorID", typeof(string));
            dt2.Columns.Add("FIO", typeof(string));
            dt2.Load(reader2);

            comboBoxBooksAutor.ValueMember = "AutorID";
            comboBoxBooksAutor.DisplayMember = "FIO";
            comboBoxBooksAutor.DataSource = dt2;

            SqlCommand sc3 = new SqlCommand("SELECT PublishID, Name FROM Publishs", conn);
            SqlDataReader reader3;

            reader3 = sc3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("PublishID", typeof(string));
            dt3.Columns.Add("Name", typeof(string));
            dt3.Load(reader3);

            comboBoxBooksPublish.ValueMember = "PublishID";
            comboBoxBooksPublish.DisplayMember = "Name";
            comboBoxBooksPublish.DataSource = dt3;

            conn.Close();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            DataRefresh();
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            if (textBoxBooksName.Text.ToString() != "" && textBoxBooksYear.Text.ToString() != "" && textBoxBooksPrice.Text.ToString() != "" && textBoxBooksCount.Text.ToString() != "")
            {
                //SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
               
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into Books" +
                            "(Name,GenreID,AutorID,Year,PublishID,Price,Count) Values (@Name,@GenreID,@AutorID,@Year,@PublishID,@Price,@Count)", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Name"; param.Value = textBoxBooksName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@GenreID"; param.Value = comboBoxBooksGenre.SelectedIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@AutorID"; param.Value = comboBoxBooksAutor.SelectedIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@Year"; param.Value = Convert.ToInt32(textBoxBooksYear.Text); param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@PublishID"; param.Value = comboBoxBooksPublish.SelectedIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@Price"; param.Value = Convert.ToInt32(textBoxBooksPrice.Text); param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@Count"; param.Value = Convert.ToInt32(textBoxBooksCount.Text); param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    
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

                MessageBox.Show("Данные успешно введены", "Ввод", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();

                textBoxBooksName.Text = "";
                textBoxBooksYear.Text = "";
                textBoxBooksPrice.Text = "";
                textBoxBooksCount.Text = "";
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAddAutor_Click(object sender, EventArgs e)
        {
            if (textBoxAutorsSurname.Text.ToString() != "" && textBoxAutorsName.Text.ToString() != "" && textBoxAutorsPatronymic.Text.ToString() != "")
            {
                //SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into Autors" +
                            "(Surname,Name,Patronymic) Values (@Surname,@Name,@Patronymic)", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Surname"; param.Value = textBoxAutorsSurname.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@Name"; param.Value = textBoxAutorsName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                    param = new SqlParameter();
                    param.ParameterName = "@Patronymic"; param.Value = textBoxAutorsPatronymic.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
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
                MessageBox.Show("Данные успешно введены", "Ввод", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                textBoxAutorsSurname.Text = "";
                textBoxAutorsName.Text = "";
                textBoxAutorsPatronymic.Text = "";
                DataRefresh();
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAddGenre_Click(object sender, EventArgs e)
        {
            if (textBoxGenresName.Text.ToString() != "")
            {
                //SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into Genres" +
                            "(Name) Values (@Name)", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Name"; param.Value = textBoxGenresName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
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
                MessageBox.Show("Данные успешно введены", "Ввод", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                textBoxGenresName.Text = "";
                DataRefresh();
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAddPublish_Click(object sender, EventArgs e)
        {
            if (textBoxPublishsName.Text.ToString() != "")
            {
                //SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into Publishs" +
                            "(Name) Values (@Name)", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@Name"; param.Value = textBoxPublishsName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
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
                MessageBox.Show("Данные успешно введены", "Ввод", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                textBoxPublishsName.Text = "";
                DataRefresh();
            }
            else MessageBox.Show("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxBooksYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxBooksPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxBooksCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}