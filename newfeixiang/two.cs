using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using newfeixiang.a_sqlconn;
using static newfeixiang.a_GlobalClass.con_sql;

namespace newfeixiang
{

    public partial class two : a_qg_trol.qg_form
    {
       

        public two()
        {
            
            InitializeComponent();
            qg_bt_label1.Text = "qqqqqq";

            /*skinEngine1.SkinFile = "skins/DiamondBlue.ssk";*/
            this.qg_grid1.ShowCellToolTips = false;
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = " ";
            this.toolTip1.UseAnimation = true;
            this.toolTip1.UseFading = true;

            qg_dy1.dy_title = "新的标题";
            qg_dy1.dy_month = "我是月份";

        }

        public delegate void TestDelegate();

        static void Test()
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Height.ToString());
            //sqlconn.other ot = new sqlconn.other();
            //ot.winwait(qg_grid1);
            //TestDelegate d = Test;
            //this.toolTip1.Show("正在导出数据，请稍候……", qg_grid1, 250, 250);
            //d.BeginInvoke(null, null);
            //MessageBox.Show(GlobalClass.userInfo.user.strUsrName.ToString());

            //Form passs = new passs();
            //passs.Owner = this;
            //passs.ShowDialog();
        }


        private void two_Load(object sender, EventArgs e)
        {
            string sqlstring = "select ID,ltrim(rtrim(姓名)) 姓名,拼音 from person where 删除=0";
            //DataTable dt = conn.return_select(sqlstring);
            DataTable dt = return_select(sqlstring);
            //DataRow[] arow = dt.Select("" + ColumnsName + "='" + DataValue + "'");
            DataRow[] arow = dt.Select("拼音='zx'");
            DataTable dtarow = arow.CopyToDataTable();
            DataTable dt1 = dt.Copy();
            qg_combobox1.DataSource = dt;
            qg_combobox1.DisplayMember = "姓名";
            qg_combobox1.ValueMember = "ID";



            qg_jd_combobox2.DataSource = dt;
            qg_jd_combobox2.DisplayMember = "姓名";
            qg_jd_combobox2.ValueMember = "ID";

            sqlstring = "select ID,姓名 员工ID,完工数,产品ID from daywork where 月份='201701'";
            //DataTable datemp1 = conn.return_select(sqlstring);
            DataTable datemp1 = return_select(sqlstring);
            sqlstring = "select ID,姓名 from person where 删除=0";
            //DataTable datemp2 = conn.return_select(sqlstring);
            DataTable datemp2 = return_select(sqlstring);

            var query =
                from datemp1x in datemp1.AsEnumerable()
                join datemp2x in datemp2.AsEnumerable()
                on datemp1x.Field<int>("姓名ID") equals
                   datemp2x.Field<int>("ID")
                where datemp1x.Field<int>("产品ID") == 301
                select new
                {
                    ID=
                    datemp1x.Field<int>("ID"),
                    姓名ID=
                    datemp2x.Field<int>("ID")
                };
            DataTable newda = new DataTable();

            //List<> templist = query.ToList();
            //from order in orders.AsEnumerable()
            //join detail in details.AsEnumerable()
            //on order.Field<int>("SalesOrderID") equals
            //    detail.Field<int>("SalesOrderID")
            //where order.Field<bool>("OnlineOrderFlag") == true
            //&& order.Field<DateTime>("OrderDate").Month == 8
            //select new
            //{
            //    SalesOrderID =
            //        order.Field<int>("SalesOrderID"),
            //    SalesOrderDetailID =
            //        detail.Field<int>("SalesOrderDetailID"),
            //    OrderDate =
            //        order.Field<DateTime>("OrderDate"),
            //    ProductID =
            //        detail.Field<int>("ProductID")
            //};

            //DataTable dt2 = dt.Copy();
            //qg_jd_combobox1.DataSource = dt2;
            //qg_jd_combobox1.DisplayMember = "姓名";
            //qg_jd_combobox1.ValueMember = "ID";

            //DataTable dt3 = dt.Copy();
            //qg_combobox2.DataSource = dt3;
            //qg_combobox2.DisplayMember = "姓名";
            //qg_combobox2.ValueMember = "ID";

            sqlstring = "select top 100 0000 序号,0 选择,000000 排序,ID,姓名 员工ID,姓名就是我呀就是我=(select 姓名 from person where ID=d.姓名),完工数"
                     + " from daywork d where 月份='201612' and 属性=0";
            //dt = conn.return_select(sqlstring);
            dt= return_select(sqlstring);
            //dt.DefaultView.Sort="员工ID";
            dt = a_sqlconn.Cs_Datatable.AddSeriNumToDataTable(dt);
            qg_grid1.DataSource = dt;
            qg_grid1.xz_jytt = true;

            
        }


        private void comboBox1_Enter(object sender, EventArgs e)
        {
           //comboBox1.BackColor = Color.LightCyan; //当textBox1获得焦点时，背景色变为LightCyan（淡蓝绿色）
        }


        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            //if (comboBox1.Tag!=null)
            //{
            //    comboBox1.Tag = comboBox1.Tag.ToString() + comboBox1.Text.ToString();
            //}else
            //{ comboBox1.Tag = comboBox1.Text.ToString(); }

            //comboBox1.Tag = comboBox1.Text.ToString();

            //DataTable dt = (DataTable)comboBox1.DataSource;
            //dt.DefaultView.RowFilter = " 拼音 like '%" + comboBox1.Tag.ToString().Trim() + "%'";
            //qg_text1.Text = dt.DefaultView.Count.ToString();
            //comboBox1.SelectedIndex = -1;

            //comboBox1.Text = comboBox1.Tag.ToString();
            //comboBox1.SelectionStart = comboBox1.Text.Length;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            //bool jytttemp = true;
            //if (comboBox1.SelectedIndex == -1)
            //{
            //    jytttemp = false;
            //}
            //    DataTable dt = (DataTable)comboBox1.DataSource;
            //dt.DefaultView.RowFilter = "";
            //if (!jytttemp)
            //{
            //    comboBox1.Text = "";
            //    comboBox1.SelectedIndex = -1;
            //}
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Chocolate, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));
            e.Graphics.DrawString(this.toolTip1.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Red, e.Bounds);

        }

        private void qg_dy1_Click(object sender, EventArgs e)
        {
           
            List<string> tit = new List<string>();


        }
    }
}
