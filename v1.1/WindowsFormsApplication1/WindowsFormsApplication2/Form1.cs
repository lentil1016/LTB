using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace WindowsFormsApplication16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        int times;
        private void ExecWaitForm()
        {
            try
            {
                WaitFormService.Show();



                times++;

                for (int i = 0; i < 10000; i++)
                {
                    WaitFormService.SetText(times.ToString() + "正在执行 ，请耐心等待...." + i.ToString());

                }

                WaitFormService.Close();
                if (times == 3)
                {
                    button1.Enabled = true;
                    return;
                }
                ExecWaitForm();


            }
            catch (Exception ex)
            {
                WaitFormService.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormA mForm = new FormA();
            mForm.TopLevel = false;
            mForm.FormBorderStyle = FormBorderStyle.None;
            this.panel.Controls.Add(mForm);
            times = 0;
            Thread th = new Thread(new ThreadStart(this.ExecWaitForm));
            th.Start();
            button1.Enabled = false;
        }

    }
}
