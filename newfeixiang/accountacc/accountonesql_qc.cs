using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace newfeixiang.accountacc
{
    public partial class accountonesql_qc : Form
    {
        public accountonesql_qc()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            
            Width = 1;
            Height = 1;
            
        }

        private void accountonesql_qc_Shown(object sender, EventArgs e)
        {
        
            accountonesql acc = new accountonesql();
            acc.Form_wfiliale =begin_class.wfilialeid1;
            acc.MdiParent = MdiParent;
            //窗体居中
            acc.WindowState = FormWindowState.Normal;
            acc.Show();
            this.Close();
        }
    }
}
