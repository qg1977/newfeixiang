using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

using newfeixiang.a_sqlconn;
using static newfeixiang.a_GlobalClass.con_sql;
namespace newfeixiang
{
    public partial class monthpro3sql : a_qg_trol.qg_form
    {
        public monthpro3sql()
        {
            InitializeComponent();
        }

        private void qg_button1_Click(object sender, EventArgs e)
        {
            if (monaaa.Text.IsNullOrEmpty())
            { MessageBox.Show("请选择开始月份！"); return; }
            if (monbbb.Text.IsNullOrEmpty())
            { MessageBox.Show("请选择结束月份！"); return; }


        }

        private void monthpro3sql_Shown(object sender, EventArgs e)
        {
            string sqlstring = "select distinct months 月份 from allmax order by months desc";
            DataTable dt_mon_aaa = return_select(sqlstring);
            monaaa.DataSource = dt_mon_aaa;
            monaaa.DisplayMember = "月份";

            DataTable dt_mon_bbb = dt_mon_aaa.Copy();
            monbbb.DataSource = dt_mon_bbb;
            monbbb.DisplayMember = "月份";
        }

        //结束
    }
}
