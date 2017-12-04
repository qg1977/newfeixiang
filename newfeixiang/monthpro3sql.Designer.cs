namespace newfeixiang
{
    partial class monthpro3sql
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
            this.qg_label1 = new newfeixiang.a_qg_trol.qg_label();
            this.monaaa = new newfeixiang.a_qg_trol.qg_combobox();
            this.monbbb = new newfeixiang.a_qg_trol.qg_combobox();
            this.qg_label2 = new newfeixiang.a_qg_trol.qg_label();
            this.qg_button1 = new newfeixiang.a_qg_trol.qg_button();
            this.qg_button_quit1 = new newfeixiang.a_qg_trol.qg_button_quit();
            this.SuspendLayout();
            // 
            // qg_label1
            // 
            this.qg_label1.AutoSize = true;
            this.qg_label1.BackColor = System.Drawing.Color.Transparent;
            this.qg_label1.Location = new System.Drawing.Point(22, 24);
            this.qg_label1.Name = "qg_label1";
            this.qg_label1.Size = new System.Drawing.Size(65, 12);
            this.qg_label1.TabIndex = 0;
            this.qg_label1.Text = "开始月份：";
            // 
            // monaaa
            // 
            this.monaaa.FormattingEnabled = true;
            this.monaaa.Location = new System.Drawing.Point(88, 21);
            this.monaaa.Name = "monaaa";
            this.monaaa.Size = new System.Drawing.Size(121, 20);
            this.monaaa.TabIndex = 1;
            // 
            // monbbb
            // 
            this.monbbb.FormattingEnabled = true;
            this.monbbb.Location = new System.Drawing.Point(312, 21);
            this.monbbb.Name = "monbbb";
            this.monbbb.Size = new System.Drawing.Size(121, 20);
            this.monbbb.TabIndex = 3;
            // 
            // qg_label2
            // 
            this.qg_label2.AutoSize = true;
            this.qg_label2.BackColor = System.Drawing.Color.Transparent;
            this.qg_label2.Location = new System.Drawing.Point(246, 24);
            this.qg_label2.Name = "qg_label2";
            this.qg_label2.Size = new System.Drawing.Size(65, 12);
            this.qg_label2.TabIndex = 2;
            this.qg_label2.Text = "结束月份：";
            // 
            // qg_button1
            // 
            this.qg_button1.Location = new System.Drawing.Point(109, 70);
            this.qg_button1.Name = "qg_button1";
            this.qg_button1.Size = new System.Drawing.Size(75, 23);
            this.qg_button1.TabIndex = 4;
            this.qg_button1.Text = "确  定";
            this.qg_button1.UseVisualStyleBackColor = true;
            this.qg_button1.Click += new System.EventHandler(this.qg_button1_Click);
            // 
            // qg_button_quit1
            // 
            this.qg_button_quit1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.qg_button_quit1.Location = new System.Drawing.Point(295, 70);
            this.qg_button_quit1.Name = "qg_button_quit1";
            this.qg_button_quit1.Size = new System.Drawing.Size(75, 23);
            this.qg_button_quit1.TabIndex = 5;
            this.qg_button_quit1.Text = "退  出";
            this.qg_button_quit1.UseVisualStyleBackColor = true;
            // 
            // monthpro3sql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 111);
            this.Controls.Add(this.qg_button_quit1);
            this.Controls.Add(this.qg_button1);
            this.Controls.Add(this.monbbb);
            this.Controls.Add(this.qg_label2);
            this.Controls.Add(this.monaaa);
            this.Controls.Add(this.qg_label1);
            this.Name = "monthpro3sql";
            this.Text = "monthpro3sql";
            this.Shown += new System.EventHandler(this.monthpro3sql_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private a_qg_trol.qg_label qg_label1;
        private a_qg_trol.qg_combobox monaaa;
        private a_qg_trol.qg_combobox monbbb;
        private a_qg_trol.qg_label qg_label2;
        private a_qg_trol.qg_button qg_button1;
        private a_qg_trol.qg_button_quit qg_button_quit1;
    }
}