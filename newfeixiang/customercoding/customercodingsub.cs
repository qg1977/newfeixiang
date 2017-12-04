using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace newfeixiang.customercoding
{
    public partial class customercodingsub : a_qg_trol.qg_form
    {
        public customercodingsub()
        {
            InitializeComponent();
        }

        private void customerwcodingsub_Shown(object sender, EventArgs e)
        {

            WaitFormService.Show();
            wcoding.wcodingfinance wcoding = new newfeixiang.wcoding.wcodingfinance();
            DataTable dt = wcoding.wcodingfinancetreesql4(begin_class.allmax, "1", 1, "");

            WaitFormService.Close();

            qg_grid_tree1.DataSource = dt;
        }

        private void qg_button4_Click(object sender, EventArgs e)
        {
            monthpro3sql pro3sql = new monthpro3sql();
            pro3sql.Owner = this;
            pro3sql.ShowDialog();

        }

        private void qg_button2_Click(object sender, EventArgs e)
        {

        }

        private void qg_button3_Click(object sender, EventArgs e)
        {

        }
    }
}
