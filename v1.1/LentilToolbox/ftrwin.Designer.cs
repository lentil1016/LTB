namespace LentilToolbox
{
    partial class ftrwin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ADD = new System.Windows.Forms.Button();
            this.values = new System.Windows.Forms.GroupBox();
            this.GtextBox1 = new System.Windows.Forms.TextBox();
            this.GtextBox2 = new System.Windows.Forms.TextBox();
            this.GtextBox3 = new System.Windows.Forms.TextBox();
            this.slot = new System.Windows.Forms.Label();
            this.chipeihou = new System.Windows.Forms.Label();
            this.Beta = new System.Windows.Forms.Label();
            this.GtextBox4 = new System.Windows.Forms.TextBox();
            this.Alpha = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GtextBox5 = new System.Windows.Forms.TextBox();
            this.m = new System.Windows.Forms.Label();
            this.breadth = new System.Windows.Forms.Label();
            this.z = new System.Windows.Forms.Label();
            this.FtrHead = new System.Windows.Forms.GroupBox();
            this.GearFace = new System.Windows.Forms.ComboBox();
            this.GearDir = new System.Windows.Forms.ComboBox();
            this.GearType = new System.Windows.Forms.ComboBox();
            this.ShaftType = new System.Windows.Forms.ComboBox();
            this.Delete = new System.Windows.Forms.Button();
            this.values.SuspendLayout();
            this.FtrHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // ADD
            // 
            this.ADD.Location = new System.Drawing.Point(327, 89);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(21, 60);
            this.ADD.TabIndex = 12;
            this.ADD.Text = "+";
            this.ADD.UseVisualStyleBackColor = true;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // values
            // 
            this.values.Controls.Add(this.GtextBox1);
            this.values.Controls.Add(this.GtextBox2);
            this.values.Controls.Add(this.GtextBox3);
            this.values.Controls.Add(this.slot);
            this.values.Controls.Add(this.chipeihou);
            this.values.Controls.Add(this.Beta);
            this.values.Controls.Add(this.GtextBox4);
            this.values.Controls.Add(this.Alpha);
            this.values.Controls.Add(this.textBox2);
            this.values.Controls.Add(this.textBox1);
            this.values.Controls.Add(this.GtextBox5);
            this.values.Controls.Add(this.m);
            this.values.Controls.Add(this.breadth);
            this.values.Controls.Add(this.z);
            this.values.Location = new System.Drawing.Point(12, 84);
            this.values.Name = "values";
            this.values.Size = new System.Drawing.Size(306, 150);
            this.values.TabIndex = 4;
            this.values.TabStop = false;
            this.values.Text = "设计参数";
            this.values.Visible = false;
            // 
            // GtextBox1
            // 
            this.GtextBox1.Location = new System.Drawing.Point(80, 20);
            this.GtextBox1.Name = "GtextBox1";
            this.GtextBox1.Size = new System.Drawing.Size(57, 23);
            this.GtextBox1.TabIndex = 5;
            this.GtextBox1.Text = "18";
            this.GtextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GtextBox2
            // 
            this.GtextBox2.Location = new System.Drawing.Point(80, 45);
            this.GtextBox2.Name = "GtextBox2";
            this.GtextBox2.Size = new System.Drawing.Size(57, 23);
            this.GtextBox2.TabIndex = 6;
            this.GtextBox2.Text = "25";
            this.GtextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GtextBox3
            // 
            this.GtextBox3.Location = new System.Drawing.Point(80, 70);
            this.GtextBox3.Name = "GtextBox3";
            this.GtextBox3.Size = new System.Drawing.Size(57, 23);
            this.GtextBox3.TabIndex = 7;
            this.GtextBox3.Text = "4";
            this.GtextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // slot
            // 
            this.slot.AutoSize = true;
            this.slot.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.slot.Location = new System.Drawing.Point(152, 46);
            this.slot.Name = "slot";
            this.slot.Size = new System.Drawing.Size(48, 19);
            this.slot.TabIndex = 2;
            this.slot.Text = "凹槽深";
            this.slot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chipeihou
            // 
            this.chipeihou.AutoSize = true;
            this.chipeihou.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chipeihou.Location = new System.Drawing.Point(152, 21);
            this.chipeihou.Name = "chipeihou";
            this.chipeihou.Size = new System.Drawing.Size(48, 19);
            this.chipeihou.TabIndex = 2;
            this.chipeihou.Text = "齿胚厚";
            this.chipeihou.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Beta
            // 
            this.Beta.AutoSize = true;
            this.Beta.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Beta.Location = new System.Drawing.Point(6, 121);
            this.Beta.Name = "Beta";
            this.Beta.Size = new System.Drawing.Size(48, 19);
            this.Beta.TabIndex = 2;
            this.Beta.Text = "螺旋角";
            this.Beta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GtextBox4
            // 
            this.GtextBox4.Location = new System.Drawing.Point(80, 95);
            this.GtextBox4.Name = "GtextBox4";
            this.GtextBox4.Size = new System.Drawing.Size(57, 23);
            this.GtextBox4.TabIndex = 8;
            this.GtextBox4.Text = "20";
            this.GtextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Alpha
            // 
            this.Alpha.AutoSize = true;
            this.Alpha.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Alpha.Location = new System.Drawing.Point(6, 96);
            this.Alpha.Name = "Alpha";
            this.Alpha.Size = new System.Drawing.Size(48, 19);
            this.Alpha.TabIndex = 2;
            this.Alpha.Text = "压力角";
            this.Alpha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(226, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(57, 23);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "6";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(226, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 23);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "30";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GtextBox5
            // 
            this.GtextBox5.Location = new System.Drawing.Point(80, 120);
            this.GtextBox5.Name = "GtextBox5";
            this.GtextBox5.Size = new System.Drawing.Size(57, 23);
            this.GtextBox5.TabIndex = 9;
            this.GtextBox5.Text = "45";
            this.GtextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m
            // 
            this.m.AutoSize = true;
            this.m.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m.Location = new System.Drawing.Point(6, 71);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(35, 19);
            this.m.TabIndex = 2;
            this.m.Text = "模数";
            this.m.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // breadth
            // 
            this.breadth.AutoSize = true;
            this.breadth.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.breadth.Location = new System.Drawing.Point(6, 21);
            this.breadth.Name = "breadth";
            this.breadth.Size = new System.Drawing.Size(61, 19);
            this.breadth.TabIndex = 2;
            this.breadth.Text = "轴段宽度";
            this.breadth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // z
            // 
            this.z.AutoSize = true;
            this.z.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.z.Location = new System.Drawing.Point(6, 46);
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(35, 19);
            this.z.TabIndex = 2;
            this.z.Text = "齿数";
            this.z.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FtrHead
            // 
            this.FtrHead.Controls.Add(this.GearFace);
            this.FtrHead.Controls.Add(this.GearDir);
            this.FtrHead.Controls.Add(this.GearType);
            this.FtrHead.Controls.Add(this.ShaftType);
            this.FtrHead.Controls.Add(this.values);
            this.FtrHead.Dock = System.Windows.Forms.DockStyle.Left;
            this.FtrHead.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FtrHead.Location = new System.Drawing.Point(0, 0);
            this.FtrHead.Name = "FtrHead";
            this.FtrHead.Size = new System.Drawing.Size(325, 300);
            this.FtrHead.TabIndex = 0;
            this.FtrHead.TabStop = false;
            this.FtrHead.Text = "定义轴段";
            // 
            // GearFace
            // 
            this.GearFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GearFace.FormattingEnabled = true;
            this.GearFace.Items.AddRange(new object[] {
            "(请选择锥面朝向)",
            "向左",
            "向右"});
            this.GearFace.Location = new System.Drawing.Point(168, 54);
            this.GearFace.Name = "GearFace";
            this.GearFace.Size = new System.Drawing.Size(127, 25);
            this.GearFace.TabIndex = 4;
            this.GearFace.Visible = false;
            this.GearFace.SelectedIndexChanged += new System.EventHandler(this.GearFace_SelectedIndexChanged);
            // 
            // GearDir
            // 
            this.GearDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GearDir.FormattingEnabled = true;
            this.GearDir.Items.AddRange(new object[] {
            "(请选择旋向)",
            "左旋",
            "右旋"});
            this.GearDir.Location = new System.Drawing.Point(22, 54);
            this.GearDir.Name = "GearDir";
            this.GearDir.Size = new System.Drawing.Size(127, 25);
            this.GearDir.TabIndex = 3;
            this.GearDir.Visible = false;
            this.GearDir.SelectedIndexChanged += new System.EventHandler(this.GearDir_SelectedIndexChanged);
            // 
            // GearType
            // 
            this.GearType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GearType.FormattingEnabled = true;
            this.GearType.Items.AddRange(new object[] {
            "(请选择齿轮类型)",
            "直齿轮",
            "斜齿轮"});
            this.GearType.Location = new System.Drawing.Point(168, 22);
            this.GearType.Name = "GearType";
            this.GearType.Size = new System.Drawing.Size(127, 25);
            this.GearType.TabIndex = 2;
            this.GearType.Visible = false;
            this.GearType.SelectedIndexChanged += new System.EventHandler(this.GearType_SelectedIndexChanged);
            // 
            // ShaftType
            // 
            this.ShaftType.DisplayMember = "1";
            this.ShaftType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShaftType.FormattingEnabled = true;
            this.ShaftType.Items.AddRange(new object[] {
            "(请选择轴段类型)",
            "普通轴段",
            "圆柱直/斜齿轮",
            "圆锥直齿轮"});
            this.ShaftType.Location = new System.Drawing.Point(22, 22);
            this.ShaftType.Name = "ShaftType";
            this.ShaftType.Size = new System.Drawing.Size(127, 25);
            this.ShaftType.TabIndex = 1;
            this.ShaftType.Tag = "";
            this.ShaftType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(327, 155);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(21, 60);
            this.Delete.TabIndex = 0;
            this.Delete.TabStop = false;
            this.Delete.Text = "-";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ftrwin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.ADD);
            this.Controls.Add(this.FtrHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ftrwin";
            this.Text = "ftrwin";
            this.values.ResumeLayout(false);
            this.values.PerformLayout();
            this.FtrHead.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.GroupBox values;
        private System.Windows.Forms.TextBox GtextBox1;
        private System.Windows.Forms.TextBox GtextBox2;
        private System.Windows.Forms.TextBox GtextBox3;
        private System.Windows.Forms.Label Beta;
        private System.Windows.Forms.TextBox GtextBox4;
        private System.Windows.Forms.Label Alpha;
        private System.Windows.Forms.TextBox GtextBox5;
        private System.Windows.Forms.Label m;
        private System.Windows.Forms.Label breadth;
        private System.Windows.Forms.Label z;
        private System.Windows.Forms.GroupBox FtrHead;
        private System.Windows.Forms.ComboBox ShaftType;
        private System.Windows.Forms.ComboBox GearType;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ComboBox GearDir;
        private System.Windows.Forms.ComboBox GearFace;
        private System.Windows.Forms.Label chipeihou;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label slot;
        private System.Windows.Forms.TextBox textBox2;
    }
}