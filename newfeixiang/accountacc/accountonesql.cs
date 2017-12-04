using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using newfeixiang.a_sqlconn;
using static newfeixiang.a_GlobalClass.con_sql;

namespace newfeixiang.accountacc
{
    public partial class accountonesql : a_qg_trol.qg_form
    {
        public string Form_wfiliale;

        public accountonesql()
        {
            InitializeComponent();
            qg_radio_group1.AccessibleDescription = "全部,收入凭证,支出凭证,转帐凭证";
            qg_radio_group1.Tag = 4;

            qg_radio_group2.AccessibleDescription = "全部,已制单,已审核,主管已审,已记帐,作废";
            qg_radio_group2.Tag = 6;
        }


        private void accountonesql_Load(object sender, EventArgs e)
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

                DataRow[] rows_km = begin_class.dt_cw_prg_all.Select("分公司ID=" + Form_wfiliale);
                DataTable dt_km = Cs_Datatable.Row_To_Table(rows_km);
                kmaaa.DataSource = dt_km;
                kmaaa.DisplayMember = "编码加名称";
                kmaaa.ValueMember = "ID";

                sqlstring = "select 分公司名称 from wfiliale where ID='" + Form_wfiliale + "'";
                DataTable dt = return_select(sqlstring);
                string wfilialenametemp1 = dt.Rows[0]["分公司名称"].ToString();
                qg_bt_label1.Text=qg_bt_label1.Text.Trim()+"("+wfilialenametemp1.Trim()+")";

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

                string subid = "";//科目ID
                if (kmaaa.Text.NotIsNullOrEmpty())
                { subid = kmaaa.SelectedValue.ToString(); }

                string pjh1 = pjh1_text.Text.ToString().Trim();
                string pzh1 = pzh1_text.Text.ToString();

                int pz_type = qg_radio_group1.Tag.ToString().ToInt();//凭证类型
                string pz_typeid = "";
                switch(pz_type)
                {
                    case 1://全部
                        pz_typeid = "";
                        break;
                    case 2://收入凭证
                        pz_typeid = begin_class.wcodingtypepzid1;
                        break;
                    case 3://支出凭证
                        pz_typeid = begin_class.wcodingtypepzid2;
                        break;
                    case 4://转帐凭证
                        pz_typeid = begin_class.wcodingtypepzid3;
                        break;
                    default:
                        break;
                }
                
                int pz_zt = qg_radio_group2.Tag.ToString().ToInt();//凭证状态
                string pz_ztid = "";
                switch(pz_zt)
                {
                    case 1://全部
                        pz_ztid = "";
                        break;
                    case 2://已制单
                        pz_ztid = "1";
                        break;
                    case 3://已审核 
                        pz_ztid = "2";
                        break;
                    case 4://主管已审
                        pz_ztid = "5";
                        break;
                    case 5://已记帐
                        pz_ztid = "5";
                        break;
                    case 6://作废
                        pz_ztid = "9";
                        break;
                    default:
                        break;
                }
                accountacc_one accone = new accountacc_one();
                begin_class.vouchereditdbfacc = accone.accountaccone(pro3, pro3, pz_typeid, subid, pz_ztid, pjh1, pzh1, "", "", "", "", "", "1");
                if (begin_class.vouchereditdbfacc.Rows.Count <= 0) { MessageBox.Show("没有查找到相应的凭证！"); }

                //string accallidtempid = begin_class.vouchereditdbfacc.Rows[0]["ID"].ToString();

                accountone acc = new accountone();
                //foreach (Control trol in acc.Controls)
                //{
                //    if (trol is a_qg_trol.aqgvoucher.containerallall)
                //    { ((a_qg_trol.aqgvoucher.containerallall)trol).accallid_new = accallidtempid; }
                //}
                acc.Owner = this;
                acc.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }


        //结束
    }
}
