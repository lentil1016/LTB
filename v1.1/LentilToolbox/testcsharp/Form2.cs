using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testcsharp
{
    public partial class ShowAllPage : Form
    {
        private ShowAllPage nextftr;
        public ShowAllPage addftr()
        {
            nextftr = new ShowAllPage(nextftr);
            return nextftr;
        }
        public ShowAllPage()
        {
            nextftr = null;
            InitializeComponent();
        }

        public ShowAllPage(ShowAllPage linkto)
        {
            nextftr = linkto;
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
