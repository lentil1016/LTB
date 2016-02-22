using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using INFITF;
using MECMOD;


namespace testcsharp
{
    public partial class Form1 : Form
    {
        private ShowAllPage head;
        private ShowAllPage sAllPage;
        public bool refresh()
        {
            sAllPage.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(sAllPage);
            sAllPage.Show();
            sAllPage.Left = 100;
            return false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            head = new ShowAllPage();
            //sAllPage.FormBorderStyle = FormBorderStyle.None;
            //sAllPage.Dock = DockStyle.Fill;
            head.TopLevel = false;
            sAllPage= head.addftr();
            refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
