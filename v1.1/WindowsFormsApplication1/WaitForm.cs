using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication16
{
    public partial class WaitForm : Form
    {
        private Label label1;

        public WaitForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetText("正在执行，请耐心等待....");
        }

        private delegate void SetTextHandler(string text);
        public void SetText(string text)
        {
            if (this.label1.InvokeRequired)
            {
                this.Invoke(new SetTextHandler(SetText), text);
            }
            else
            {
                this.label1.Text = text;
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // WaitForm
            // 
            this.ClientSize = new System.Drawing.Size(248, 136);
            this.Controls.Add(this.label1);
            this.Name = "WaitForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
