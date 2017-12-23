using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class CheckForm : Form
    {
        int userID;
        string login;
        int fullPrice;
        int bookCount;
        DateTime thisDay = DateTime.Today;

        private string documentContents;
        private string stringToPrint;

        public CheckForm(int UserID, string Login, int FullPrice, int BookCount)
        {
            InitializeComponent();
            this.userID = UserID;
            this.fullPrice = FullPrice;
            this.bookCount = BookCount;
            this.login = Login;
        }

        private void ReadDocument()
        {
            string docName = "Check.txt";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }

        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);
            stringToPrint = stringToPrint.Substring(charactersOnPage);
            e.HasMorePages = (stringToPrint.Length > 0);
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }

        private void CheckForm_Load(object sender, EventArgs e)
        {
            labelLogin.Text = labelLogin.Text + login;
            labelBookCount.Text = labelBookCount.Text + bookCount;
            labelFullPrice.Text = labelFullPrice.Text + fullPrice;
            labelDate.Text = labelDate.Text + " " + thisDay.ToString("d");
        }

        private void buttonPrintCheck_Click(object sender, EventArgs e)
        {
            ReadDocument();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}