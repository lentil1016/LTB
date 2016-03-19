
using System.Collections.Generic;

namespace LentilToolbox
{
    partial class Shaftwin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shaftwin));
            this.ListShower = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.preview = new LentilToolbox.Preview();
            this.Generate = new System.Windows.Forms.Button();
            this.previewMSG = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.preview.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListShower
            // 
            this.ListShower.BackColor = System.Drawing.SystemColors.Control;
            this.ListShower.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListShower.Location = new System.Drawing.Point(0, 0);
            this.ListShower.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListShower.Name = "ListShower";
            this.ListShower.Size = new System.Drawing.Size(1002, 516);
            this.ListShower.TabIndex = 0;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 439);
            this.hScrollBar1.Maximum = 0;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1002, 17);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Visible = false;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ListShower);
            this.splitContainer1.Panel1.Controls.Add(this.hScrollBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.preview);
            this.splitContainer1.Panel2.Controls.Add(this.previewMSG);
            this.splitContainer1.Panel2.Controls.Add(this.Generate);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 501);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // preview
            // 
            this.preview.Cursor = System.Windows.Forms.Cursors.Default;
            this.preview.Location = new System.Drawing.Point(0, 40);
            this.preview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(1002, 425);
            this.preview.TabIndex = 0;
            // 
            // Generate
            // 
            this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Generate.Cursor = System.Windows.Forms.Cursors.Default;
            this.Generate.Location = new System.Drawing.Point(915, 1);
            this.Generate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(87, 34);
            this.Generate.TabIndex = 0;
            this.Generate.Text = "生成零件";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // previewMSG
            // 
            this.previewMSG.AutoSize = true;
            this.previewMSG.Location = new System.Drawing.Point(5, 7);
            this.previewMSG.Name = "previewMSG";
            this.previewMSG.Size = new System.Drawing.Size(104, 17);
            this.previewMSG.TabIndex = 0;
            this.previewMSG.Text = "上拉查看轴段预览";
            // 
            // Shaftwin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 501);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Shaftwin";
            this.Text = "传动零件生成插件";
            this.SizeChanged += new System.EventHandler(this.Shaftwin_SizeChanged);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.preview.ResumeLayout(false);
            this.preview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ListShower;
        private Preview preview;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Label previewMSG;
    }
}