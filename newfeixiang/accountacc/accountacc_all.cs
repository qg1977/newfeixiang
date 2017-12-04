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
    public partial class accountacc_all : a_qg_trol.qg_form
    {
        public accountacc_all()
        {
            InitializeComponent();
        }

        private void containerinto1_Load(object sender, EventArgs e)
        {

        }





        private void qg_button1_Click(object sender, EventArgs e)
        {
            int rowindex = qg_grid1.CurrentCell.RowIndex;
            string id = qg_grid1.Rows[rowindex].Cells["ID"].Value.ToString();

            accountacc_one accone = new accountacc_one();
            DataTable dt = accone.accountacconesqlone(id);
            Form2 form2 = new Form2();
            form2.dt = dt;
            form2.Owner = this;
            form2.ShowDialog();
        }

        private void accountacc_all_Shown(object sender, EventArgs e)
        {
            accountacc_one accone = new accountacc_one();
            DataTable dt = accone.accountaccone("201703", "201703", "", "315", "", "", "", "", "", "", "", "", "1");
      
            qg_grid1.DataSource = dt;
            qg_grid1.AutoGenerateColumns = true;
        }

//结束
    }
}
