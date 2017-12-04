namespace newfeixiang.a_qg_trol.aqgvoucher
{
    partial class containerall
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
            this.containermoneyallcon1 = new newfeixiang.a_qg_trol.aqgvoucher.containermoneyallcon();
            this.containertitleall1 = new newfeixiang.a_qg_trol.aqgvoucher.containertitleall();
            this.containermoneybottom1 = new newfeixiang.a_qg_trol.aqgvoucher.containermoneybottom();
            this.SuspendLayout();
            // 
            // containermoneyallcon1
            // 
            this.containermoneyallcon1.Location = new System.Drawing.Point(26, 60);
            this.containermoneyallcon1.Name = "containermoneyallcon1";
            this.containermoneyallcon1.Size = new System.Drawing.Size(763, 226);
            this.containermoneyallcon1.TabIndex = 1;
            // 
            // containertitleall1
            // 
            this.containertitleall1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.containertitleall1.Location = new System.Drawing.Point(26, 14);
            this.containertitleall1.Name = "containertitleall1";
            this.containertitleall1.Size = new System.Drawing.Size(763, 40);
            this.containertitleall1.TabIndex = 0;
            // 
            // containermoneybottom1
            // 
            this.containermoneybottom1.Location = new System.Drawing.Point(26, 293);
            this.containermoneybottom1.Name = "containermoneybottom1";
            this.containermoneybottom1.Size = new System.Drawing.Size(686, 72);
            this.containermoneybottom1.TabIndex = 2;
            // 
            // containerall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.containermoneybottom1);
            this.Controls.Add(this.containermoneyallcon1);
            this.Controls.Add(this.containertitleall1);
            this.Name = "containerall";
            this.Size = new System.Drawing.Size(886, 402);
            this.Load += new System.EventHandler(this.containerall_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private containertitleall containertitleall1;
        private containermoneyallcon containermoneyallcon1;
        private containermoneybottom containermoneybottom1;
    }
}
