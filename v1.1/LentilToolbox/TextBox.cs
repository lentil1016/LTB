using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LentilToolbox
{
    //-------------------派生文本框类----------------------
    //修改后不会影响dB和dd的参数
    public class TextBoxInt: TextBox
    {
        public TextBoxInt()
    {
    }
    private int value = 0;
    public void Check()
    {
        if ((Regex.IsMatch(Text, @"^\d+$")) && (Text != "0"))
        {
            value = Convert.ToInt32(Text);
        }
        else
        {
            MessageBox.Show(Name + "一般是正整数值，请填写一个正整数");
        }
    }
    public int consult()
    {
        Check();
        return value;
    }
}
    public class TextBoxDouble : TextBox
    {
        public TextBoxDouble()
        {
        }
        private double value = 0;
        public void Check()
        {
            if (Regex.IsMatch(Text, @"^\d+(\.\d+)?$"))
            {
                value = Convert.ToDouble(Text);
            }
            else
            {
                MessageBox.Show(Name + "一般是正实数值，请填写一个正实数");
            }
        }
        public double consult()
        {
            Check();
            return value;
        }
    }
    //修改后会影响dB和dd的参数
    public class TextBoxIntFactor : TextBoxInt
    {
        private ftrwin ParentWin;
        public TextBoxIntFactor(ftrwin oftrwin)
        {
            ParentWin = oftrwin;
            this.Leave += new System.EventHandler(IntTextFactorChanged);
        }
        private void IntTextFactorChanged(object sender, EventArgs e)
        {
            ParentWin.refreshdBAnddd();
        }
    }
    public class TextBoxDoubleFactor : TextBoxDouble
    {

        private ftrwin ParentWin;
        public TextBoxDoubleFactor(ftrwin oftrwin)
        {
            ParentWin = oftrwin;
            this.Leave += new System.EventHandler(DoubleTextFactorChanged);
        }
        private void DoubleTextFactorChanged(object sender, EventArgs e)
        {
            ParentWin.refreshdBAnddd();
        }
    }
}
