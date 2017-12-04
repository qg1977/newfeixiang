namespace newfeixiang.a_qg_trol.aqgvoucher
{
    partial class containermoneyall
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.containerselect1 = new newfeixiang.a_qg_trol.aqgvoucher.containerselect();
            this.containeredit2 = new newfeixiang.a_qg_trol.aqgvoucher.containeredit();
            this.containeredit1 = new newfeixiang.a_qg_trol.aqgvoucher.containeredit();
            this.containerinto2 = new newfeixiang.a_qg_trol.aqgvoucher.containerinto();
            this.containerinto1 = new newfeixiang.a_qg_trol.aqgvoucher.containerinto();
            this.SuspendLayout();
            // 
            // containerselect1
            // 
            this.containerselect1.FormattingEnabled = true;
            this.containerselect1.ItemHeight = 12;
            this.containerselect1.Location = new System.Drawing.Point(185, 18);
            this.containerselect1.Name = "containerselect1";
            this.containerselect1.Size = new System.Drawing.Size(170, 20);
            this.containerselect1.TabIndex = 6;
            this.containerselect1.SelectedIndexChanged += new System.EventHandler(this.containerselect1_SelectedIndexChanged);
            this.containerselect1.SelectedValueChanged += new System.EventHandler(this.containerselect1_SelectedValueChanged);
            // 
            // containeredit2
            // 
            this.containeredit2.BackColor = System.Drawing.Color.White;
            this.containeredit2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.containeredit2.Enabled = false;
            this.containeredit2.Location = new System.Drawing.Point(185, 35);
            this.containeredit2.Multiline = true;
            this.containeredit2.Name = "containeredit2";
            this.containeredit2.Size = new System.Drawing.Size(169, 45);
            this.containeredit2.TabIndex = 5;
            // 
            // containeredit1
            // 
            this.containeredit1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.containeredit1.Location = new System.Drawing.Point(-5, 18);
            this.containeredit1.Multiline = true;
            this.containeredit1.Name = "containeredit1";
            this.containeredit1.Size = new System.Drawing.Size(185, 45);
            this.containeredit1.TabIndex = 1;
            // 
            // containerinto2
            // 
            this.containerinto2.BackColor = System.Drawing.Color.White;
            this.containerinto2.Location = new System.Drawing.Point(567, 22);
            this.containerinto2.Name = "containerinto2";
            this.containerinto2.Size = new System.Drawing.Size(198, 45);
            this.containerinto2.TabIndex = 4;
            this.containerinto2.Tag = "0000000000000.00";
            // 
            // containerinto1
            // 
            this.containerinto1.BackColor = System.Drawing.Color.White;
            this.containerinto1.Location = new System.Drawing.Point(359, 21);
            this.containerinto1.Name = "containerinto1";
            this.containerinto1.Size = new System.Drawing.Size(198, 45);
            this.containerinto1.TabIndex = 3;
            this.containerinto1.Tag = "0000000000000.00";
            // 
            // containermoneyall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.containerselect1);
            this.Controls.Add(this.containeredit2);
            this.Controls.Add(this.containeredit1);
            this.Controls.Add(this.containerinto2);
            this.Controls.Add(this.containerinto1);
            this.Name = "containermoneyall";
            this.Size = new System.Drawing.Size(741, 92);
            this.Load += new System.EventHandler(this.containermoneyall_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.containermoneyall_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private containerinto containerinto1;
        private containerinto containerinto2;
        private containeredit containeredit1;
        private containeredit containeredit2;
        private containerselect containerselect1;
    }
}
