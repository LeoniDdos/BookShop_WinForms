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
    public partial class EditForm : Form
    {
        int bookID;
        SqlConnection conn;

        public EditForm(int BookID, SqlConnection conn)
        {
            InitializeComponent();
            this.bookID = BookID;
            this.conn = conn;
        }

        private void dataRefresh()
        {
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

            SqlCommand sc4 = new SqlCommand("SELECT Name, GenreID, AutorID, Year, PublishID, Price, Count FROM Books WHERE BookID = @BookID", conn);

            sc4.Parameters.AddWithValue("@BookID", bookID);

            using (SqlDataReader reader4 = sc4.ExecuteReader())
            {
                while (reader4.Read())
                {
                    textBoxBooksName.Text = reader4["Name"].ToString();
                    textBoxBooksYear.Text = reader4["Year"].ToString();
                    textBoxBooksPrice.Text = reader4["Price"].ToString();
                    textBoxBooksCount.Text = reader4["Count"].ToString();
                    
                    comboBoxBooksGenre.SelectedIndex = Convert.ToInt32(reader4["GenreID"]) - 1;
                    comboBoxBooksAutor.SelectedIndex = Convert.ToInt32(reader4["AutorID"]) - 1;
                    comboBoxBooksPublish.SelectedIndex = Convert.ToInt32(reader4["PublishID"]) - 1;
                }
            }

            SqlCommand sc5 = new SqlCommand("SELECT AutorID, CONCAT (Autors.Surname, ' ', Left (Autors.Name,1), '. ', Left (Autors.Patronymic,1), '.') AS FIO FROM Autors", conn);
            SqlDataReader reader5;

            reader5 = sc5.ExecuteReader();
            DataTable dt5 = new DataTable();
            dt5.Columns.Add("GenreID", typeof(string));
            dt5.Columns.Add("Name", typeof(string));
            dt5.Load(reader5);

            comboBoxEditAutor.ValueMember = "AutorID";
            comboBoxEditAutor.DisplayMember = "FIO";
            comboBoxEditAutor.DataSource = dt5;

            SqlCommand sc6 = new SqlCommand("SELECT GenreID, Name FROM Genres", conn);
            SqlDataReader reader6;

            reader6 = sc6.ExecuteReader();
            DataTable dt6 = new DataTable();
            dt6.Columns.Add("GenreID", typeof(string));
            dt6.Columns.Add("Name", typeof(string));
            dt6.Load(reader6);

            comboBoxEditGenre.ValueMember = "GenreID";
            comboBoxEditGenre.DisplayMember = "Name";
            comboBoxEditGenre.DataSource = dt6;

            SqlCommand sc7 = new SqlCommand("SELECT PublishID, Name FROM Publishs", conn);
            SqlDataReader reader7;

            reader7 = sc7.ExecuteReader();
            DataTable dt7 = new DataTable();
            dt7.Columns.Add("PublishID", typeof(string));
            dt7.Columns.Add("Name", typeof(string));
            dt7.Load(reader7);

            comboBoxEditPublish.ValueMember = "PublishID";
            comboBoxEditPublish.DisplayMember = "Name";
            comboBoxEditPublish.DataSource = dt7;

            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataRefresh();   
        }

        private void buttonEditBook_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("sp_EditBook", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                param = new SqlParameter();
                param.ParameterName = "@BookID"; param.Value = bookID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                
                Console.WriteLine("Изменяем запись");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные успешно изменены", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка: {0}", se.Message);
                        conn.Close();
                        return;
                    }
                }
            }
            conn.Close();
            Close();
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

        private void buttonEditAutor_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("sp_EditAutor", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = textBoxAutorsName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Surname"; param.Value = textBoxAutorsSurname.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Patronymic"; param.Value = textBoxAutorsPatronymic.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@AutorID"; param.Value = comboBoxEditAutor.SelectedIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                
                Console.WriteLine("Изменяем запись");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные успешно изменены", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка: {0}", se.Message);
                        conn.Close();
                        return;
                    }
                }
            }
            conn.Close();
            Close();
        }

        private void buttonEditGenre_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("sp_EditGenre", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();

                param.ParameterName = "@Name"; param.Value = textBoxGenresName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@GenreID"; param.Value = comboBoxEditGenre.SelectedIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                Console.WriteLine("Изменяем запись");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные успешно изменены", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка: {0}", se.Message);
                        conn.Close();
                        return;
                    }
                }
            }
            conn.Close();
            Close();
        }

        private void buttonEditPublish_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("sp_EditPublish", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = textBoxPublishsName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@PublishID"; param.Value = comboBoxEditPublish.SelectedIndex + 1; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                Console.WriteLine("Изменяем запись");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные успешно изменены", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine("Ошибка: {0}", se.Message);
                        conn.Close();
                        return;
                    }
                }
            }
            conn.Close();
            Close();
        }
    }
}