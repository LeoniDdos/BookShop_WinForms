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
        public EditForm()
        {
            InitializeComponent();
        }

        private void DataRefresh()
        {
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
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

            SqlCommand sc2 = new SqlCommand("SELECT AutorID, CONCAT (Surname, Left (Name,1), Left (Patronymic,1)) AS FIO FROM Autors", conn);
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
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("Update Students" +
                   " Set Name = @Name, GenreID = @GenreID, AutorID = @AutorID, YearID = @Year, PublishID = @PublishID, Price = @Price, Count = @Count where BookID = @BookID", conn))
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
                param.ParameterName = "@BookID";
                param.Value = Convert.ToInt32(textBox1.Text);
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                Console.WriteLine("Изменяем запись(и)");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка, при выполнении запроса на изменение записи(ей)");

                        return;
                    }
                }
            }
            conn.Close();
        }
    }
}
