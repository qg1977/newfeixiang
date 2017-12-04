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
    public partial class containerinto : UserControl
    {

        int containertextboxheighttemp = 24;// 默认的Texbox的高度

        public int containertextboxcount = 15;// 容器中包含的textbox的个数

        string public_value = "0000000000000.00";
        string tag_string = "0000000000000.00";

        public enum ColorEnum
        {
            Teal, LightGray, LightCoral, DeepSkyBlue, SlateGray, LightSalmon, DarkCyan, Gray, Salmon, Red, Silver

        };

        public containerinto()
        {
            InitializeComponent();
            BackColor = Color.White;

        }

        private void containerinto_Load(object sender, EventArgs e)
        {
            this.Tag = "0";// public_value;

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



        private void containerinto_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                List<string> colorList = new List<string>()
            { "#008081","#c0c0c0","#FF8080","#008081","#c0c0c0","#FF8080","#008081","#808080","#FF8080","#008081","#808080","#FF8080","#FF0000","#808080"};

                Height = 45;
                Width = 198;

                int containertextboxtoptemp = (this.Height - containertextboxheighttemp) / 2;// 设置的textbox的top值

                int containerwidthtemp = (this.Width - 2) / containertextboxcount;// 每一个textbox应该的宽度


                foreach (Control control in this.Controls)
                {
                    if (control is containertextbox)
                    {
                        //根据text的名称判断该按钮在“text_name_all”中的排序位置
                        string text_name = control.Name.ToString();
                        //int text_i = text_name_all.IndexOf(text_name);
                        int text_i = text_name.Trim().Replace("containertextbox", "").ToInt();
                        //int tag_text_i = text_i - 3;
                        //if (tag_text_i >= 0) { tag_text_i = tag_text_i + 1; }

                        control.Top = containertextboxtoptemp;
                        control.Width = containerwidthtemp - 2;
                        control.Height = containerwidthtemp;
                        control.Left = (containertextboxcount - text_i) * containerwidthtemp + 1;


                        control.TabIndex = Math.Abs(text_i - containertextboxcount);
                        int tag_text_i = control.TabIndex;
                        //////if (tag_text_i >= containertextboxcount - 2) { tag_text_i = tag_text_i + 1; }
                        control.Tag = tag_text_i;

                        //((containertextbox)control).Text = control.Tag.ToString();

                        Point p1 = new Point((text_i - 1) * containerwidthtemp + control.Width + 1, 0);
                        Point p2 = new Point((text_i - 1) * containerwidthtemp + control.Width + 1, Height);

                        if (text_i <= colorList.Count)
                        {
                            string temp = colorList[text_i - 1];
                            Color c = System.Drawing.ColorTranslator.FromHtml(temp);
                            int cx = 1;
                            //“元”的后面的划线为粗线
                            if (text_i == containertextboxcount - 2) { cx = 1; }
                            create_line(p1, p2, c, cx);
                        }
                    }

                }
                get_TAG();
                //if (Tag.ToString().ToDouble() != 0)
                //{ get_TAG(); }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }


        private void containerinto_Leave(object sender, EventArgs e)
        {
            //get_TAG();
            //if (Tag.ToString().ToDouble() != 0)
            //{ get_TAG(); }
            //Tag = tag_string;
            containermoneyall moneyall = (containermoneyall)Parent;
            foreach (Control control in moneyall.Controls)
            {
                if (control is containerinto)
                {
                    if (control.Name != Name)
                    {
                        if (control.Tag.ToString().ToDouble() != 0)
                        {
                            this.Tag = "0";// public_value;

                        }
                    }
                }
            }
            get_TAG();

            if (this.Tag.ToString().ToDouble() < 0)
            {
                foreach (Control control in Controls)
                {
                    if (control is containertextbox)
                    {
                        ((containertextbox)control).ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                foreach (Control control in Controls)
                {
                    if (control is containertextbox)
                    {
                        ((containertextbox)control).ForeColor = Color.Black;
                    }
                }
            }

        }

        public void set_TAG_x(int wz,string set_value)
        {
            try
            {
                string[] vlaue_list = new string[containertextboxcount+1];
                vlaue_list[containertextboxcount - 2] = ".";
                vlaue_list[containertextboxcount - 1] = "0";
                vlaue_list[containertextboxcount] = "0";
                foreach (Control control in Controls)
                {
                    containertextbox textbox = (containertextbox)control;
                    if (textbox.Tag.ToString().NotIsNullOrEmpty() && textbox.Tag.ToString().IsInt())
                    {
                        int box_tag = textbox.Tag.ToString().ToInt();
                        if (box_tag> containertextboxcount - 3) { box_tag = box_tag + 1; }
                        vlaue_list[box_tag] = textbox.Text.ToString();
                    }
                }

                string value_new = "";
                foreach(string s in vlaue_list)
                {
                    if (s.NotIsNullOrEmpty() && s.Trim()!="")
                    { value_new = value_new.Trim() + s.Trim(); }
                }
                this.Tag = add_xsd(tag_to_string(value_new));


                containermoneyall all = ((containermoneyall)Parent);
                foreach (Control control in all.Controls)
                {
                    if (control.Name == "containeredit1")
                    {
                        ((containeredit)control).Text = this.Tag.ToString() + " / " + this.Tag.ToString().ToLong().ToString()+" / "+ tag_to_string(value_new).Trim();


                    }
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        public void set_TAG(int wz, string set_value)
        {
            try
            {
                string public_value_temp = tag_to_string(this.Tag.ToString());// "000000000000000";
                //// 将Tag的值补充为15位（不带小数点）字符串
                //string tag_public_values = tag_to_string();

                if (set_value == ".")
                {
                    //如果点击小数点的话，直接跳到“角”位上
                    foreach (Control control in Controls)
                    {
                        containertextbox textbox = (containertextbox)control;
                        if (textbox.Tag.ToString().NotIsNullOrEmpty() && textbox.Tag.ToString().IsInt())
                        {
                            int tag_int = textbox.Tag.ToString().ToInt();

                            if (tag_int == containertextboxcount - 2)
                            { textbox.Focus(); }

                        }
                    }
                    //如果点击小数点的话，直接跳到“角”位上  
                }
                else
                {

                    public_value_temp = public_value_temp.Substring(0, wz) + set_value.Trim() + public_value_temp.Substring(wz + 1);

                    this.Tag = public_value_temp;
                    foreach (Control control in Controls)
                    {
                        containertextbox textbox = (containertextbox)control;
                        if (textbox.Tag.ToString().NotIsNullOrEmpty() && textbox.Tag.ToString().IsInt())
                        {
                            //遍历所有的Textbox
                            int textbox_tag = textbox.Tag.ToString().ToInt();
                            if (textbox_tag < wz)
                            {
                                public_value_temp = public_value_temp.Substring(0, wz) + set_value.Trim() + public_value_temp.Substring(wz + 1);
                            }
                        }
                    }
                    //将public_valuea_temp加上小数点，再拷贝到tag
                    this.Tag = add_xsd(public_value_temp);
                    //get_TAG();
                }
               

                containermoneyall all = ((containermoneyall)Parent);
                foreach (Control control in all.Controls)
                {
                    if (control.Name == "containeredit1")
                    {
                        ((containeredit)control).Text = this.Tag.ToString() + " " + this.Tag.ToString().ToLong().ToString();


                    }
                }

            }

            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        //在直接输入的数字的情况下，是没有小数点的，则在将值转入tag里时需要加上小数点
        #region
        private string add_xsd(string public_value)
        {
            string xsd_string = public_value;
            //int xsd_int = 2;//小数点的位置
;
            if (public_value.Length>2)
            {
                xsd_string = public_value.Substring(0, public_value.Length - 2) + "." + public_value.Substring(public_value.Length - 2, 2);
            }
            
            return xsd_string;
        }

        #endregion

        //将传递进来的一个数修改成为15位的（不带小数点）的字符串
        public string tag_to_string(string tag_values)
        {
            string tag_value_string = "";
            try
            {
                

                if (!tag_values.ToString().IsDecimal()) { MessageBox.Show(tag_values.ToString() + "请输入正确的数字！"); return ""; }

                string tag_string = tag_values.ToString().ToDecimal().ToString();
                #region 整数补齐
                long top_int = tag_string.ToString().ToLong();//tag的整数的大小
                string top_tag = "";
                for (int i = top_int.ToString().Length; i < containertextboxcount - 2; i++)
                {
                    top_tag = "0" + top_tag.Trim();
                }
                top_tag = top_tag.Trim() + top_int.ToString().Trim();
                #endregion
                //MessageBox.Show(top_int.ToString()+" / "+ tag_values + " / " + top_tag);
                #region 小数补齐
                string bottom_tag = "";//tag的小数
                string[] sArray = tag_string.Split('.');
                if (sArray.Length > 1)
                {
                    string bottom_tag_temp = sArray[1];
                    Console.Write("bottom_tag_temp=" + bottom_tag_temp + " < br>");

                    if (bottom_tag_temp.Trim().Length < 2)
                    {
                        for (int i = bottom_tag_temp.Trim().Length; i < 2; i++)
                        { bottom_tag = "0" + bottom_tag.Trim(); }
                        bottom_tag = bottom_tag_temp.Trim() + bottom_tag.Trim();
                    }
                    //如果传递的小数的位数超过2位，则直接截取前2位的小数
                    else
                    { bottom_tag = bottom_tag_temp.Substring(0, 2); }
                }
                //如果传递的参数没有小数的话
                else { bottom_tag = "00"; }
                #endregion

                //this.Tag = top_tag.Trim() +"."+ bottom_tag.Trim();
                tag_value_string= top_tag.Trim() + bottom_tag.Trim(); 

                //MessageBox.Show("tag的值：" + this.Tag.ToString() + " / 整数的值：" + top_tag.ToString() + " / 小数的值：" + bottom_tag.ToString()+" / tag转换的值为："+ tag_value_string);

                
            }

            catch (Exception ex)
            {
                ex.errormess();
            }
            return tag_value_string;
        }

        public void get_TAG()
        {
            try
            {

                //if (!this.Tag.ToString().IsDecimal()) { MessageBox.Show(this.Tag.ToString() + "请输入正确的数字！"); return; }

                // 将Tag的值补充为15位（不带小数点）字符串
                string tag_public_values= tag_to_string(this.Tag.ToString());
                //MessageBox.Show(this.Tag.ToString()+" / "+tag_public_values);
                bool l_jytt = true;
                if (this.Tag.ToString().ToDecimal() == 0) { l_jytt = false; }

                int begin_i = 0;//从15位字符串第一位开始往后顺，第一个不为0的数是开始的位置
                for(int i=0;i< containertextboxcount;i++)
                {
                    if (tag_public_values.Trim().Substring(i, 1) != "0")
                    {
                        begin_i = i;
                        break;
                    }
                }
                //MessageBox.Show("是否为0:"+l_jytt.ToString()+" / 开始截取的位置："+ begin_i.ToString());
                foreach (Control control in Controls)
                {
                    if (control is containertextbox)
                    {
                        containertextbox textbox = (containertextbox)control;
                        if (textbox.Tag.ToString().NotIsNullOrEmpty() && textbox.Tag.ToString().IsInt())
                        {
                            int textbox_tag_int = textbox.Tag.ToString().ToInt();//当前的textbox的tag值

                            if (textbox_tag_int >= begin_i && l_jytt)
                            {
                                //MessageBox.Show("tag_public_values的值：" + tag_public_values + " / 开始截取的位置：" + textbox_tag_int.ToString());
                                textbox.Text = tag_public_values.Trim().Substring(textbox_tag_int, 1);// this.Tag.ToString().Substring(tag_int, 1);
                            }
                            else
                            { textbox.Text = ""; }
                        }
                    }
                }


                        // bool l_jytt = true;
                        //if (this.Tag.ToString().ToDecimal()==0) { l_jytt = false; }

                        // long top_int = tag_string.ToString().ToLong();

                        // int length_int = top_int.ToString().Length;

                        // foreach (Control control in Controls)
                        // {
                        //     if (control is containertextbox)
                        //     {
                        //         containertextbox textbox = (containertextbox)control;
                        //         if (textbox.Tag.ToString().NotIsNullOrEmpty() && textbox.Tag.ToString().IsInt())
                        //         {
                        //             int tag_int = textbox.Tag.ToString().ToInt();

                        //             int wz_jytt = Tag.ToString().Trim().Length - 2 - 1 - length_int - 1;

                        //             //MessageBox.Show(Tag.ToString().Trim().Length.ToString() + "  " + tag_int.ToString() + "  " + wz_jytt.ToString());
                        //             if (wz_jytt < tag_int && l_jytt)
                        //             {
                        //                 textbox.Text = this.Tag.ToString().Substring(tag_int, 1);
                        //             }
                        //             else
                        //             { textbox.Text = ""; }

                        //         }
                        //     }
                        // }
            }

            catch (Exception ex)
            {
                ex.errormess();
            }
        }


        private void containerinto_Enter(object sender, EventArgs e)
        {

        }


        //结束
    }
}
