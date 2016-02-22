/*

The MIT License (MIT)
Copyright (c) 2016 Lentil Sun

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

using System;
using System.Windows.Forms;
using Core;

namespace LentilToolbox
{
    public partial class ftrwin : Form
    {
        private int rank;
        private Shaftwin oShaftwin;
        private int B_flat=0;
        private double dBeta;
        public ftrwin(Shaftwin oshaftwin)
        {
            InitializeComponent();
            oShaftwin = oshaftwin;
            ShaftType.Text = "(请选择轴段类型)";
            GearDir.Text = "(请选择旋向)";
            GearType.Text = "(请选择齿轮类型)";
            GearFace.Text = "(请选择锥面朝向)";
        }
        
        public void RefRank(int a)
        {
            rank=a;
            this.FtrHead.Text = "定义轴特征"+(rank+1);
        }
        private void ADD_Click(object sender, EventArgs e)
        {
            oShaftwin.AddAndRefresh(rank+1);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            oShaftwin.DeleteAndRefresh(rank);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(ShaftType.Text != "(请选择轴段类型)")
            {
                values.Visible = true;
                if (ShaftType.Text == "普通轴段")
                {
                    GearType.Visible = false;
                    GearFace.Visible = false;
                    Beta.Visible = false;
                    Alpha.Visible = false;
                    m.Visible = false;
                    chipeihou.Visible = false;
                    slot.Visible = false;
                    GtextBox5.Visible = false;
                    GtextBox4.Visible = false;
                    GtextBox3.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    GearFace.Top = 54;
                    z.Text = "轴段直径";
                    breadth.Text = "轴段宽度";
                    GearDir.Visible = false;
                    values.Height = 75;
                }
                else
                {
                    z.Text = "齿数";
                    Beta.Visible = true;
                    Alpha.Visible = true;
                    m.Visible = true;
                    GtextBox5.Visible = true;
                    GtextBox4.Visible = true;
                    GtextBox3.Visible = true;
                    breadth.Text = "齿宽";
                    values.Height = 150;
                    if (ShaftType.Text == "圆柱直/斜齿轮")
                    {
                        chipeihou.Visible = false;
                        GearType.Visible = true;
                        GearFace.Visible = false;
                        GearFace.Top = 54;
                        textBox1.Visible = false;
                        Beta.Text = "螺旋角";
                        slot.Visible = false;
                        textBox2.Visible = false;
                        values.Visible = false;
                    }
                    else
                    {
                        GearFace.Visible = true;
                        GearType.Visible = false;
                        GearFace.Top = 22;
                        textBox1.Visible = true;
                        chipeihou.Visible = true;
                        Beta.Text = "分锥角";
                        slot.Visible = true;
                        textBox2.Visible = true;
                        GearDir.Visible = false;
                    }
                }
            }
            else
            {
                values.Visible = false;
                GearDir.Visible = false;
                GearFace.Visible = false;
                GearType.Visible = false;
            }
        }

        private void GearType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GearType.Text!="(请选择齿轮类型)")
            {
                if (GearType.Text == "斜齿轮")
                {
                    GearDir.Visible = true;
                    Beta.Visible = true;
                    GtextBox5.Visible = true;
                    values.Height = 150;
                }
                else
                {
                    Beta.Visible = false;
                    GtextBox5.Visible = false;
                    values.Height = 125;
                }
                values.Visible = true;

            }
            else
            {
                values.Visible = false;
                GearDir.Visible = false;
            }
        }
        public double modeling(double Height,iPartDoc oiPartDoc)
        {
            double B;
            if (ShaftType.Text!= "(请选择轴段类型)")
            {
                if(ShaftType.Text == "普通轴段")//普通轴段
                {
                    B = Convert.ToDouble(this.GtextBox1.Text);
                    shaft_section oshaft_section = new shaft_section();
                    oshaft_section.SetValues(B, Convert.ToDouble(GtextBox2.Text));
                    oshaft_section.modeling(Height, oiPartDoc);
                }
                else if (ShaftType.Text== "圆柱直/斜齿轮")//圆柱齿轮
                {
                    if (GearType.Text == "斜齿轮")
                        dBeta = Convert.ToDouble(GtextBox5.Text);
                    else
                        dBeta = 0;
                    B = Convert.ToDouble(this.GtextBox1.Text);
                    cyl_gear ocyl_gear = new cyl_gear();
                    ocyl_gear.SetValues(B, Convert.ToInt32(GtextBox2.Text),Convert.ToInt32(GtextBox3.Text),Convert.ToDouble(GtextBox4.Text),dBeta, B_flat);
                    ocyl_gear.modeling(Height, oiPartDoc);
                }
                else//圆锥齿轮
                {
                    bool Dir;
                    B = Convert.ToDouble(this.textBox1.Text)-Convert.ToDouble(this.textBox2.Text);
                    bev_gear obev_gear = new bev_gear();
                    if (GearFace.Text == "(请选择锥面朝向)")
                    {
                        MessageBox.Show("未选择锥面朝向");
                        return -1;
                    }
                    else if (GearFace.Text == "向左")
                        Dir = true ;
                    else
                        Dir = false ;
                    obev_gear.SetValues(Convert.ToDouble(this.textBox1.Text), Convert.ToDouble(this.GtextBox1.Text), Convert.ToDouble(this.textBox2.Text), Convert.ToInt32(GtextBox2.Text), Convert.ToInt32(GtextBox3.Text), Convert.ToDouble(GtextBox4.Text), Convert.ToDouble(GtextBox5.Text),Dir);
                    obev_gear.modeling(Height, oiPartDoc);
                }
            }
            else
            {
                return -1;
            }
            return B;
        }

        private void GearDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GearDir.Text == "(请选择旋向)")
                B_flat = 0;
            else if (GearDir.Text == "左旋")
                B_flat = 1;
            else
                B_flat = 2;
        }

        private void GearFace_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
