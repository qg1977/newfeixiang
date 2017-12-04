using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using newfeixiang.a_sqlconn;

namespace newfeixiang.a_qg_trol
{
    public partial class qg_radio_group : UserControl
    {
        public qg_radio_group()
        {
            InitializeComponent();
        }

        private void qg_radio_group_Load(object sender, EventArgs e)
        {
            auto_bj();
            foreach (System.Windows.Forms.Control control in this.panel1.Controls)
            {
                if (control is RadioButton)
                {
                    rd_click(control, null);
                }
            }
        }

        private void auto_bj()
        {
            try
            {
                //下属的radio的text
                string[] name_list = AccessibleDescription.ToString().Split(',');
                int name_list_sum = name_list.Length;

                string rad_sum_string = "1";

                if (!string.IsNullOrEmpty(Tag.ToString()))
                {
                    rad_sum_string = Tag.ToString();
                }
                if (!a_sqlconn.Simple_all.isNumberic(rad_sum_string))
                { rad_sum_string = "1"; }

                int rad_sum = Convert.ToInt32(rad_sum_string);

                int rad_left = 0;
                for (int i = 1; i <= rad_sum; i++)
                {
                    RadioButton rd = new RadioButton();
                    if (i == 1)
                    { rd.Checked = true; }
                    rd.AutoSize = true;
                    rd.Left = rad_left + 5;
                    rd.Top = 5;
                    if (i <= name_list_sum)
                    {
                        rd.Text = name_list[i - 1];
                    }
                    else
                    {
                        rd.Text = "按钮" + i.ToString();
                    }
                    rd.Tag = i.ToString();
                    rd.Click += new EventHandler(rd_click);   //用代码动态连接事件
                    panel1.Controls.Add(rd);

                    rad_left = rad_left + rd.Width + 20;

                    panel1.Height = rd.Height + 10;
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void rd_click(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)(sender); //这么一转换就知道是哪个label点击了
            if (rd.Checked)
            {
                Tag = rd.Tag;
                AccessibleDescription = rd.Text;
            }
         //是001 label

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //使用红色虚线绘制边框  
            Pen pen1 = new Pen(Color.Red, 1);
            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen1.DashPattern = new float[] { 4f, 2f };
            e.Graphics.DrawRectangle(pen1, 0, 0, this.panel1.Width - 1, this.panel1.Height - 1);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            //改变窗体大小时，panel1同步
            panel1.Refresh();
        }
    }
}
