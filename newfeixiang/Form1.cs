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
using System.Threading;

namespace newfeixiang
{
    public partial class Form1 : a_qg_trol.qg_form
    {
        //public delegate void TestDelegate(Control c);
        //static void Test(Control c)
        //{
        //    temp(c);
        //}

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Control.CheckForIllegalCrossThreadCalls = false;


        }


        private void ThreadFuntion()
        {
            Control c = null; ;
            MainForm m = (MainForm)MdiParent;
            foreach (Control trol in m.Controls)
            {
                if (trol is Panel)
                {
                    Panel p = (Panel)trol;

                    foreach(Control trolx in p.Controls)
                    {
                        if (trolx is Label)
                        { trolx.Text = "aaaad磊"; MessageBox.Show("a"); }
                    }
                    //c = trol;
                    //ToolTip toolTip = new ToolTip();

                    //int times = 3000000;
                    //string ly = "aaaaadd 的";

                    //toolTip.IsBalloon = true;// 不显示为气泡弹窗，气泡的箭头会乱跑
                    //toolTip.ToolTipIcon = ToolTipIcon.Info;
                    //toolTip.SetToolTip(c, "");
                    //toolTip.ShowAlways = true;// 总是显示
                    //toolTip.UseAnimation = true;
                    //toolTip.UseFading = true;

                    //toolTip.Hide(c);
                    //toolTip.Show(ly, c, c.Width / 2, c.Height / 2, times);

                }
            }
        }
        public static void temp(Control ctol)
        {
            ctol.Visible = true;
            ctol.Text = "我出来了";
            //ToolTip toolTip = new ToolTip();

            //int times = 3000000;
            //string ly = "aaaaadd 的";

            //toolTip.IsBalloon = true;// 不显示为气泡弹窗，气泡的箭头会乱跑
            //toolTip.ToolTipIcon = ToolTipIcon.Info;
            //toolTip.SetToolTip(ctol, "");
            //toolTip.ShowAlways = true;// 总是显示
            //toolTip.UseAnimation = true;
            //toolTip.UseFading = true;

            //toolTip.Hide(trol);
            //toolTip.Show(ly, ctol, ctol.Width / 2, ctol.Height / 2, times);
            //MessageBox.Show(ctol.Name.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MainForm m = (MainForm)MdiParent;
            //foreach (Control trol in m.Controls)
            //{
            //    if (trol is Panel)
            //    {
            //        toolTip.Hide(trol);
            //    }
            //}
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            //Control c = null; ;
            //MainForm m = (MainForm)MdiParent;
            //foreach (Control trol in m.Controls)
            //{
            //    if (trol is Panel)
            //    {
            //        c = trol;
            //        //ToolTip toolTip = new ToolTip();

            //        //int times = 3000000;
            //        //string ly = "aaaaadd 的";

            //        //toolTip.IsBalloon = true;// 不显示为气泡弹窗，气泡的箭头会乱跑
            //        //toolTip.ToolTipIcon = ToolTipIcon.Info;
            //        //toolTip.SetToolTip(c, "");
            //        //toolTip.ShowAlways = true;// 总是显示
            //        //toolTip.UseAnimation = true;
            //        //toolTip.UseFading = true;

            //        ////toolTip.Hide(trol);
            //        //toolTip.Show(ly, c, c.Width / 2, c.Height / 2, times);
            //    }
            //}
            //c = this;
            //    int times = 3000000;
            //    string ly = "aaaaadd 的";

            //    toolTip.IsBalloon = true;// 不显示为气泡弹窗，气泡的箭头会乱跑
            //    toolTip.ToolTipIcon = ToolTipIcon.Info;
            //    toolTip.SetToolTip(c, "");
            //    toolTip.ShowAlways = true;// 总是显示
            //    toolTip.UseAnimation = true;
            //    toolTip.UseFading = true;

            //    //toolTip.Hide(trol);
            //    toolTip.Show(ly, c, c.Width / 2, c.Height / 2, times);

            //Thread thread = new Thread(ThreadFuntion);
            //thread.IsBackground = true;
            //thread.Start();
            //TestDelegate d = Test;
            //d.BeginInvoke((Control)label1, null, null);
            WaitFormService.Show();
            WaitFormService.SetText("d，请稍候…………");

            wcoding.wcodingfinance wcoding = new newfeixiang.wcoding.wcodingfinance();
            DataTable dt = wcoding.wcodingfinancetreesql4(begin_class.allmax, "1", 1, "");
            WaitFormService.SetText("我是第二个，请稍候…………");
            dt = wcoding.wcodingfinancetreesql4(begin_class.allmax, "1", 1, "");
            WaitFormService.SetText("我是第三个哟我是第三个哟我是第三个哟我是第三个哟，请稍候…………");
            dt = wcoding.wcodingfinancetreesql4(begin_class.allmax, "1", 1, "");
            dt = wcoding.wcodingfinancetreesql4(begin_class.allmax, "1", 1, "");
            dt = wcoding.wcodingfinancetreesql4(begin_class.allmax, "1", 1, "");
            dt = wcoding.wcodingfinancetreesql4(begin_class.allmax, "1", 1, "");
            WaitFormService.Close();
            //toolTip.Hide(this);
            qg_grid_tree1.DataSource = dt;
        }








        //结束
    }
}
