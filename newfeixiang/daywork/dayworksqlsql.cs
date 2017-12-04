using System;
using System.Data;
using System.Windows.Forms;

using newfeixiang.a_sqlconn;
using static newfeixiang.a_GlobalClass.con_sql;

namespace newfeixiang.daywork
{
    public partial class dayworksqlsql : a_qg_trol.qg_form
    {
        public dayworksqlsql()
        {
            InitializeComponent();
            qg_radio_group1.AccessibleDescription = "是,否";
            qg_radio_group1.Tag = 2;
        }

        private void dayworksqlsql_Load(object sender, EventArgs e)
        {


            auto();
        }

        public void auto()
        {
            try
            {
                string sqlstring = "select distinct 月份 from daywork order by 月份 desc";
                DataTable dt_mon = return_select(sqlstring);
                monaaa.DataSource = dt_mon;
                monaaa.DisplayMember = "月份";
                if (dt_mon.Rows.Count > 0) { monaaa.flag = false; monaaa.SelectedIndex = 0; }


                sqlstring = "select ID,ltrim(rtrim(姓名)) 姓名,拼音 from person where 删除=0";
                DataTable dt_peraaa = return_select(sqlstring);
                peraaa.DataSource = dt_peraaa;
                peraaa.DisplayMember = "姓名";
                peraaa.ValueMember = "ID";
                peraaa.SelectedIndex = 0;

                sqlstring = "select distinct ltrim(rtrim(产品名称)) 产品名称,拼音 from pproduct where 删除=0";
                DataTable dt_ppraaa = return_select(sqlstring);
                ppraaa.DataSource = dt_ppraaa;
                ppraaa.DisplayMember = "产品名称";
            }
            catch (Exception ex)
            {
                ex.errormess();
            }

        }

        private void ppraaa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pprbbb.DataSource = null;
                if (ppraaa.SelectedValue != null)
                {
                    string ppr1 = ppraaa.Text.ToString();

                    string sqlstring = "SELECT distinct ID,ltrim(rtrim(规格)) 规格 from pproduct where 产品名称=LTRIM(RTRIM('" + ppr1 + "')) and ID in (select distinct 产品ID from process where 产品ID in "
                      + "(select distinct 产品ID from pprstock where 考核类型 in ('" + begin_class.wtempid1 + "','" + begin_class.wtempid2 + "','" + begin_class.wtempid4 + "'))"
                      + " or 班产定额=1) and 删除=0";
                    DataTable  dt_pprbbb = return_select(sqlstring);

                    pprbbb.DataSource = dt_pprbbb;
                    pprbbb.DisplayMember = "规格";
                    pprbbb.ValueMember = "ID";
                    if (dt_pprbbb.Rows.Count > 1) { pprbbb.Text = ""; }
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void qg_button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (monaaa.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("请选择月份");
                    return;
                }
                string pro3 = monaaa.Text.ToString();

                int px_jytt = qg_radio_group1.Tag.ToString().ToInt();

                string perid = "";
                if (peraaa.Text.NotIsNullOrEmpty())
                { perid = peraaa.SelectedValue.ToString(); }

                string pprid = "";
                if (ppraaa.Text.NotIsNullOrEmpty() && pprbbb.Text.NotIsNullOrEmpty())
                { pprid = pprbbb.SelectedValue.ToString(); }

                
                int ph1 = ph1_text.Text.ToString().ToInt();

                DataTable dt;



                if (px_jytt==2)
                {
                     dt = daywork_one.dayworksql(pro3, pro3, pro3, pro3, DateTime.Now, DateTime.Now, 1
              , ph1, "", perid, pprid, "", 0, "", "");
                }
                else
                {
                    dt = dayworksqlform.dayworksql_form(pro3, pro3, pro3, pro3, DateTime.Now, DateTime.Now, 1
              , ph1, "", perid, pprid, "", 0, "", "");
                }

                
                dayworksql day = new dayworksql();
                day.dt_daywork = dt;
                day.pro3 = pro3;
                day.Owner = this;
                day.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        //结束
    }
}
