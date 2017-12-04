using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using newfeixiang.a_sqlconn;
using static newfeixiang.a_GlobalClass.con_sql;

namespace newfeixiang.a_qg_trol.aqgvoucher
{
    public partial class containermoneyall : UserControl
    {
        public decimal jf_money = 0.0M;//借方金额
        public decimal df_money = 0.0M;//贷方金额

        public containermoneyall()
        {
            InitializeComponent();
            //this.SuspendLayout();
            ////Height = containeredit1.Height ;
            //auto();

            //this.ResumeLayout(false);
        }

        private void containermoneyall_Load(object sender, EventArgs e)
        {
            try {
                Height = containeredit1.Height;
                Width = 763;

                //string sqlstring = "select ID from allmax where ID is null";
                //DataTable dt = return_select(sqlstring);

                DataTable dt = begin_class.dt_cw_prg_all_bottom.Copy();
                if (dt != null)
                {
                    containerselect1.DataSource = dt;
                    containerselect1.DisplayMember = "编码加名称";
                    containerselect1.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                //ex.errormess();
            }
        }

        private void containermoneyall_Paint(object sender, PaintEventArgs e)
        {
            auto();
        }

        /// </summary>画线段   
        /// <param name="p1">起点</param>  
        /// <param name="p2">终点</param>  
        /// <param name="c">线段颜色</param>  
        /// <param name="cx">线段粗线</param>   
        private void create_line(Point p1, Point p2, Color c, int cx)
        {
            try
            {
                Graphics g = CreateGraphics();
                List<Int32> aa = new List<Int32> { 255, 255, 0 };
                //出来一个画笔,这只笔画出来的颜色是红的  
                //Pen p = new Pen(Brushes.Red);

                Pen p = new Pen(c, cx);

                //创建两个点  
                //Point p1 = new Point(50, 0);
                //Point p2 = new Point(50, 48);

                //将两个点连起来  
                g.DrawLine(p, p1, p2);
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }


        private void auto()
        {
            try {
                containeredit1.Height = Height - 2;
                //containerinto1.Height = Height - 2;
                //containerinto2.Height = Height - 2;

                //containerselect1.ItemHeight = Height -20;

                Point p1 = new Point(0, 0);
                Point p2 = new Point(0, Height);
                Color c = Color.Blue;
                create_line(p1, p2, c, 1);
                containeredit1.Left = 2;
                p1 = new Point(containeredit1.Left + containeredit1.Width + 1, 0);
                p2 = new Point(containeredit1.Left + containeredit1.Width + 1, Height);
                create_line(p1, p2, c, 1);
                containerselect1.Left = containeredit1.Left + containeredit1.Width + 2;
                p1 = new Point(containerselect1.Left + containerselect1.Width + 1, 0);
                p2 = new Point(containerselect1.Left + containerselect1.Width + 1, Height);
                create_line(p1, p2, c, 1);
                containerinto1.Left = containerselect1.Left + containerselect1.Width + 2;
                p1 = new Point(containerinto1.Left + containerinto1.Width + 1, 0);
                p2 = new Point(containerinto1.Left + containerinto1.Width + 1, Height);
                create_line(p1, p2, c, 2);
                containerinto2.Left = containerinto1.Left + containerinto1.Width + 4;
                p1 = new Point(containerinto2.Left + containerinto2.Width + 1, 0);
                p2 = new Point(containerinto2.Left + containerinto2.Width + 1, Height);
                create_line(p1, p2, c, 1);

                //p1 = new Point(0, 0);
                //p2 = new Point(Width, 0);
                //create_line(p1, p2, c, 1);
                p1 = new Point(0, Height - 1);
                p2 = new Point(Width, Height - 1);
                create_line(p1, p2, c, 1);

                containeredit1.Top = 1;
                containerselect1.Top = Height - containerselect1.Height - 2;
                containerinto1.Top = -1;
                containerinto2.Top = -1;

                containeredit2.Top = containeredit1.Top;
                containeredit2.Left = containerselect1.Left;
                containeredit2.Width = containerselect1.Width - 17;
                containeredit2.Height = containeredit1.Height;
                containeredit2.BringToFront();//使编辑框居最上面

                Width = containerinto2.Left + containerinto2.Width + 2;
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        //将下拉框选中的值，埴到exit中
        private void containerselect1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                containerselect select = (containerselect)sender;
                containermoneyall moneyall = (containermoneyall)(select.Parent);
                containeredit edit = null;
                foreach (Control trol in moneyall.Controls)
                {
                    if (trol.Name == "containeredit2")
                    {
                        edit = (containeredit)trol;
                        //((containeredit)trol).Text = select.Text.ToString();
                    }
                }

                if (select.Text != null)
                {
                    edit.Text = select.Text.ToString();

                }
                if (select.SelectedValue != null)
                {
                    edit.Tag = select.SelectedValue.ToString();
                    //edit.Text = edit.Text.Trim() + "  ID=" + edit.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }

        }
        private void containerselect1_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(((containerselect)sender).SelectedValue.ToString());
        }


        //本控件第一次生成时的一些值 
        public void auto_set_value()
        {
            try
            {
                DataRow[] rows = begin_class.vouchereditdbf.Select("凭证序号=" + Tag.ToString().Trim());
                containeredit1.Text = rows[0]["摘要"].ToString().Trim();
                containeredit2.Text = rows[0]["科目名称"].ToString().Trim();
                jf_money = rows[0]["借方金额"].ToString().ToDecimal();
                df_money = rows[0]["贷方金额"].ToString().ToDecimal();
                //MessageBox.Show(jf_money.ToString());
                foreach(Control trol in Controls)
                {
                    if (trol.Name== "containerinto1")
                    {
                        containerinto into = (containerinto)trol;
                        into.Tag =  "-"+ jf_money.ToString();
                        into.get_TAG();
                    }
                    //if (trol.Name == "containerinto2")
                    //{
                    //    containerinto into = (containerinto)trol;
                    //    into.Tag = df_money.ToString();
                    //    into.get_TAG();
                    //}
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }




        //结束
    }
}
