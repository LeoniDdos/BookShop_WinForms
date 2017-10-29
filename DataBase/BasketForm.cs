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
        int FullPrice = 0;
        string Login;
        SqlConnection conn;

        public BasketForm(int UserID, string Login, SqlConnection conn)
        {
            InitializeComponent();
            this.UserID = UserID;
            this.Login = Login;
            this.conn = conn;
        }

        public void RefreshData()
        {
            conn.Open();

            SqlCommand sc = new SqlCommand("SELECT Books.BookID as ID, Books.Name as Название, Books.Price as Стоимость FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID"; param.Value = UserID; param.SqlDbType = SqlDbType.Int; sc.Parameters.Add(param);

            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            dataGridViewBasket.DataSource = dt;

            conn.Close();

            DataGridViewColumn column = dataGridViewBasket.Columns[0];
            column.Width = 25;
        }

        public void RefreshLabel()
        {
            conn.Open();

            using (SqlCommand sqlout = new SqlCommand("SELECT SUM(Books.Price) FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID", conn))
            {
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@UserID"; param2.Value = UserID; param2.SqlDbType = SqlDbType.Int; sqlout.Parameters.Add(param2);

                try
                {
                    sqlout.ExecuteNonQuery();
                    FullPrice = (int)sqlout.ExecuteScalar();
                }
                catch (Exception se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    conn.Close();
                    return;
                } 
                
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
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("DELETE TOP (1) FROM Baskets" +
                  " WHERE UserID = @UserID AND BookID = @BookID; UPDATE Books" +
                   " SET Count = Count + 1 WHERE BookID = @BookID", conn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@UserID"; param.Value = UserID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                param = new SqlParameter();
                param.ParameterName = "@BookID"; param.Value = dataGridViewBasket[0, dataGridViewBasket.CurrentCell.RowIndex].Value; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                // Обработать удаление когда ничего нет
                Console.WriteLine("Удаляем запись");
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
            conn.Close();

            RefreshData();
            RefreshLabel();
        }

        private void buttonBuyBooks_Click(object sender, EventArgs e)
        {
            if (dataGridViewBasket.Rows.Count > 1)
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Baskets WHERE UserID = @UserID", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@UserID"; param.Value = UserID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    
                    Console.WriteLine("Удаляем запись");
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
                conn.Close();

                Hide();
                CheckForm checkForm = new CheckForm(UserID, Login, FullPrice, dataGridViewBasket.Rows.Count - 1);
                checkForm.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("В корзине нет книг", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}