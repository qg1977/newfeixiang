namespace newfeixiang
{
    partial class Form1
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
            this.qg_grid_tree1 = new newfeixiang.a_qg_trol.qg_grid_tree();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.拼音 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.编码名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qg_grid_tree1)).BeginInit();
            this.SuspendLayout();
            // 
            // qg_grid_tree1
            // 
            this.qg_grid_tree1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.qg_grid_tree1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.qg_grid_tree1.auto_jytt = true;
            this.qg_grid_tree1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.qg_grid_tree1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.qg_grid_tree1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.qg_grid_tree1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qg_grid_tree1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.拼音,
            this.ID,
            this.编码名称,
            this.编码});
            this.qg_grid_tree1.Location = new System.Drawing.Point(28, 26);
            this.qg_grid_tree1.Name = "qg_grid_tree1";
            this.qg_grid_tree1.RowHeadersVisible = false;
            this.qg_grid_tree1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.qg_grid_tree1.RowTemplate.Height = 30;
            this.qg_grid_tree1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.qg_grid_tree1.Size = new System.Drawing.Size(925, 266);
            this.qg_grid_tree1.TabIndex = 0;
            this.qg_grid_tree1.xz_jytt = false;
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            // 
            // 拼音
            // 
            this.拼音.HeaderText = "拼音";
            this.拼音.Name = "拼音";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // 编码名称
            // 
            this.编码名称.HeaderText = "编码名称";
            this.编码名称.Name = "编码名称";
            // 
            // 编码
            // 
            this.编码.HeaderText = "编码";
            this.编码.Name = "编码";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Location = new System.Drawing.Point(945, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 551);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.qg_grid_tree1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.qg_grid_tree1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private a_qg_trol.qg_grid_tree qg_grid_tree1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 拼音;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编码名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编码;
    }
}