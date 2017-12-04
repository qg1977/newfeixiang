using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using newfeixiang.a_sqlconn;

namespace newfeixiang.a_qg_trol.aqgvoucher
{
    public partial class containertextbox : TextBox
    {
        public containertextbox()
        {

            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void containertextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text.ToString().Length > 0)
                    SelectAll();

                //判断按键是不是要输入的类型。
                if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46 && e.KeyChar != 45)
                { e.Handled = true; }



                int containertextboxcount = ((containerinto)((containertextbox)sender).Parent).containertextboxcount;
                string parent_tag = ((containerinto)((containertextbox)sender).Parent).Tag.ToString();
                //将tag的值转换成15位(不带小数点)的字符串
                parent_tag = ((containerinto)((containertextbox)sender).Parent).tag_to_string(parent_tag);


                int this_tag = Tag.ToString().ToInt();
                //MessageBox.Show("值："+ parent_tag+"   /   "+this_tag.ToString());

                string parent_tag_temp = parent_tag.Substring(0, this_tag + 1);
                bool not_0_jytt = true;
                if (parent_tag_temp.ToLong() == 0) { not_0_jytt = false; }
                ////MessageBox.Show(parent_tag_temp + "  " + parent_tag_temp.ToLong().ToString() + "  " + not_0_jytt.ToString());
                //输入为负号时，只能输入一次且只能输入一次
                if (e.KeyChar == 45 &&
                            (
                            ((containertextbox)sender).Tag.ToString().ToInt() > containertextboxcount - 2//不能是小数位
                            ||
                            parent_tag.IndexOf("-") >= 0//不能已经有"-"
                            ||
                            not_0_jytt//"-"前面必须全是0,不能有其它数字
                            )
                    )
                    //{ e.Handled = true; }

                    if (e.KeyChar == (char)Keys.Back) { Text = "0"; }

                if (!e.Handled)
                {

                    SendKeys.Send("{tab}");
                }
            }

            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void containertextbox_Enter(object sender, EventArgs e)
        {
            ImeMode = System.Windows.Forms.ImeMode.Disable;//获得焦点时,设置为英文
            SelectAll();
        }

        private void containertextbox_Leave(object sender, EventArgs e)
        {
            ImeMode = System.Windows.Forms.ImeMode.NoControl;
            //if (!Simple_all.isNumberic(this.Text.ToString()) && (Text.ToString() != "-"))
            //{ this.Text = "0"; }
            if (Text.ToString().Trim() != "")
            {
                ((containerinto)Parent).set_TAG_x(Tag.ToString().ToInt(), Text);
            }
        }

        private void containertextbox_MouseUp(object sender, MouseEventArgs e)
        {
            //如果鼠标左键操作并且标记存在，则执行全选             
            if (e.Button == MouseButtons.Left)
            {
                SelectAll();
            }
        }

        private void containertextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                SendKeys.Send("{tab}");
            }
            if (e.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{tab}");
            }
        }


        //结束
    }
}
