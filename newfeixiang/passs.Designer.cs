namespace newfeixiang
{
    partial class passs
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
            this.button1 = new System.Windows.Forms.Button();
            this.qg_text1 = new newfeixiang.a_qg_trol.qg_text();
            this.qg_button1 = new newfeixiang.a_qg_trol.qg_button();
            this.qg_button2 = new newfeixiang.a_qg_trol.qg_button();
            this.qg_button_quit1 = new newfeixiang.a_qg_trol.qg_button_quit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // qg_text1
            // 
            this.qg_text1.Location = new System.Drawing.Point(131, 33);
            this.qg_text1.Name = "qg_text1";
            this.qg_text1.Size = new System.Drawing.Size(100, 21);
            this.qg_text1.TabIndex = 0;
            // 
            // qg_button1
            // 
            this.qg_button1.Location = new System.Drawing.Point(316, 112);
            this.qg_button1.Name = "qg_button1";
            this.qg_button1.Size = new System.Drawing.Size(75, 23);
            this.qg_button1.TabIndex = 2;
            this.qg_button1.Text = "qg_button1";
            this.qg_button1.UseVisualStyleBackColor = true;
            this.qg_button1.Click += new System.EventHandler(this.qg_button1_Click);
            // 
            // qg_button2
            // 
            this.qg_button2.Location = new System.Drawing.Point(330, 159);
            this.qg_button2.Name = "qg_button2";
            this.qg_button2.Size = new System.Drawing.Size(75, 23);
            this.qg_button2.TabIndex = 3;
            this.qg_button2.Text = "qg_button2";
            this.qg_button2.UseVisualStyleBackColor = true;
            this.qg_button2.Click += new System.EventHandler(this.qg_button2_Click);
            // 
            // qg_button_quit1
            // 
            this.qg_button_quit1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.qg_button_quit1.Location = new System.Drawing.Point(351, 212);
            this.qg_button_quit1.Name = "qg_button_quit1";
            this.qg_button_quit1.Size = new System.Drawing.Size(75, 23);
            this.qg_button_quit1.TabIndex = 4;
            this.qg_button_quit1.Text = "退出";
            this.qg_button_quit1.UseVisualStyleBackColor = true;
            // 
            // passs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 259);
            this.Controls.Add(this.qg_button_quit1);
            this.Controls.Add(this.qg_button2);
            this.Controls.Add(this.qg_button1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.qg_text1);
            this.Name = "passs";
            this.Text = "passs";
            this.Load += new System.EventHandler(this.passs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private a_qg_trol.qg_text qg_text1;
        private System.Windows.Forms.Button button1;
        private a_qg_trol.qg_button qg_button1;
        private a_qg_trol.qg_button qg_button2;
        private a_qg_trol.qg_button_quit qg_button_quit1;
    }
}