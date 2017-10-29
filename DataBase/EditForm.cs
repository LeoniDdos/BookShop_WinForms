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
        int BookID;
        SqlConnection conn;

        public EditForm(int BookID, SqlConnection conn)
        {
            InitializeComponent();
            this.BookID = BookID;
            this.conn = conn;
        }

        private void DataRefresh()
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

            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataRefresh();   
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("UPDATE Books" +
                   " SET Name = @Name, GenreID = @GenreID, AutorID = @AutorID, Year = @Year, PublishID = @PublishID, Price = @Price, Count = @Count WHERE BookID = @BookID", conn))
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
                param = new SqlParameter();
                param.ParameterName = "@BookID"; param.Value = BookID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                
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

        private void buttonAddAutor_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("UPDATE Autors" +
                   " SET Name = @Name, Surname = @Surname, Patronymic = @Patronymic WHERE AutorID = @AutorID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = textBoxAutorsName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Surname"; param.Value = textBoxAutorsSurname.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@Patronymic"; param.Value = textBoxAutorsPatronymic.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@AutorID"; param.Value = textBoxAutorID.Text.ToString(); param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                
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

        private void buttonAddGenre_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("UPDATE Genres SET Name = @Name WHERE GenreID = @GenreID", conn))
            {
                SqlParameter param = new SqlParameter();

                param.ParameterName = "@Name"; param.Value = textBoxGenresName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@GenreID"; param.Value = textBoxGenreID.Text.ToString(); param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

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

        private void buttonAddPublish_Click(object sender, EventArgs e)
        {
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("UPDATE Publishs SET Name = @Name WHERE PublishID = @PublishID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Name"; param.Value = textBoxPublishsName.Text.ToString(); param.SqlDbType = SqlDbType.VarChar; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@PublishID"; param.Value = textBoxPublishID.Text.ToString(); param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

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

        private void textBoxAutorID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxGenreID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBoxPublishID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}