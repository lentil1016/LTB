/*

The MIT License (MIT)
Copyright (c) 2016 Lentil Sun

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/


using System.Collections.Generic;
using System.Windows.Forms;
using Core;

namespace LentilToolbox
{
    public partial class Shaftwin : Form
    {
        private List<ftrwin> Ftrlist;//轴段特征窗口的list
        public Shaftwin()
        {
            InitializeComponent();
            hScrollBar1.BringToFront();
            Ftrlist = new List<ftrwin>();
            AddAndRefresh(0);
        }

        public bool AddAndRefresh(int position)
        {
            Ftrlist.Insert(position,new ftrwin(this));
            Ftrlist[position].TopLevel = false;
            ListShower.Controls.Add(Ftrlist[position]);
            Ftrlist[position].Show();//显示新插入的轴段窗口
            int a = Ftrlist.Count, i;
            ListShower.Width = a * 350;//调整容器宽度
            rewin();//根据总窗口和容器宽度1q24调整滚动条大小
            for (i=position;i<a;++i)
            {
                Ftrlist[i].RefRank(i);
                Ftrlist[i].Left = i * 350;
            }//更新各“第n段轴段”中的代号n及显示位置

            return true;
        }

        public bool DeleteAndRefresh(int position)
        {
            Ftrlist[position+1].Visible = false;
            Ftrlist.RemoveAt(position+1);//删除一项轴特征
            int a = Ftrlist.Count, i;
            ListShower.Width = a * 350;//调整容器宽度
            rewin();//根据总窗口和容器宽度调整滚动条大小
            for (i = position; i < a; ++i)
            {
                Ftrlist[i].RefRank(i);
                Ftrlist[i].Left = i * 350;
            }//更新各“第n段轴段”中的代号n及显示位置
            return true;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            ListShower.Left = -hScrollBar1.Value;
        }

        private void rewin()
        {
            if (Ftrlist.Count * 350 > splitContainer1.Width)
            {
                hScrollBar1.Visible = true;
                hScrollBar1.Maximum = ListShower.Width;
                hScrollBar1.Minimum = 0;
                hScrollBar1.LargeChange =splitContainer1.Panel1.Width;
            }
            else
            {
                hScrollBar1.Visible = false;
            }
        }

        private void Shaftwin_SizeChanged(object sender, System.EventArgs e)
        {
            rewin();
        }

        public void regraph()
        {
            preview.refresh(Ftrlist);
        }

        //----------------生成零件阶段------------------------
        private void Generate_Click(object sender, System.EventArgs e)
        {
            this.Generate.IsAccessible = false;
            int a = Ftrlist.Count, i=0;
            iPartDoc oiPartDoc=new iPartDoc();//生成零件实例
            double H = 0.0, H1 = 0.0;
            for (;i< a;i++)
            {
                H1 = Ftrlist[i].modeling(H, oiPartDoc);
                if(H1<0)
                {
                    MessageBox.Show ("第"+(i+1)+"项轴特征未定义");
                    break;
                }
                else
                {
                    H += H1;
                }
            }
        }

        private void ListShower_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
