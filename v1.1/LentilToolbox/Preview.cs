using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace LentilToolbox
{
    public class Preview : Panel
    {
        private List<ftrwin> ftrList;//存放ftrlist对象指针
        private Graphics g;
        private SolidBrush Bluebrush;
        public Preview()
        {
        }
        public void initialize(List<ftrwin> Plist)//初始化上述各变量
        {
            ftrList = Plist;
            g = CreateGraphics();
            Bluebrush = new SolidBrush(Color.Blue);

        }

        private double paint_width = 0;//像素绘图用轴段宽度单位量
        private double paint_diameter = 0;//像素绘图用半径单位量
        private double max_diameter;//所有轴段中的最大直径
        private double max_width;//所有轴段累加的总宽度
        private int Listcount;//ftrlist的元素个数

        public void refresh()//更新上述成员变量，重新绘图函数
        {
            g = CreateGraphics();
            Listcount = ftrList.Count;
            max_diameter = 0;
            max_width = 0;
            List<Rectangle>  Reclist = new List<Rectangle>();
            RecurListor(0, Reclist);//递归计算上述成员变量后创建List<rectangle>，最后将List转换成array
            Rectangle[] RecArray = Reclist.ToArray();//将list转化为array
            g.Clear(BackColor);
            g.FillRectangles(Bluebrush,RecArray);
        }
        public void RecurListor(int Depth,List<Rectangle> RecList)//递归累加，depth为当前层数，Reclist为各个轴段矩形寄存list
        {
            if (Depth < Listcount)
            {
                double temp_width = max_width;//当前深度左端距离
                double temp_diameter = ftrList[Depth].consultd();//当前深度轴径
                max_width += ftrList[Depth].consultB();
                if (max_diameter < temp_diameter)
                    max_diameter = temp_diameter;
                RecurListor(Depth+1, RecList);
                RecList.Add(new Rectangle((int)Math.Floor(temp_width * paint_width)+25, (int)Math.Floor((Height - temp_diameter * paint_diameter) / 2), (int)Math.Ceiling(ftrList[Depth].consultB() * paint_width), (int)Math.Ceiling(temp_diameter * paint_diameter)));
                int position = RecList.Count-1;
                //MessageBox.Show("rectangle" + Depth + "=" + RecList[position].Width + " " + RecList[position].Height+"=" + RecList[position].X + " " + RecList[position].Y);
            }
            else
            {
                paint_diameter = (Height - 50) / max_diameter;
                paint_width = (Width - 50) / max_width;
                //MessageBox.Show("height="+Height+" width="+Width);
            }

        }

    }
}
