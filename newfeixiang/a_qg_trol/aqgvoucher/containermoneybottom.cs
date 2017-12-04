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
    public partial class containermoneybottom : UserControl
    {
        public containermoneybottom()
        {
            InitializeComponent();
        }




        private void containermoneybottom_Load(object sender, EventArgs e)
        {
            Height = containerinto1.Height + 3;
            Width = 763;
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



        private void containermoneybottom_Paint(object sender, PaintEventArgs e)
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, Height);
            Color c = Color.Blue;
            create_line(p1, p2, c, 1);

            p1 = new Point(0, 0);
            p2 = new Point(Width, 0);
            create_line(p1, p2, c, 2);

            p1 = new Point(0, Height-1);
            p2 = new Point(Width, Height-1);
            create_line(p1, p2, c, 1);

            p1 = new Point(Width-1, 0);
            p2 = new Point(Width-1, Height);
            create_line(p1, p2, c, 1);

            containerinto2.Top = 2;
            containerinto2.Left = Width - containerinto2.Width - 2;
            p1 = new Point(containerinto2.Left - 3, 0);
            p2 = new Point(containerinto2.Left - 3, Height);
            create_line(p1, p2, c, 1);
            containerinto1.Top = 1;
            containerinto1.Left = containerinto2.Left - containerinto2.Width - 4;
            p1 = new Point(containerinto1.Left - 1, 0);
            p2 = new Point(containerinto1.Left - 1, Height);
            create_line(p1, p2, c, 1);

            label1.Top = (Height - label1.Height) / 2;
        }


        //本控件第一次生成时的一些值 
        public void auto_set_value()
        {
            try
            {

            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }
        //结束
    }
}
