using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using newfeixiang.a_sqlconn;
using static newfeixiang.a_GlobalClass.con_sql;

namespace newfeixiang.daywork
{
    public partial class daywork : a_qg_trol.qg_form
    {
        //DataTable dt_pprbbb;//工序号的源表

        public DataTable dt_dayworkcal=new DataTable();//废品原因的表

        public daywork()
        {
            try
            {
                InitializeComponent();
                qg_radio_group1.AccessibleDescription = "正常,只计算数量,二次生产";
                qg_radio_group1.Tag = 3;




                string sqlstring = "select ID, ltrim(rtrim(班次)) 班次 from wclass where 删除 = 0";
                DataTable dt = return_select(sqlstring);
                string temp = "";
                int sumtemp1 = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i > 0)
                    { temp = temp + ","; }
                    temp = temp + dt.Rows[i]["班次"].ToString();
                }
                //qg_radio_group2.AccessibleDescription = "白班,小夜班,中夜班,大夜班";
                qg_radio_group2.AccessibleDescription = temp;
                qg_radio_group2.Tag = sumtemp1;
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void daywork_Load(object sender, EventArgs e)
        {
            auto();
            get_ph();
        }


        public void auto()
        {
            try
            {
                string[] hour_string = new string[24];
                for (int i = 1; i <= 24; i++)
                { hour_string[i - 1] = i.ToString(); }
                hour1_text.DataSource = hour_string;

                string[] time_string = new string[12];
                for (int i = 0; i <= 55; i = i + 5)
                { time_string[i / 5] = i.ToString(); }
                time1_text.DataSource = time_string;


                string sqlstring = "select ID,ltrim(rtrim(姓名)) 姓名,拼音 from person where 删除=0"
                    + " and "
                    + "("
                    + "(分公司ID='" + begin_class.wfilialeid3 + "' and ID in (select 员工ID from persume2 where 所属单位='" + begin_class.cusfxidall + "' and 删除=0))"
                    + ")";
                DataTable dt_peraaa = return_select(sqlstring);

                peraaa.DataSource = dt_peraaa;
                peraaa.DisplayMember = "姓名";
                peraaa.ValueMember = "ID";


                sqlstring = "select distinct ltrim(rtrim(产品名称)) 产品名称,拼音 from pproduct where ID in (select distinct 产品ID from process where 产品ID in "
                   + "(select distinct 产品ID from pprstock where 考核类型 in ('" + begin_class.wtempid1 + "','" + begin_class.wtempid2 + "','" + begin_class.wtempid4 + "') and 删除=0)"
                   + " or 班产定额=1) and 删除=0";
                DataTable dt_ppraaa = return_select(sqlstring);

                ppraaa.DataSource = dt_ppraaa;
                ppraaa.DisplayMember = "产品名称";

                DataColumn dc1 = new DataColumn("ID", Type.GetType("System.Int64"));
                dt_dayworkcal.Columns.Add(dc1);
                dc1 = new DataColumn("数量", Type.GetType("System.Int32"));
                dt_dayworkcal.Columns.Add(dc1);
                dc1 = new DataColumn("考核ID", Type.GetType("System.Int32"));
                dt_dayworkcal.Columns.Add(dc1);
                dc1 = new DataColumn("废品现象", Type.GetType("System.String"));
                dt_dayworkcal.Columns.Add(dc1);
                dc1 = new DataColumn("类型", Type.GetType("System.Int32"));
                dt_dayworkcal.Columns.Add(dc1);
                dc1 = new DataColumn("类型名称", Type.GetType("System.String"));
                dt_dayworkcal.Columns.Add(dc1);
                dc1 = new DataColumn("原因详ID", Type.GetType("System.String"));
                dt_dayworkcal.Columns.Add(dc1);
                dc1 = new DataColumn("具体原因", Type.GetType("System.String"));
                dt_dayworkcal.Columns.Add(dc1);

                qg_grid_qt.DataSource = dt_dayworkcal;
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void get_ph()
        {
            try {
                peraaa.Text = "";
                ppraaa.Text = "";
                pprbbb.Text = "";
                proceaaa.Text = "";
                hour1_text.Text = "";
                time1_text.Text = "";


                js_all_text.Text = "0";
                js1_text.Text = "0";
                js_1_text.Text = "0";
                js_2_text.Text = "0";
                js_3_text.Text = "0";
                js_4_text.Text = "0";

                while (qg_grid_qt.Rows.Count != 0)
                {
                    qg_grid_qt.Rows.RemoveAt(0);
                }

                string sqlstring = "select distinct ISNULL(票号,1) 票号 from daywork where 月份='" + begin_class.allmax + "' order by 票号";
                DataTable dt = return_select(sqlstring);
                int counti = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int phtemp1 = dt.Rows[i]["票号"].ToString().ToInt();
                    //MessageBox.Show(phtemp1.ToString()+" "+counti.ToString());
                    if (phtemp1 != counti)
                    { break; }
                   
                    counti = counti+1;
                }
                ph1_text.Text = counti.ToString();
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void ppraaa_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                pprbbb.DataSource = null;
                proceaaa.DataSource = null;
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

        private void pprbbb_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                proceaaa.DataSource = null;
                if (pprbbb.SelectedValue != null)
                {
                    string pprid = pprbbb.SelectedValue.ToString();

                    string sqlstring = "select ID,(LTRIM(RTRIM(车间工序号))+' '+LTRIM(RTRIM(工序名称))) 详细工序号,工序号 系统工序号"
                      + ",ISNULL(组号,0) 组号 from process where 产品ID='" + pprid + "' and 删除=0 order by 系统工序号,组号";

                    DataTable dt_proceaaa = return_select(sqlstring);

                    proceaaa.DataSource = dt_proceaaa;
                    proceaaa.DisplayMember = "详细工序号";
                    proceaaa.ValueMember = "ID";
                    proceaaa.Text = "";

                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }



        private void qg_button_small1_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(ppraaa.Text))
                {
                    MessageBox.Show("请选择产品名称!");
                    return;
                }
                if (string.IsNullOrEmpty(pprbbb.Text))
                {
                    MessageBox.Show("请选择规格!");
                    return;
                }
                if (string.IsNullOrEmpty(proceaaa.Text))
                {
                    MessageBox.Show("请选择工序号!");
                    return;
                }

                if (pprbbb.SelectedValue == null)
                {
                    MessageBox.Show("没有查找到产品ＩＤ!");
                    return;
                }
                string pprid = pprbbb.SelectedValue.ToString();


                dayworkaacal1 cal = new dayworkaacal1();
                cal.pprid = pprid;
                cal.Owner = this;
                cal.ShowDialog();
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void qg_button_small2_Click(object sender, EventArgs e)
        {
            try
            {
  
                if (qg_grid_qt.Rows.Count <= 0)
                {
                    MessageBox.Show("没有记录！");
                    return;
                }
                //int index = qg_grid_qt.CurrentCell.RowIndex;
                int rowindex = qg_grid_qt.CurrentCell.RowIndex;
                string temp = "";
                temp = temp + "\n" + "废品现象：" + qg_grid_qt.Rows[rowindex].Cells[0].Value.ToString()
                    + "\n具体原因：" + qg_grid_qt.Rows[rowindex].Cells[1].Value.ToString()
                    + "\n数量：" + qg_grid_qt.Rows[rowindex].Cells[2].Value.ToString() + "件"
                    + "\n类型：" + qg_grid_qt.Rows[rowindex].Cells[3].Value.ToString();

                DialogResult dr = MessageBox.Show("确认删除吗？" + temp, "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                qg_grid_qt.Rows.Remove(qg_grid_qt.CurrentRow);
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //使用红色虚线绘制边框  
            Pen pen1 = new Pen(Color.Red, 1);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen1.DashPattern = new float[] { 4f, 2f };
            e.Graphics.DrawRectangle(pen1, 0, 0, this.panel1.Width - 1, this.panel1.Height - 1);
        }

        //合格数=“完工数”-“工废”-料废-机废-调试
        #region
        private void js_all_text_TextChanged(object sender, EventArgs e)
        { js_value_change(); }

        private void js_value_change()
        {
            js1_text.Text =(
                js_all_text.Text.ToString().ToInt() -
         (js_1_text.Text.ToString().ToInt() + js_2_text.Text.ToString().ToInt() + js_3_text.Text.ToString().ToInt() + js_4_text.Text.ToString().ToInt())
         ).ToString();
        }

        private void js_1_text_TextChanged(object sender, EventArgs e)
        { js_value_change(); }

        private void js_2_text_TextChanged(object sender, EventArgs e)
        { js_value_change(); }

        private void js_3_text_TextChanged(object sender, EventArgs e)
        { js_value_change(); }

        private void js_4_text_TextChanged(object sender, EventArgs e)
        { js_value_change(); }
        #endregion

        private void qg_button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(peraaa.Text))
                {
                    MessageBox.Show("请选择员工!");
                    return;
                }
                if (string.IsNullOrEmpty(ppraaa.Text))
                {
                    MessageBox.Show("请选择产品名称!");
                    return;
                }
                if (string.IsNullOrEmpty(pprbbb.Text))
                {
                    MessageBox.Show("请选择规格!");
                    return;
                }
                if (string.IsNullOrEmpty(proceaaa.Text))
                {
                    MessageBox.Show("请选择工序号!");
                    return;
                }
                if (Convert.ToInt32(js1_text.Text.ToString()) < 0)
                {
                    MessageBox.Show("合格件数不正常!");
                    return;
                }
                if (string.IsNullOrEmpty(hour1_text.Text) || string.IsNullOrEmpty(time1_text.Text))
                {
                    MessageBox.Show("请选择工作时间!");
                    return;
                }
                if (string.IsNullOrEmpty(pch1_text.Text))
                {
                    MessageBox.Show("请输入批次号!");
                    return;
                }
                //工时
                double hour_all = hour1_text.Text.ToDouble() + time1_text.Text.ToDouble()/ 60; // 得出工时的数字值


                //工作票的方式是“正常”还是“只计算数量”
                int day_fs = Convert.ToInt32(qg_radio_group1.Tag.ToString());

                //员工ID
                string perid = peraaa.SelectedValue.ToString();

                //产品信息ID
                string pprid = pprbbb.SelectedValue.ToString();
                string ppr_name = ppraaa.Text.ToString().Trim() + pprbbb.Text.ToString().Trim();
                string proceid = proceaaa.SelectedValue.ToString();
                int js_all = Convert.ToInt32(js_all_text.Text.ToString());//完工数
                int js1 = Convert.ToInt32(js1_text.Text.ToString());//合格数


                string sqlstring = "select 工序号 系统工序号,车间工序号,单序工资,工序名称,组号"
                     +",班产定额,工资=ISNULL((select 工资 from wage where 工资类型=p.工资类型 and 删除=0),0)"
                        +" from process p where ID='" + proceid + "'";
                DataTable dt = return_select(sqlstring);

                int proce1 = Convert.ToInt32(dt.Rows[0]["系统工序号"].ToString());
                double proce_gz = Convert.ToDouble(dt.Rows[0]["单序工资"].ToString());
                string proce1x = dt.Rows[0]["车间工序号"].ToString();
                string proce_name = dt.Rows[0]["工序名称"].ToString();
                int proce_zh = Convert.ToInt32(dt.Rows[0]["组号"].ToString());

                double bctemp1 = dt.Rows[0]["班产定额"].ToString().ToDouble();
                double gztemp1 = dt.Rows[0]["工资"].ToString().ToDouble();
                if (day_fs != 2 && (proce_gz <= 0 || bctemp1<=0 || gztemp1<=0))
                {
                    MessageBox.Show("该工序没有指定单序工资，无法填写正常工作票，只有填写“只计算数量”工作票！");
                    return;
                }

                //班次信息
                string wclassname1 = qg_radio_group2.AccessibleDescription.ToString();
                string sql_string = "select ID from wclass where 班次='" + wclassname1.Trim() + "'";
                dt = return_select(sql_string);
                string wclassid = dt.Rows[0]["ID"].ToString();



                #region 判断废品的数量 和 废品原因记录表中的废品数量是否一致
                DataTable dt_qt = (DataTable)qg_grid_qt.DataSource;
                int fpsl_temp = 0;
                //string fpsl_temp_string = dt_qt.Compute("sum(数量)", "类型名称='工废'").ToString();
                //if (!string.IsNullOrEmpty(fpsl_temp_string))
                //{ fpsl_temp = Convert.ToInt32(fpsl_temp_string); }
                //int js_1 = Convert.ToInt32(js_1_text.Text.ToString());
                fpsl_temp = dt_qt.Compute("sum(数量)", "类型名称='工废'").ToString().ToInt();
                int js_1 = js_1_text.Text.ToString().ToInt();
                if (js_1 != fpsl_temp)
                {
                    MessageBox.Show("工作票的工废件数为" + js_1.ToString() + "件，废品现象中的工废件数为：" + fpsl_temp.ToString() + "件！");
                    return;
                }

                fpsl_temp = 0;
                fpsl_temp = dt_qt.Compute("sum(数量)", "类型名称='料废'").ToString().ToInt();
                int js_2 = js_2_text.Text.ToString().ToInt();
                if (js_2 != fpsl_temp)
                {
                    MessageBox.Show("工作票的料废件数为" + js_2.ToString() + "件，废品现象中的料废件数为：" + fpsl_temp.ToString() + "件！");
                    return;
                }

                fpsl_temp = 0;
                fpsl_temp = dt_qt.Compute("sum(数量)", "类型名称='机废'").ToString().ToInt();
                int js_3 = js_3_text.Text.ToString().ToInt();
                if (js_3 != fpsl_temp)
                {
                    MessageBox.Show("工作票的机废件数为" + js_3.ToString() + "件，废品现象中的机废件数为：" + fpsl_temp.ToString() + "件！");
                    return;
                }

                fpsl_temp = 0;
                fpsl_temp = dt_qt.Compute("sum(数量)", "类型名称='调试'").ToString().ToInt();
                int js_4 = js_4_text.Text.ToString().ToInt();
                if (js_4 != fpsl_temp)
                {
                    MessageBox.Show("工作票的调试废品件数为" + js_4.ToString() + "件，废品现象中的调试废品件数为：" + fpsl_temp.ToString() + "件！");
                    return;
                }
                #endregion 判断废品的数量 和 废品原因记录表中的废品数量是否一致




                #region 如果是第一道工序，则判断相应的毛坯是否已经投入
                if (proce1 == 10)
                {
                    sqlstring = "select 原料ID,考核类型,毛重 from pprstock where 产品ID='" + pprid + "' and 考核类型 in ('" + begin_class.wtempid1 + "') and 删除=0";
                    dt = return_select(sqlstring);

                    // 如果该产品有“镶件毛坯”或“成品毛坯”
                    if (dt.Rows.Count > 0)
                    {
                        string waretempx = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i > 0) { waretempx = waretempx + ","; }
                            waretempx = waretempx + dt.Rows[i]["原料ID"].ToString();
                        }

                        sqlstring = "select ISNULL(sum(完工数),0) 已生产数 from daywork where 月份='" + begin_class.allmax + "' and convert(int,工序号)=10 and 属性 in (0,4)"
                             + " and 月产品ID in (select ID from productionmonth where 月份 = '" + begin_class.allmax + "' and 产品ID in (select 产品ID from pprstock where 原料ID in (" + waretempx.Trim() + ")))";
                        dt = return_select(sqlstring);

                        int day10sum1x = Convert.ToInt32(dt.Rows[0]["已生产数"].ToString());

                        sqlstring = "select 原料ID,原料名称=(select 名称 from warehouse where ID=pprsto.原料ID),原料规格=(select 规格 from warehouse where ID=pprsto.原料ID)"
                            + ",数量,出库毛坯数=ISNULL(("
                            + "select sum(数量) from goodsallot where 月份='" + begin_class.allmax + "' and 原料ID=pprsto.原料ID and 方式='" + begin_class.wmodeid2 + "' and 考核类型='" + begin_class.wtempid1 + "' and 属性 in (0,1,2)"
                            + " and 月产品ID in (select ID from productionmonth where 月份='" + begin_class.allmax + "' and 产品ID in (select 产品ID from pprstock where 原料ID in (" + waretempx.Trim() + ")))"
                            + "),0)"
                            + " from pprstock pprsto where 产品ID='" + pprid + "' and 考核类型='" + begin_class.wtempid1 + "' and 删除=0";
                        dt = return_select(sqlstring);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string waretemp1 = dt.Rows[i]["原料名称"].ToString();
                            string waretemp2 = dt.Rows[i]["原料规格"].ToString();
                            int ckmp1 = (int)Convert.ToDouble(dt.Rows[i]["出库毛坯数"].ToString());
                            double sltemp1 = Convert.ToDouble(dt.Rows[i]["数量"].ToString());
                            if (sltemp1 <= 0)
                            { sltemp1 = 0; }
                            string temp1temp1 = "";
                            if (sltemp1 > 1)
                            { temp1temp1 = "\n" + "每生产一件" + ppr_name.Trim() + "需要" + sltemp1.ToString() + "件" + waretemp1.Trim() + waretemp2.Trim() + "!"; }

                            if ((ckmp1 / sltemp1) < (day10sum1x + js_all))
                            {
                                MessageBox.Show(
                                    "＂" + waretemp1.Trim() + waretemp2.Trim() + "＂本月领用出库的数量仅为：" + ckmp1.ToString() + "件！" + temp1temp1
                                    + "\n" + "而＂" + ppr_name + "＂第一序的已生产件数为：" + day10sum1x.ToString() + "件，加上本张工作票的生产件数：" + js_all.ToString() + "件,第一序生产件数为" + (day10sum1x + js_all).ToString() + "件！"
                                    + "\n" + "已超过＂" + waretemp1.Trim() + waretemp2.Trim() + "＂的领用件数！"
                                    );

                                return;
                            }

                        }

                    }
                }
                #endregion 如果是第一道工序，则判断相应的毛坯是否已经投入

                #region 生成月产品ID proid
                sqlstring = "select ID from productionmonth where 月份='" + begin_class.allmax + "' and 产品ID='" + pprid + "'";
                dt = return_select(sqlstring);

                string proid = "0";
                if (dt.Rows.Count > 0)
                {
                    proid = dt.Rows[0]["ID"].ToString();
                }
                else
                {
                    sqlstring = "insert productionmonth(产品ID) values ('" + pprid + "')";
                    insert_update_delete(sqlstring);
                    sqlstring = "select ID from productionmonth where 月份='" + begin_class.allmax + "' and 产品ID='" + pprid + "'";
                    dt = return_select(sqlstring);

                    proid = dt.Rows[0]["ID"].ToString();
                }
                #endregion 生成月产品ID proid


                //如果“组号”为0，则或本工序只有一个车间工序号，或有两个或两个以上的车间工序号的组号均为0，否则判断出错
                #region 
                sqlstring = "select ID,车间工序号,工序号,工序名称,组号 from process where 删除=0 and 产品ID='" + pprid + "' and 工序号=" + proce1.ToString()
                     +" and ID!='"+proceid+"'";
                if (proce_zh == 0) { sqlstring = sqlstring + " and 组号!=0"; }
                else { sqlstring = sqlstring + " and 组号=0"; }
                dt = return_select(sqlstring);
                if (dt.Rows.Count>0)
                {
                    string procex1temp1 = dt.Rows[0]["车间工序号"].ToString().Trim();
                    string procenametemp1 = dt.Rows[0]["工序名称"].ToString().Trim();
                    string procezhtemp1 = dt.Rows[0]["组号"].ToString().Trim();

                    MessageBox.Show(
                          "本工序的组号为："+proce_zh.ToString()
                          +"\n"+"与本工序同步的另一道工序“"+procex1temp1.Trim()+"："+procenametemp1+"”组号为"+procezhtemp1+"！"
                           +"无法正常输入工作票！请与系统管理员联系！"
                          );
                    return;
                }
                #endregion
                //如果“组号”为0，则或本工序只有一个车间工序号，或有两个或两个以上的车间工序号的组号均为0，否则判断出错
     
                //上一道工序的组号不能一个为0，另一个不为0，只能全部为0，或全部不为0
                #region
                sqlstring = "select ID,车间工序号,工序号,工序名称,组号 from process where 删除=0 and 产品ID='" + pprid + "' and 工序号=" +(proce1-10).ToString();
                dt = return_select(sqlstring);
               
                 var query= from c in dt.AsEnumerable()
                                where c.Field<decimal>("组号") == 0
                                select c;
      
                DataTable dtx = query.LinqToTable(dt);
            
                if (dtx.Rows.Count>0)
                {
                    string procex1temp1 = dtx.Rows[0]["车间工序号"].ToString().Trim();
                    string procenametemp1 = dtx.Rows[0]["工序名称"].ToString().Trim();
                    string procezhtemp1 = dtx.Rows[0]["组号"].ToString().Trim();

                    dtx = (from c in dt.AsEnumerable()
                           where c.Field<decimal>("组号") > 0
                           select c)
                           .LinqToTable(dt);
                    if (dtx.Rows.Count>0)
                    {
                        string procex1temp2 = dtx.Rows[0]["车间工序号"].ToString().Trim();
                        string procenametemp2 = dtx.Rows[0]["工序名称"].ToString().Trim();
                        string procezhtemp2 = dtx.Rows[0]["组号"].ToString().Trim();

                        MessageBox.Show(
                            "上一工序中有：" + procex1temp1 + "：" + procenametemp1 + "”组号为" + procezhtemp1 + "！"
                        +"\n" + "另一组：" + procex1temp2 + "：" + procenametemp2 + "”组号为" + procezhtemp2 + "！"
                        +"\n" + "无法正常输入工作票！请与系统管理员联系！"
                            );

                        return;
                    }
                }
                #endregion
                //上一道工序的组号不能一个为0，另一个不为0，只能全部为0，或全部不为0

           
                //如果不是第一道工序，则判断以前工序的投入数是否足够本序生产
                // 如果是“二次生产”则不需要这样
                #region
                if (proce1>10 && day_fs!= 3 && proce1 % 10 == 0)
                {
                    
                    sqlstring = "select ID,车间工序号,工序号,工序名称,组号 from process where 删除=0 and 产品ID='" + pprid + "' and 工序号=" + (proce1-10).ToString();
                    dt = return_select(sqlstring);
                    int reccounttemp1 = dt.Rows.Count;
                    if (reccounttemp1 <= 0)
                    { MessageBox.Show("工序信息不正常，无法找到该工序的前一道工序信息，请与系统管理员联系！"); return; }

                    //如果上个工序只能一个车间工序，则上序件数肯定只用求这一个工序的数量

                    string proceqygid = "0";//前一道工序的ID
                    string proceqygidall = "";//前一道工序的工序ID之all
                    string procetopnameall = "";//前一道工序的工序名称之和

                    if (reccounttemp1==1)
                    {
                         proceqygid = dt.Rows[0]["ID"].ToString();//前一道工序的ID
                        proceqygidall = proceqygid;//前一道工序的工序ID之all
                         procetopnameall= dt.Rows[0]["工序名称"].ToString().Trim();//前一道工序的工序名称之和
                    }else
                    {
                        if (proce_zh==0)
                        {
                            dtx = dt.Copy();
                        } else
                        {
                            dtx = (from c in dt.AsEnumerable()
                                   where c.Field<decimal>("组号") == proce_zh || c.Field<decimal>("组号") == 0
                                   select c)
                                  .LinqToTable(dt);
                        }
                        for(int i=0;i<dtx.Rows.Count;i++)
                        {
                            string procetopidtempid = dtx.Rows[i]["ID"].ToString();
                            string procetopnametemp1= dtx.Rows[i]["工序名称"].ToString().Trim();

                            if (i>0)
                            { proceqygidall = proceqygidall.Trim() + ",";    procetopnameall = procetopnameall.Trim() + "、"; }

                            proceqygidall = proceqygidall.Trim() + procetopidtempid.Trim();
                            procetopnametemp1 = procetopnametemp1.Trim() + procetopnametemp1.Trim();
                        }

                    }
                    //如果上个工序只能一个车间工序，则上序件数肯定只用求这一个工序的数量

                    sqlstring = "select ISNULL(sum(上序月初数),0) 上序月初数,ISNULL(sum(上序生产数),0) 上序生产数"
                         + " from ("
                         + "select ISNULL((case when 属性=1 then 合格数 else 0 end),0) 上序月初数"
                         + ",ISNULL((case when 属性 in (0,4,6) then 合格数 else 0 end),0) 上序生产数"
                         + " from ("
                         + "select 工序ID,完工数,(完工数-工废-料废-机废-调试废品) 合格数,属性"
                         + " from daywork where 工序ID in (" + proceqygidall.Trim() + ") and 月份='" +begin_class. allmax + "' and 属性 in (0,1,4,6)"
                         + ") temp"
                         + ") temp";
                    dt = return_select(sqlstring);

                    int procedaysumtemp1 = Convert.ToInt32(dt.Rows[0]["上序月初数"].ToString());
                    int procedaysumtemp2 = Convert.ToInt32(dt.Rows[0]["上序生产数"].ToString());

                    //本工序的工序ID之和，因为可能本工序的组号为0，则需要查出同一工序的所有车间工序号的工序ID之all
                    string proceidall = proceid;
                    string procenameall = proce_name;

                    sqlstring = "select ID,工序名称 from process where 产品ID='" + pprid + "' and 删除=0 and ID!='" + proceid + "' and 工序号=" + proce1.ToString()
                        + " and 组号=" +proce_zh.ToString();
                    dt = return_select(sqlstring);
                    if (dt.Rows.Count>0)
                    {
                        for(int i=0;i<dt.Rows.Count;i++)
                        {
                            string proceidtempid = dtx.Rows[i]["ID"].ToString().Trim();
                            string procenametemp1 = dtx.Rows[i]["工序名称"].ToString().Trim();

                            if (i > 0)
                            { proceidall = proceidall.Trim() + ","; procenameall = procenameall.Trim() + "、"; }

                            proceidall = proceidall.Trim() + proceidtempid.Trim();
                            procenameall = procenameall.Trim() + procenametemp1.Trim();
                        }
                    }

                    sqlstring = "select ISNULL(sum(本序生产数),0) 本序生产数"
                         + " from ("
                           + "select ISNULL((case when 属性 in (0,4) then 完工数 else 0 end),0) 本序生产数"
                           + " from ("
                         + "select 工序ID,完工数,(完工数-工废-料废-机废-调试废品) 合格数,属性 from daywork where 工序ID in (" + proceidall + ") and 月份='" +begin_class. allmax + "' and 属性 in (0,1,4,6)"
                           + ") temp"
                         + ") temp";
                    dt = return_select(sqlstring);
                    int procedaysumtemp3 =Convert.ToInt32( dt.Rows[0]["本序生产数"].ToString());
         
                    //如果当前数量+本序生产数>(上序月初数+上序生产数),则判断出错
                    if ((js_all + procedaysumtemp3) > (procedaysumtemp1 + procedaysumtemp2))
                    {
                        MessageBox.Show(
                            "前一道工序“" + procetopnameall + "”的月初数：" + procedaysumtemp1.ToString() + "件，本月生产件数为：" + procedaysumtemp2.ToString() + "件，合计：" + (procedaysumtemp1 + procedaysumtemp2).ToString() + "件！"
                        +"\n" + "本道工序“" + procenameall + "”已生产件数：" + procedaysumtemp3.ToString() + "件，本张工作票生产件数：" + js_all.ToString() + "件，合计：" + (procedaysumtemp3 + js_all).ToString() + "件！"
                        +"\n" + "已经超出上一工序生产件数：" + (js_all + procedaysumtemp3 - procedaysumtemp1 - procedaysumtemp2).ToString() + "件！"
                            );

                        //return;
                    }
                    //本工序的工序ID之和，因为可能本工序的组号为0，则需要查出同一工序的所有车间工序号的工序ID之all
                }
                #endregion
                //如果不是第一道工序，则判断以前工序的投入数是否足够本序生产


                sqlstring = "insert into daywork(姓名,月产品ID,工序ID,完工数,工废,料废,机废,调试废品,工时,票号";
                sqlstring = sqlstring + ",日期";
                sqlstring=sqlstring+",操作员,班次,批次号";
                sqlstring = sqlstring + ",属性";
                if (day_fs == 2)
                { sqlstring = sqlstring + ",工资月份,纳入成本"; }
                sqlstring = sqlstring + ") values (";
                sqlstring = sqlstring + "'" + perid + "','" + proid + "','" + proceid + "'," + js_all.ToString() + "," + js_1.ToString() + "," + js_2.ToString() + "," + js_3.ToString() + "," + js_4.ToString() +","+hour_all.ToString("0.0")+","+ph1_text.Text.ToString();
                sqlstring = sqlstring + ",(convert(varchar(10),'" + data1_text.Value.ToShortDateString().ToString() + "',120))";
                sqlstring = sqlstring + ",'" + allczy_user.strUsrId+"','"+wclassid+"','"+pch1_text.Text.ToString()+"'";
                switch(day_fs)
                {
                    case 1: sqlstring = sqlstring + ",0"; break;
                    case 2: sqlstring = sqlstring + ",4"; break;
                    case 3: sqlstring = sqlstring + ",6"; break;
                    default: sqlstring = sqlstring + ",-1"; break;
                }
                if (day_fs==2)//一般和属性4配合，属性为4纳入成本为1表示该条工作票除了不计算工资，其它都计算，属性为4纳入成本为2表示该条工作票什么都不算
                { sqlstring = sqlstring + ",'',2"; }
                sqlstring = sqlstring + ")";

                insert_update_delete(sqlstring);

                sqlstring = "select MAX(ID) ID from daywork";
                dt = return_select(sqlstring);
                string dayid = dt.Rows[0]["ID"].ToString();

                string csql = "";
                dt = (DataTable)qg_grid_qt.DataSource;
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string lxtemp1 = dt.Rows[i]["类型"].ToString(); 
                    string calkhidtempid = dt.Rows[i]["考核ID"].ToString(); 
                    string calyyidtempid = dt.Rows[i]["原因详ID"].ToString(); 
                    string sltemp1 = dt.Rows[i]["数量"].ToString();

                    csql = csql + "\n" + "insert into dayworkcal(日ID,考核ID,原因详ID,类型,数量"
                        + ") values ("
                        + "'" + dayid + "','" + calkhidtempid + "','" + calyyidtempid + "'," + lxtemp1 + "," + sltemp1
                        + ")";
                }

                insert_update_delete(csql);

                    get_ph();
                //“确定”按钮结束
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }


        //结束
    }
}
