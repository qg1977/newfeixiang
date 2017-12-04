namespace newfeixiang.a_qg_trol.aqgvoucher
{
    partial class containermoneybottom
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
            this.label1 = new System.Windows.Forms.Label();
            this.containerinto2 = new newfeixiang.a_qg_trol.aqgvoucher.containerinto();
            this.containerinto1 = new newfeixiang.a_qg_trol.aqgvoucher.containerinto();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "合  计：";
            // 
            // containerinto2
            // 
            this.containerinto2.BackColor = System.Drawing.Color.White;
            this.containerinto2.Location = new System.Drawing.Point(467, 15);
            this.containerinto2.Name = "containerinto2";
            this.containerinto2.Size = new System.Drawing.Size(198, 45);
            this.containerinto2.TabIndex = 2;
            this.containerinto2.Tag = "0000000000000.00";
            // 
            // containerinto1
            // 
            this.containerinto1.BackColor = System.Drawing.Color.White;
            this.containerinto1.Location = new System.Drawing.Point(254, 15);
            this.containerinto1.Name = "containerinto1";
            this.containerinto1.Size = new System.Drawing.Size(198, 45);
            this.containerinto1.TabIndex = 1;
            this.containerinto1.Tag = "0000000000000.00";
            // 
            // containermoneybottom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.containerinto2);
            this.Controls.Add(this.containerinto1);
            this.Controls.Add(this.label1);
            this.Name = "containermoneybottom";
            this.Size = new System.Drawing.Size(686, 72);
            this.Load += new System.EventHandler(this.containermoneybottom_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.containermoneybottom_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private containerinto containerinto1;
        private containerinto containerinto2;
    }
}
