using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using newfeixiang.a_sqlconn;
using static newfeixiang.a_GlobalClass.con_sql;
using djdc_employee_wages.a_sqlconn;

namespace newfeixiang.daywork
{
    public partial class dayworkaacal1 : a_qg_trol.qg_form
    {
        public string pprid;

        public dayworkaacal1()
        {           
            InitializeComponent();
            qg_radio_group1.Tag = 4;
            qg_radio_group1.AccessibleDescription = "料废,工废,机废,调试";

            sl1.Text= "0";
        }
        private void qg_radio_group1_Load(object sender, EventArgs e)
        {
            auto();
        }
        public void auto()
        {
            try
            {
                string sqlstring = "select ID,ltrim(rtrim(考核名称)) 考核名称,拼音 from calibrate where 产品ID='" + pprid + "' and 删除=0 and 属性=0";
                DataTable dt_calaaa = return_select(sqlstring);

                calaaa.DataSource = dt_calaaa;
                calaaa.DisplayMember = "考核名称";
                calaaa.ValueMember = "ID";

                sqlstring = "select distinct ltrim(rtrim(考核名称)) 考核名称,拼音 from calibrate where 删除=0 and 属性=2";
                DataTable dt_calbbb = return_select(sqlstring);

                calbbb.DataSource = dt_calbbb;
                calbbb.DisplayMember = "考核名称";
            }
            catch (Exception ex)
            {
                ex.errormess();
            }

        }

        private void calaaa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calaaa.SelectedValue != null)
            {
                fpxx1.Text = calaaa.Text.ToString();
            }

        }

        private void calbbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calbbb.SelectedValue != null)
            { fpyy1.Text = calbbb.Text.ToString(); }
        }

        private void qg_button1_Click(object sender, EventArgs e)
        {
            try
            {
                string lxid = qg_radio_group1.Tag.ToString();
                string lxname = qg_radio_group1.AccessibleDescription.ToString();

                //if (string.IsNullOrEmpty(fpxx1.Text))
                if (fpxx1.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("请输入废品现象!");
                    return;
                }
                if (fpyy1.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("请输入废品原因!");
                    return;
                }
                ////if (!a_sqlconn.Simple_all.isNumberic(sl1.Text.ToString()))
                //{
                //    MessageBox.Show("请输入正确的数量!");
                //    return;
                //}
                int sl = sl1.Text.ToInt();
                if (sl <= 0)
                {
                    MessageBox.Show("数量不正确！");
                    return;
                }

                string fpxx = fpxx1.Text.ToString().Trim();
                string fpyy = fpyy1.Text.ToString().Trim();
                string fpxx_py = MyPinYin.GetFirst(fpxx);
                string fpyy_py = MyPinYin.GetFirst(fpyy);

                #region
                string sqlstring = "select * from calibrate where 产品ID='" + pprid + "' and  属性=0 and LTRIM(RTRIM(考核名称))=LTRIM(RTRIM('" + fpxx + "'))";
                DataTable dt = return_select(sqlstring);


                string fpxxid = "0";
                if (dt.Rows.Count > 0)
                {
                    fpxxid = dt.Rows[0]["ID"].ToString();
                }
                else
                {
                    sqlstring = "insert into calibrate(产品ID,考核名称,拼音,属性) values ('" + pprid + "',LTRIM(RTRIM('" + fpxx + "')),LTRIM(RTRIM('" + fpxx_py + "')),2)";
                    insert_update_delete(sqlstring);


                    sqlstring = "select * from calibrate where 产品ID='" + pprid + "' and  属性=0 and LTRIM(RTRIM(考核名称))=LTRIM(RTRIM('" + fpxx + "'))";
                    dt = return_select(sqlstring);


                    fpxxid = dt.Rows[0]["ID"].ToString();
                }
                #endregion

                #region
                sqlstring = "select * from calibrate where 属性=2 and LTRIM(RTRIM(考核名称))=LTRIM(RTRIM('" + fpyy + "'))";
                dt = return_select(sqlstring);


                string fpyyid = "0";
                if (dt.Rows.Count > 0)
                {
                    fpyyid = dt.Rows[0]["ID"].ToString();
                }
                else
                {
                    sqlstring = "insert into calibrate(考核名称,拼音,属性) values (LTRIM(RTRIM('" + fpyy + "')),LTRIM(RTRIM('" + fpyy_py + "')),2)";
                    insert_update_delete(sqlstring);


                    sqlstring = "select * from calibrate where 属性=2 and LTRIM(RTRIM(考核名称))=LTRIM(RTRIM('" + fpyy + "'))";
                    dt = return_select(sqlstring);


                    fpyyid = dt.Rows[0]["ID"].ToString();
                }
                #endregion

                //INSERT into dayworkcal(ID, 考核ID, 废品现象, 数量, 原因详ID, 具体原因, 类型名称, 类型) values(maxid, calid1, daycalx1, daycalx2, calid3, daycalx4, templx, daycalx5)

                daywork day1 = (daywork)Owner;
                DataRow dr = day1.dt_dayworkcal.NewRow();
                dr["考核ID"] = fpxxid;
                dr["废品现象"] = fpxx;
                dr["数量"] = sl;
                dr["原因详ID"] = fpyyid;
                dr["具体原因"] = fpyy;
                dr["类型名称"] = lxname;
                dr["类型"] = lxid;
                day1.dt_dayworkcal.Rows.Add(dr);

                fpxx1.Text = "";
                calaaa.Text = "";
                fpyy1.Text = "";
                calbbb.Text = "";
                sl1.Text = "0";
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }





        //结束
    }
}
