using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    //проверить наличие строк в баскете и запретить изменение размеров экрана
    public partial class CheckForm : Form
    {
        int UserID;
        string Login;
        int FullPrice;
        int BookCount;

        public CheckForm(int UserID, string Login, int FullPrice, int BookCount)
        {
            InitializeComponent();
            this.UserID = UserID;
            this.FullPrice = FullPrice;
            this.BookCount = BookCount;
            this.Login = Login;
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
               System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void CheckForm_Load(object sender, EventArgs e)
        {
            labelLogin.Text = labelLogin.Text + Login;
            labelBookCount.Text = labelBookCount.Text + BookCount;
            labelFullPrice.Text = labelFullPrice.Text + FullPrice;
        }

        private void buttonPrintCheck_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }
    }
}