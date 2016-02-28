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
            this.FtrHead = new System.Windows.Forms.GroupBox();
            this.GearFace = new System.Windows.Forms.ComboBox();
            this.GearDir = new System.Windows.Forms.ComboBox();
            this.GearType = new System.Windows.Forms.ComboBox();
            this.ShaftType = new System.Windows.Forms.ComboBox();
            this.Delete = new System.Windows.Forms.Button();
            this.Values_Bev = new System.Windows.Forms.GroupBox();
            this.Bev_B = new System.Windows.Forms.TextBox();
            this.Bev_z = new System.Windows.Forms.TextBox();
            this.Bev_m = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Bev_Alpha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Bev_C = new System.Windows.Forms.TextBox();
            this.Bev_A = new System.Windows.Forms.TextBox();
            this.Bev_Theta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Values_Sha = new System.Windows.Forms.GroupBox();
            this.Sha_B = new System.Windows.Forms.TextBox();
            this.Sha_d = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Values_Cyl = new System.Windows.Forms.GroupBox();
            this.Cyl_B = new System.Windows.Forms.TextBox();
            this.Cyl_z = new System.Windows.Forms.TextBox();
            this.Cyl_m = new System.Windows.Forms.TextBox();
            this.L_Beta = new System.Windows.Forms.Label();
            this.Cyl_Alpha = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Cyl_Beta = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.FtrHead.SuspendLayout();
            this.Values_Bev.SuspendLayout();
            this.Values_Sha.SuspendLayout();
            this.Values_Cyl.SuspendLayout();
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
            // FtrHead
            // 
            this.FtrHead.Controls.Add(this.GearFace);
            this.FtrHead.Controls.Add(this.GearDir);
            this.FtrHead.Controls.Add(this.GearType);
            this.FtrHead.Controls.Add(this.ShaftType);
            this.FtrHead.Controls.Add(this.Values_Bev);
            this.FtrHead.Controls.Add(this.Values_Cyl);
            this.FtrHead.Controls.Add(this.Values_Sha);
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
            // Values_Bev
            // 
            this.Values_Bev.Controls.Add(this.Bev_B);
            this.Values_Bev.Controls.Add(this.Bev_z);
            this.Values_Bev.Controls.Add(this.Bev_m);
            this.Values_Bev.Controls.Add(this.label1);
            this.Values_Bev.Controls.Add(this.label2);
            this.Values_Bev.Controls.Add(this.label3);
            this.Values_Bev.Controls.Add(this.Bev_Alpha);
            this.Values_Bev.Controls.Add(this.label4);
            this.Values_Bev.Controls.Add(this.Bev_C);
            this.Values_Bev.Controls.Add(this.Bev_A);
            this.Values_Bev.Controls.Add(this.Bev_Theta);
            this.Values_Bev.Controls.Add(this.label5);
            this.Values_Bev.Controls.Add(this.label6);
            this.Values_Bev.Controls.Add(this.label7);
            this.Values_Bev.Location = new System.Drawing.Point(12, 89);
            this.Values_Bev.Name = "Values_Bev";
            this.Values_Bev.Size = new System.Drawing.Size(306, 150);
            this.Values_Bev.TabIndex = 12;
            this.Values_Bev.TabStop = false;
            this.Values_Bev.Text = "设计参数";
            this.Values_Bev.Visible = false;
            // 
            // Bev_B
            // 
            this.Bev_B.Location = new System.Drawing.Point(80, 20);
            this.Bev_B.Name = "Bev_B";
            this.Bev_B.Size = new System.Drawing.Size(57, 23);
            this.Bev_B.TabIndex = 5;
            this.Bev_B.Text = "18";
            this.Bev_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Bev_z
            // 
            this.Bev_z.Location = new System.Drawing.Point(80, 45);
            this.Bev_z.Name = "Bev_z";
            this.Bev_z.Size = new System.Drawing.Size(57, 23);
            this.Bev_z.TabIndex = 6;
            this.Bev_z.Text = "25";
            this.Bev_z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Bev_m
            // 
            this.Bev_m.Location = new System.Drawing.Point(80, 70);
            this.Bev_m.Name = "Bev_m";
            this.Bev_m.Size = new System.Drawing.Size(57, 23);
            this.Bev_m.TabIndex = 7;
            this.Bev_m.Text = "4";
            this.Bev_m.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(152, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "凹槽深";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(152, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "齿胚厚";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "螺旋角";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Bev_Alpha
            // 
            this.Bev_Alpha.Location = new System.Drawing.Point(80, 95);
            this.Bev_Alpha.Name = "Bev_Alpha";
            this.Bev_Alpha.Size = new System.Drawing.Size(57, 23);
            this.Bev_Alpha.TabIndex = 8;
            this.Bev_Alpha.Text = "20";
            this.Bev_Alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "压力角";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Bev_C
            // 
            this.Bev_C.Location = new System.Drawing.Point(226, 45);
            this.Bev_C.Name = "Bev_C";
            this.Bev_C.Size = new System.Drawing.Size(57, 23);
            this.Bev_C.TabIndex = 11;
            this.Bev_C.Text = "6";
            this.Bev_C.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Bev_A
            // 
            this.Bev_A.Location = new System.Drawing.Point(226, 20);
            this.Bev_A.Name = "Bev_A";
            this.Bev_A.Size = new System.Drawing.Size(57, 23);
            this.Bev_A.TabIndex = 10;
            this.Bev_A.Text = "30";
            this.Bev_A.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Bev_Theta
            // 
            this.Bev_Theta.Location = new System.Drawing.Point(80, 120);
            this.Bev_Theta.Name = "Bev_Theta";
            this.Bev_Theta.Size = new System.Drawing.Size(57, 23);
            this.Bev_Theta.TabIndex = 9;
            this.Bev_Theta.Text = "45";
            this.Bev_Theta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "模数";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "齿宽";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "齿数";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Values_Sha
            // 
            this.Values_Sha.Controls.Add(this.Sha_B);
            this.Values_Sha.Controls.Add(this.Sha_d);
            this.Values_Sha.Controls.Add(this.label13);
            this.Values_Sha.Controls.Add(this.label14);
            this.Values_Sha.Location = new System.Drawing.Point(12, 89);
            this.Values_Sha.Name = "Values_Sha";
            this.Values_Sha.Size = new System.Drawing.Size(306, 80);
            this.Values_Sha.TabIndex = 12;
            this.Values_Sha.TabStop = false;
            this.Values_Sha.Text = "设计参数";
            this.Values_Sha.Visible = false;
            // 
            // Sha_B
            // 
            this.Sha_B.Location = new System.Drawing.Point(80, 20);
            this.Sha_B.Name = "Sha_B";
            this.Sha_B.Size = new System.Drawing.Size(57, 23);
            this.Sha_B.TabIndex = 5;
            this.Sha_B.Text = "18";
            this.Sha_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Sha_d
            // 
            this.Sha_d.Location = new System.Drawing.Point(80, 45);
            this.Sha_d.Name = "Sha_d";
            this.Sha_d.Size = new System.Drawing.Size(57, 23);
            this.Sha_d.TabIndex = 6;
            this.Sha_d.Text = "25";
            this.Sha_d.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(6, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 19);
            this.label13.TabIndex = 2;
            this.label13.Text = "轴段宽度";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(6, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 19);
            this.label14.TabIndex = 2;
            this.label14.Text = "轴段直径";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Values_Cyl
            // 
            this.Values_Cyl.Controls.Add(this.Cyl_B);
            this.Values_Cyl.Controls.Add(this.Cyl_z);
            this.Values_Cyl.Controls.Add(this.Cyl_m);
            this.Values_Cyl.Controls.Add(this.L_Beta);
            this.Values_Cyl.Controls.Add(this.Cyl_Alpha);
            this.Values_Cyl.Controls.Add(this.label15);
            this.Values_Cyl.Controls.Add(this.Cyl_Beta);
            this.Values_Cyl.Controls.Add(this.label16);
            this.Values_Cyl.Controls.Add(this.label17);
            this.Values_Cyl.Controls.Add(this.label18);
            this.Values_Cyl.Location = new System.Drawing.Point(12, 89);
            this.Values_Cyl.Name = "Values_Cyl";
            this.Values_Cyl.Size = new System.Drawing.Size(306, 150);
            this.Values_Cyl.TabIndex = 12;
            this.Values_Cyl.TabStop = false;
            this.Values_Cyl.Text = "设计参数";
            this.Values_Cyl.Visible = false;
            // 
            // Cyl_B
            // 
            this.Cyl_B.Location = new System.Drawing.Point(80, 20);
            this.Cyl_B.Name = "Cyl_B";
            this.Cyl_B.Size = new System.Drawing.Size(57, 23);
            this.Cyl_B.TabIndex = 5;
            this.Cyl_B.Text = "18";
            this.Cyl_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cyl_z
            // 
            this.Cyl_z.Location = new System.Drawing.Point(80, 45);
            this.Cyl_z.Name = "Cyl_z";
            this.Cyl_z.Size = new System.Drawing.Size(57, 23);
            this.Cyl_z.TabIndex = 6;
            this.Cyl_z.Text = "25";
            this.Cyl_z.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cyl_m
            // 
            this.Cyl_m.Location = new System.Drawing.Point(80, 70);
            this.Cyl_m.Name = "Cyl_m";
            this.Cyl_m.Size = new System.Drawing.Size(57, 23);
            this.Cyl_m.TabIndex = 7;
            this.Cyl_m.Text = "4";
            this.Cyl_m.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // L_Beta
            // 
            this.L_Beta.AutoSize = true;
            this.L_Beta.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.L_Beta.Location = new System.Drawing.Point(6, 121);
            this.L_Beta.Name = "L_Beta";
            this.L_Beta.Size = new System.Drawing.Size(48, 19);
            this.L_Beta.TabIndex = 2;
            this.L_Beta.Text = "螺旋角";
            this.L_Beta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cyl_Alpha
            // 
            this.Cyl_Alpha.Location = new System.Drawing.Point(80, 95);
            this.Cyl_Alpha.Name = "Cyl_Alpha";
            this.Cyl_Alpha.Size = new System.Drawing.Size(57, 23);
            this.Cyl_Alpha.TabIndex = 8;
            this.Cyl_Alpha.Text = "20";
            this.Cyl_Alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(6, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 19);
            this.label15.TabIndex = 2;
            this.label15.Text = "压力角";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cyl_Beta
            // 
            this.Cyl_Beta.Location = new System.Drawing.Point(80, 120);
            this.Cyl_Beta.Name = "Cyl_Beta";
            this.Cyl_Beta.Size = new System.Drawing.Size(57, 23);
            this.Cyl_Beta.TabIndex = 9;
            this.Cyl_Beta.Text = "45";
            this.Cyl_Beta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(6, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 19);
            this.label16.TabIndex = 2;
            this.label16.Text = "模数";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(6, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 19);
            this.label17.TabIndex = 2;
            this.label17.Text = "齿宽";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(6, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 19);
            this.label18.TabIndex = 2;
            this.label18.Text = "齿数";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.FtrHead.ResumeLayout(false);
            this.Values_Bev.ResumeLayout(false);
            this.Values_Bev.PerformLayout();
            this.Values_Sha.ResumeLayout(false);
            this.Values_Sha.PerformLayout();
            this.Values_Cyl.ResumeLayout(false);
            this.Values_Cyl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.GroupBox FtrHead;
        private System.Windows.Forms.ComboBox ShaftType;
        private System.Windows.Forms.ComboBox GearType;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ComboBox GearDir;
        private System.Windows.Forms.ComboBox GearFace;
        private System.Windows.Forms.GroupBox Values_Bev;
        private System.Windows.Forms.TextBox Bev_B;
        private System.Windows.Forms.TextBox Bev_z;
        private System.Windows.Forms.TextBox Bev_m;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Bev_Alpha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Bev_C;
        private System.Windows.Forms.TextBox Bev_A;
        private System.Windows.Forms.TextBox Bev_Theta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox Values_Sha;
        private System.Windows.Forms.TextBox Sha_B;
        private System.Windows.Forms.TextBox Sha_d;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox Values_Cyl;
        private System.Windows.Forms.TextBox Cyl_B;
        private System.Windows.Forms.TextBox Cyl_z;
        private System.Windows.Forms.TextBox Cyl_m;
        private System.Windows.Forms.Label L_Beta;
        private System.Windows.Forms.TextBox Cyl_Alpha;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Cyl_Beta;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}