using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using newfeixiang.a_sqlconn;

namespace newfeixiang.a_qg_trol.aqgvoucher
{
    public partial class containertitleall : UserControl
    {
        public containertitleall()
        {
            InitializeComponent();
        }

        private void containertitleall_Load(object sender, EventArgs e)
        {
            //BackColor = Color.FromArgb(255, 255, 255);
            Height = containertitle1.Height;
            Width = 763;

            chind_set_bt();
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

        private void containertitleall_Paint(object sender, PaintEventArgs e)
        {
            int labeltop = (Height - label1.Height) / 2;
            label1.Top = labeltop;
            label2.Top = labeltop;

            containertitle1.Height = Height - 3;
            containertitle2.Height = Height - 3;

            
            containertitle2.Top = 1;
            containertitle2.Left = Width - containertitle2.Width-1;
            Point p1 = new Point(containertitle2.Left-2, 0);
            Point p2 = new Point(containertitle2.Left-2, Height);
            Color c = Color.Blue;
            create_line(p1, p2, c, 1);
            containertitle1.Top = 1;
            containertitle1.Left = containertitle2.Left - containertitle2.Width-2;
            p1 = new Point(containertitle1.Left -1, 0);
            p2 = new Point(containertitle1.Left -1, Height);
            create_line(p1, p2, c, 1);


             p1 = new Point(0, 0);
             p2 = new Point(Width, 0);

            create_line(p1, p2, c, 1);

            p1 = new Point(0, 0);
            p2 = new Point(0, Height);
            create_line(p1, p2, c, 1);

            p1 = new Point(Width-1, 0);
            p2 = new Point(Width-1, Height);
            create_line(p1, p2, c, 1);

            p1 = new Point(0, Height-1);
            p2 = new Point(Width, Height-1);
            create_line(p1, p2, c, 2);

            label1.Top = (Height - label1.Height) / 2;
            label1.Left = (188 - label1.Width) / 2;

            int line2_left = 188;//竖向第二条 线的位置，可定位

            p1 = new Point(line2_left, 0);
            p2 = new Point(line2_left, Height);
            create_line(p1, p2, c, 1);
            //MessageBox.Show(containertitle1.Left.ToString());
            label2.Top = label1.Top;
            label2.Left = line2_left + (containertitle1.Left - line2_left - label2.Width) / 2;
        }


        private void chind_set_bt()
        {
            foreach(Control trol in Controls)
            {
                if (trol.Name=="containertitle1")
                {
                    ((containertitle)trol).set_bt("借方金额");
                }
                if (trol.Name == "containertitle2")
                {
                    ((containertitle)trol).set_bt("贷方金额");
                }
            }
        }

        //结束
    }
}
