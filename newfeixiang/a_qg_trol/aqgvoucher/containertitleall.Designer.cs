namespace newfeixiang.a_qg_trol.aqgvoucher
{
    partial class containertitleall
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
            this.containertitle1 = new newfeixiang.a_qg_trol.aqgvoucher.containertitle();
            this.containertitle2 = new newfeixiang.a_qg_trol.aqgvoucher.containertitle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // containertitle1
            // 
            this.containertitle1.Location = new System.Drawing.Point(276, 53);
            this.containertitle1.Name = "containertitle1";
            this.containertitle1.Size = new System.Drawing.Size(265, 40);
            this.containertitle1.TabIndex = 0;
            // 
            // containertitle2
            // 
            this.containertitle2.Location = new System.Drawing.Point(568, 53);
            this.containertitle2.Name = "containertitle2";
            this.containertitle2.Size = new System.Drawing.Size(231, 43);
            this.containertitle2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "摘   要";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(154, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "财务科目";
            // 
            // containertitleall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.containertitle2);
            this.Controls.Add(this.containertitle1);
            this.Name = "containertitleall";
            this.Size = new System.Drawing.Size(700, 150);
            this.Load += new System.EventHandler(this.containertitleall_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.containertitleall_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private containertitle containertitle1;
        private containertitle containertitle2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
