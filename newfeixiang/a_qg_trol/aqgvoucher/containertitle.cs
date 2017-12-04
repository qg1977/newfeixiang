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
    public partial class containertitle : UserControl
    {
        int containertextboxcount = 15; // 容器中包含的textbox的个

        public containertitle()
        {
            InitializeComponent();
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

        private void containertitle_Load(object sender, EventArgs e)
        {
            Height = 40;
            Width = 200;
        }

        private void containertitle_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                List<string> colorList = new List<string>()
            { "#008081","#c0c0c0","#FF8080","#008081","#c0c0c0","#FF8080","#008081","#808080","#FF8080","#008081","#808080","#FF8080","#FF0000","#808080"};



                int containerwidthtemp =  (Width - 2) / containertextboxcount;// 每一个textbox应该的宽度
                //int boxwidth = 0;// 每过一个textbox，containertextboxwidth就增加一个textbox的宽度

                label1all.Top = 5;
                label1all.Left = (Width - label1all.Width) / 2;

                int lineheight = label1all.Top + label1all.Height + 1;//中间一条横线的高度
                Point p1=new Point(1, label1all.Top + label1all.Height + 1);
                Point p2= new Point(Width-2, lineheight);
                Color c = Color.Black;
                create_line(p1, p2, c, 1);

                int contarinerlabelheight = this.label1all.Top+label1all.Height + 5;//"亿万"的top

                foreach (Control control in this.Controls)
                {
                    if (control is Label && control.Name!= "label1all")
                    {
                        //根据text的名称判断该按钮在“text_name_all”中的排序位置
                        string text_name = control.Name.ToString();
                        //int text_i = text_name_all.IndexOf(text_name);
                        int text_i = text_name.Trim().Replace("label", "").ToInt();
                        //int tag_text_i = text_i - 3;
                        //if (tag_text_i >= 0) { tag_text_i = tag_text_i + 1; }

                        control.Top = contarinerlabelheight;
                        //control.Width = containerwidthtemp - 2;
                        //control.Height = containerwidthtemp;
                        control.Left = (containertextboxcount - text_i) * containerwidthtemp+1 ;

                         p1 = new Point((text_i - 1) * containerwidthtemp + control.Width+2, lineheight);
                         p2 = new Point((text_i - 1) * containerwidthtemp + control.Width +2, Height);
                        if (text_i <= colorList.Count)
                        {
                            string temp = colorList[text_i - 1];
                            c = System.Drawing.ColorTranslator.FromHtml(temp);
                            int cx = 1;
                            //“元”的后面的划线为粗线
                            if (text_i == containertextboxcount - 2) { cx = 2; }
                            create_line(p1, p2, c, cx);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        public void set_bt(string btstring)
        {
            label1all.Text = btstring;
        }

        //结束
        }
}
