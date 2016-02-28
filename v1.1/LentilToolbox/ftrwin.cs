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
using System.Text.RegularExpressions;

namespace LentilToolbox
{
    public partial class ftrwin : Form//轴段特征子窗体
    {
        private int rank;
        public Shaftwin oShaftwin;
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
                if (ShaftType.Text == "普通轴段")
                {
                    Values_Sha.Visible = true;
                    Values_Cyl.Visible = false;
                    Values_Bev.Visible = false;
                    GearType.Visible = false;
                    GearFace.Visible = false;
                    GearFace.Top = 54;
                    GearDir.Visible = false;
                    GearType.Text = "(请选择齿轮类型)";
                }
                else
                {
                    if (ShaftType.Text == "圆柱直/斜齿轮")
                    {
                        Values_Sha.Visible = false;
                        Values_Bev.Visible = false;
                        GearType.Visible = true;
                        GearFace.Visible = false;
                        GearFace.Top = 54;
                    }
                    else
                    {
                        Values_Bev.Visible = true;
                        Values_Sha.Visible = false;
                        Values_Cyl.Visible = false;
                        GearType.Text = "(请选择齿轮类型)";
                        GearFace.Visible = true;
                        GearType.Visible = false;
                        GearFace.Top = 22;
                        轴段宽度.Visible = true;
                        轴段直径.Visible = true;
                        GearDir.Visible = false;
                    }
                }
            }
            else
            {
                GearType.Text = "(请选择齿轮类型)";
                Values_Bev.Visible = false;
                Values_Sha.Visible = false;
                Values_Cyl.Visible = false;
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
                    圆柱齿轮螺旋角.Visible = true;
                    L_Beta .Visible = true;
                    Values_Cyl .Height = 150;
                }
                else
                {
                    圆柱齿轮螺旋角.Visible = false;
                    L_Beta.Visible = false;
                    Values_Cyl.Height = 125;
                    GearDir.Visible = false ;
                }
                Values_Cyl.Visible = true;

            }
            else
            {
                Values_Cyl.Visible = false;
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
                    B = 轴段宽度.consult();
                    shaft_section oshaft_section = new shaft_section();
                    oshaft_section.SetValues(B, 轴段直径.consult());
                    oshaft_section.modeling(Height, oiPartDoc);
                }
                else if (ShaftType.Text== "圆柱直/斜齿轮")//圆柱齿轮
                {
                    if (GearType.Text == "斜齿轮")
                        dBeta = 圆柱齿轮螺旋角.consult();
                    else
                        dBeta = 0;
                    B = 圆柱齿轮齿宽.consult();
                    cyl_gear ocyl_gear = new cyl_gear();
                    ocyl_gear.SetValues(B, 圆柱齿轮齿数 .consult(), 圆柱齿轮模数.consult(), 圆柱齿轮压力角.consult(), dBeta, B_flat);
                    ocyl_gear.modeling(Height, oiPartDoc);
                }
                else//圆锥齿轮
                {
                    bool Dir;
                    B = 齿胚厚.consult() - 齿槽深.consult();
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
                    obev_gear.SetValues(齿胚厚.consult(), 锥齿轮齿宽.consult(), 齿槽深.consult(), 锥齿轮齿数.consult(), 大端模数.consult(), 锥齿轮压力角.consult(),分锥角.consult(), Dir);
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

        private void tSha_B_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
    public class TextBoxPlus:TextBox
    {
        public TextBoxPlus ()
        {
            this.Leave += new System.EventHandler(fTextChanged);
        }
        public void fTextChanged(object sender, EventArgs e)
        {
            Check();
        }
        virtual protected void Check()
        {
        }
    }
    public class TextBoxInt:TextBoxPlus
    {
        private int value;
        override protected void Check()
        {
            if (Regex.IsMatch(Text, @"^\d+$"))
                value = Convert.ToInt32(Text);
            else
                MessageBox.Show(Name + "一般是正整数值，请填写一个正整数");
        }
        public int consult()
        {
            return value;
        }
    }
    public class TextBoxDouble : TextBoxPlus
    {
        private double value=0;
        override protected void Check()
        {
            if (Regex.IsMatch(Text, @"^\d+(\.\d+)?$"))
                value = Convert.ToDouble(Text);
            else
                MessageBox.Show(Name + "一般是正实数值，请填写一个正实数");
        }
        public double consult()
        {
            return value;
        }
    }
}
