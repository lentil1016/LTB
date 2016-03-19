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
            Ftrlist = new List<ftrwin>();//初始化特征窗口容器对象
            InitializeComponent();//各控件对象初始化
            preview.initialize(Ftrlist);
            AddAndRefresh(0);//向特征窗口容器添加第一个特征窗口对象
            hScrollBar1.BringToFront();
            preview.Width = this.Width;
        }

        public bool AddAndRefresh(int position)
        {
            Ftrlist.Insert(position,new ftrwin(this));
            Ftrlist[position].initialize();
            Ftrlist[position].TopLevel = false;
            ListShower.Controls.Add(Ftrlist[position]);
            Ftrlist[position].Show();//显示新插入的轴段窗口
            int a = Ftrlist.Count, i;
            ListShower.Width = a * Ftrlist[0].Width;//调整容器宽度
            rescroll();//根据总窗口和容器宽度调整滚动条大小
            for (i=position;i<a;++i)
            {
                Ftrlist[i].RefRank(i);
                Ftrlist[i].Left = i * Ftrlist[0].Width;
            }//更新各“第n段轴段”中的代号n及显示位置
            return true;
        }//在position处增加新的特征窗口

        public bool DeleteAndRefresh(int position)
        {
            Ftrlist[position+1].Visible = false;
            Ftrlist.RemoveAt(position+1);//删除一项轴特征
            int a = Ftrlist.Count, i;
            ListShower.Width = a * Ftrlist[0].Width;//调整容器宽度
            rescroll();//根据总窗口和容器宽度调整滚动条大小
            regraph();//重新绘图
            for (i = position; i < a; ++i)
            {
                Ftrlist[i].RefRank(i);
                Ftrlist[i].Left = i * Ftrlist[0].Width;
            }//更新各“第n段轴段”中的代号n及显示位置
            return true;
        }//删除第position个特征窗口

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)//控制上拉分割框至一定位置后隐藏preview message
        {
            if (Height - splitContainer1.SplitterDistance > 100)
            {
                previewMSG.Visible = false;
                刷新预览.Visible = true;
                preview.Visible = true;
            }
            else
            {
                previewMSG.Visible = true;
                刷新预览.Visible = false;
                preview.Visible = false;
            }
            if (Height > 300)
                preview.Height = splitContainer1.Panel2.Height ;
            else
                preview.Height = 300;
            regraph();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)//设置拖动条控制特征面板滚动
        {
            ListShower.Left = -hScrollBar1.Value;
        }

        private void Shaftwin_SizeChanged(object sender, System.EventArgs e)//总窗口大小改变时调用
        {
            rescroll();
            preview.Width = this.Width;
            regraph();
        }

        private void rescroll()//根据总窗口大小和特征容器大小重新调整拖动条
        {
            if (Ftrlist.Count * 350 > splitContainer1.Width)
            {
                hScrollBar1.Visible = true;
                hScrollBar1.Maximum = ListShower.Width;
                hScrollBar1.Minimum = 0;
                hScrollBar1.LargeChange = splitContainer1.Panel1.Width;
            }
            else
            {
                hScrollBar1.Visible = false;
            }
        }

        public void regraph()//重新绘制预览，窗口改变大小或增减特征窗口时被调用
        {
            if (Ftrlist.Count != 0)
                preview.refresh();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            regraph();
        }
        //----------------生成零件阶段------------------------
        private void Generate_Click(object sender, System.EventArgs e)
        {
            this.Generate.Enabled = false;
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
            this.Generate.Enabled = true;
        }

    }
}
