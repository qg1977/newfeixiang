using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace newfeixiang.daywork
{
    public partial class dayworksql : a_qg_trol.qg_form
    {
        public DataTable dt_daywork;
        public string pro3;

        public dayworksql()
        {
            InitializeComponent();
        }

        private void dayworksql_Load(object sender, EventArgs e)
        {
            grid_dayworksql.xz_jytt = true;
            auto();

        }
        private void auto()
        {

            qg_label1.Text = pro3.Substring(0, 4) + "年"+pro3.Substring(4,2)+"月";

            WaitFormService.Show();
            WaitFormService.SetText("正在查询工作票信息,请稍候……");
            grid_dayworksql.DataSource = dt_daywork;
            WaitFormService.Close();
        }

        private void qg_button1_Click(object sender, EventArgs e)
        {

        }


        //结束
    }
}
