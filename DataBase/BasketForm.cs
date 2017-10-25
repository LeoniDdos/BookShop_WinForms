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
    public partial class BasketForm : Form
    {
        int UserID;
        public BasketForm(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        public void RefreshData()
        {
            SqlConnection connection = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            connection.Open();

            //var selectBooks = "SELECT Books.Name as Название, Books.Price as Стоимость FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID";

            SqlCommand sc = new SqlCommand("SELECT Books.BookID as ID, Books.Name as Название, Books.Price as Стоимость FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID", connection);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID"; param.Value = UserID; param.SqlDbType = SqlDbType.Int; sc.Parameters.Add(param);

            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            //dataGridViewBasket.ValueMember = "GenreID";
            //dataGridViewBasket.DisplayMember = "Name";
            dataGridViewBasket.DataSource = dt;

            connection.Close();

            DataGridViewColumn column = dataGridViewBasket.Columns[0];
            column.Width = 25;
        }

        public void RefreshLabel()
        {
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");
            
            conn.Open();
            using (SqlCommand sqlout = new SqlCommand("SELECT SUM(Books.Price) FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID", conn))
            {
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@UserID"; param2.Value = UserID; param2.SqlDbType = SqlDbType.Int; sqlout.Parameters.Add(param2);

                try
                {
                    sqlout.ExecuteNonQuery();
                }
                catch (Exception se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    return;
                }

                int FullPrice = 0;

                FullPrice = (int)sqlout.ExecuteScalar();

                labelFullPrice.Text = "Полная стоимость: " + FullPrice.ToString();
            }
            conn.Close();
        }

        private void BasketForm_Load(object sender, EventArgs e)
        {
            RefreshData();
            RefreshLabel();
        }

        private void buttonRemoveBook_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Server=LAPTOP-8BSFAANR\SQLEXPRESS;Database=BookShop;Trusted_Connection=Yes;");

            conn.Open();

            using (SqlCommand cmd = new SqlCommand("DELETE TOP (1) FROM Baskets" +
                  " WHERE UserID = @UserID AND BookID = @BookID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@UserID"; param.Value = UserID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@BookID"; param.Value = dataGridViewBasket[0, dataGridViewBasket.CurrentCell.RowIndex].Value; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);

                Console.WriteLine("Удаляем запись");
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
            conn.Close();

            RefreshData();
            RefreshLabel();
        }
    }
}
