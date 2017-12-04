namespace newfeixiang.accountacc
{
    partial class accountacc_all
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.qg_button1 = new newfeixiang.a_qg_trol.qg_button();
            this.qg_button_quit1 = new newfeixiang.a_qg_trol.qg_button_quit();
            this.qg_grid1 = new newfeixiang.a_qg_trol.qg_grid();
            this.qg_dy1 = new newfeixiang.a_qg_trol.qg_dy();
            ((System.ComponentModel.ISupportInitialize)(this.qg_grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // qg_button1
            // 
            this.qg_button1.Location = new System.Drawing.Point(403, 732);
            this.qg_button1.Name = "qg_button1";
            this.qg_button1.Size = new System.Drawing.Size(75, 23);
            this.qg_button1.TabIndex = 1;
            this.qg_button1.Text = "qg_button1";
            this.qg_button1.UseVisualStyleBackColor = true;
            this.qg_button1.Click += new System.EventHandler(this.qg_button1_Click);
            // 
            // qg_button_quit1
            // 
            this.qg_button_quit1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.qg_button_quit1.Location = new System.Drawing.Point(936, 732);
            this.qg_button_quit1.Name = "qg_button_quit1";
            this.qg_button_quit1.Size = new System.Drawing.Size(75, 23);
            this.qg_button_quit1.TabIndex = 3;
            this.qg_button_quit1.Text = "退  出";
            this.qg_button_quit1.UseVisualStyleBackColor = true;
            // 
            // qg_grid1
            // 
            this.qg_grid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.qg_grid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.qg_grid1.auto_jytt = true;
            this.qg_grid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.qg_grid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.qg_grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qg_grid1.Location = new System.Drawing.Point(51, 53);
            this.qg_grid1.Name = "qg_grid1";
            this.qg_grid1.RowHeadersVisible = false;
            this.qg_grid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.qg_grid1.RowTemplate.Height = 30;
            this.qg_grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qg_grid1.Size = new System.Drawing.Size(240, 150);
            this.qg_grid1.TabIndex = 4;
            this.qg_grid1.xz_jytt = false;
            // 
            // qg_dy1
            // 
            this.qg_dy1.dy_month = null;
            this.qg_dy1.dy_title = null;
            this.qg_dy1.Location = new System.Drawing.Point(695, 732);
            this.qg_dy1.Name = "qg_dy1";
            this.qg_dy1.Size = new System.Drawing.Size(75, 23);
            this.qg_dy1.TabIndex = 5;
            this.qg_dy1.Text = "qg_dy1";
            this.qg_dy1.UseVisualStyleBackColor = true;
            // 
            // accountacc_all
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 773);
            this.Controls.Add(this.qg_dy1);
            this.Controls.Add(this.qg_grid1);
            this.Controls.Add(this.qg_button_quit1);
            this.Controls.Add(this.qg_button1);
            this.Name = "accountacc_all";
            this.Text = "accountacc_all";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.accountacc_all_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.qg_grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private a_qg_trol.qg_button qg_button1;
        private a_qg_trol.qg_button_quit qg_button_quit1;
        private a_qg_trol.qg_grid qg_grid1;
        private a_qg_trol.qg_dy qg_dy1;
    }
}