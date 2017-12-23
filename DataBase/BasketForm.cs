using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class BasketForm : Form
    {
        int userID;
        int fullPrice = 0;
        string login;
        SqlConnection conn;

        public BasketForm(int userID, string login, SqlConnection conn)
        {
            InitializeComponent();
            this.userID = userID;
            this.login = login;
            this.conn = conn;
        }

        public void refreshData()
        {
            conn.Open();

            SqlCommand sc = new SqlCommand("SELECT Books.BookID as ID, Books.Name as Название, Books.Price as Стоимость FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID", conn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@UserID"; param.Value = userID; param.SqlDbType = SqlDbType.Int; sc.Parameters.Add(param);

            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            dataGridViewBasket.DataSource = dt;

            conn.Close();

            DataGridViewColumn column = dataGridViewBasket.Columns[0];
            column.Width = 25;
        }

        public void refreshLabel()
        {
            conn.Open();

            using (SqlCommand sqlout = new SqlCommand("SELECT SUM(Books.Price) FROM Baskets INNER JOIN Books ON Books.BookID = Baskets.BookID WHERE Baskets.UserID = @UserID", conn))
            {
                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@UserID"; param2.Value = userID; param2.SqlDbType = SqlDbType.Int; sqlout.Parameters.Add(param2);

                try
                {
                    sqlout.ExecuteNonQuery();
                    fullPrice = (int)sqlout.ExecuteScalar();
                }
                catch (Exception se)
                {
                    Console.WriteLine("Ошибка подключения: {0}", se.Message);
                    conn.Close();
                    return;
                } 
                
                labelFullPrice.Text = "Полная стоимость: " + fullPrice.ToString();
            }
            conn.Close();
        }

        private void BasketForm_Load(object sender, EventArgs e)
        {
            refreshData();
            refreshLabel();
        }

        private void buttonRemoveBook_Click(object sender, EventArgs e)
        {
            conn.Open();

            if (dataGridViewBasket.Rows.Count > 1)
                using (SqlCommand cmd = new SqlCommand("DELETE TOP (1) FROM Baskets" +
                      " WHERE UserID = @UserID AND BookID = @BookID; UPDATE Books" +
                       " SET Count = Count + 1 WHERE BookID = @BookID", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@UserID"; param.Value = userID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
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
                        conn.Close();
                        return;
                    }
                }
            else MessageBox.Show("В корзине нет книг", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conn.Close();

            refreshData();
            refreshLabel();
        }

        private void buttonBuyBooks_Click(object sender, EventArgs e)
        {
            if (dataGridViewBasket.Rows.Count > 1)
            {
                saveToFile();

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Baskets WHERE UserID = @UserID", conn))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@UserID"; param.Value = userID; param.SqlDbType = SqlDbType.Int; cmd.Parameters.Add(param);
                    
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
                CheckForm checkForm = new CheckForm(userID, login, fullPrice, dataGridViewBasket.Rows.Count - 1);
                checkForm.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("В корзине нет книг", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void saveToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Check.txt");
                DateTime thisDay = DateTime.Today;
                
                sw.WriteLine("====BookShop====");
                sw.WriteLine("Дата: " + thisDay.Day + "." + thisDay.Month + "." + thisDay.Year);
                sw.WriteLine("______ЧЕК______");
                foreach (DataGridViewRow row in dataGridViewBasket.Rows)
                {
                    sw.WriteLine(dataGridViewBasket[1, row.Index].Value + " - " + dataGridViewBasket[2, row.Index].Value);
                }
                sw.WriteLine("Сумма: " + fullPrice + " руб.");

                sw.Close();
            }
            catch (Exception ef)
            {
                Console.WriteLine("Ошибка: " + ef.Message);
            }
            finally
            {
                Console.WriteLine("Чек успешно сохранен");
            }
        }
    }
}