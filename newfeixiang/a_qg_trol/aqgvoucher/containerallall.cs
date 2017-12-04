using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using static newfeixiang.a_GlobalClass.con_sql;
using newfeixiang.a_sqlconn;

namespace newfeixiang.a_qg_trol.aqgvoucher
{
    public partial class containerallall : UserControl
    {
        //当前正要显示的凭证总ID
        public string accallid_new = "0";
        //总的凭证数量
        public int accallXH_all = 0;
        //当前是第几张凭证
        public int accallXH_new = 0;



        public containerallall()
        {
            InitializeComponent();
        }

        private void containerallall_Load(object sender, EventArgs e)
        {
            Width = containerall1.Width + 8;
            auto();

            begin_value();
            auto_set_value();
        }

        private void auto()
        {
            label1.Top = 5;
            label1.Left = (Width - label1.Width) / 2;

            label2.Left = 4;
            label2.Top = 55;
            qg_text_pjh.Top = label2.Top - 5;
            qg_text_pjh.Left = label2.Left + label2.Width + 2;
            dateTimePicker1.Top = qg_text_pjh.Top;
            dateTimePicker1.Left = (Width - dateTimePicker1.Width) / 2;

            containerall1.Left = label2.Left;
            containerall1.Top = 85;

            qg_text_spinner_fj.Top = qg_text_pjh.Top;
            qg_text_spinner_fj.Left = containerall1.Left + containerall1.Width -qg_text_spinner_fj.Width;
            label4.Top = label2.Top;
            label4.Left = qg_text_spinner_fj.Left - label4.Width -5;
            qg_text_spinner_pzh.Left = qg_text_spinner_fj.Left;
            qg_text_spinner_pzh.Top = qg_text_spinner_fj.Top - qg_text_spinner_pzh.Height - 5;
            label3.Left = label4.Left;
            label3.Top = qg_text_spinner_pzh.Top + 5;

            int conlabewidthtempall = containerall1.Width - 30 - 5 * 4 - (label_pz_1_1.Width + label_pz_1_2.Width) * 5;
            int conlabewidthtempallone = conlabewidthtempall / 4;

            label_pz_1_1.Left = 15;
            label_pz_1_1.Top = containerall1.Top + containerall1.Height + 10;
            label_pz_1_2.Left = label_pz_1_1.Left + label_pz_1_1.Width + 5;
            label_pz_1_2.Top = label_pz_1_1.Top;

            label_pz_2_1.Top = label_pz_1_1.Top;
            label_pz_2_1.Left = label_pz_1_2.Left + label_pz_1_2.Width + conlabewidthtempallone;
            label_pz_2_2.Top = label_pz_2_1.Top;
            label_pz_2_2.Left = label_pz_2_1.Left + label_pz_2_1.Width + 5;

            label_pz_3_1.Top = label_pz_1_1.Top;
            label_pz_3_1.Left = label_pz_2_2.Left + label_pz_2_2.Width + conlabewidthtempallone;
            label_pz_3_2.Top = label_pz_3_1.Top;
            label_pz_3_2.Left = label_pz_3_1.Left + label_pz_3_1.Width + 5;

            label_pz_4_1.Top = label_pz_1_1.Top;
            label_pz_4_1.Left = label_pz_3_2.Left + label_pz_3_2.Width + conlabewidthtempallone;
            label_pz_4_2.Top = label_pz_4_1.Top;
            label_pz_4_2.Left = label_pz_4_1.Left + label_pz_4_1.Width + conlabewidthtempallone;

            label_pz_5_1.Top = label_pz_1_1.Top;
            label_pz_5_1.Left = label_pz_4_2.Left + label_pz_4_2.Width + conlabewidthtempallone;
            label_pz_5_2.Top = label_pz_5_1.Top;
            label_pz_5_2.Left = label_pz_5_1.Left + label_pz_5_1.Width + 5;

            label_pz_zs.Top= label_pz_1_1.Top + label_pz_1_1.Height + 10;
            label_pz_zs.Left = label_pz_1_1.Left;

            qg_button_top.Top = label_pz_zs.Top + label_pz_zs.Height + 10;
            int commandwidthtemp = (Width - 8 * qg_button_top.Width) / 9;
            qg_button_top.Left = commandwidthtemp;
            qg_button_bottom.Top = qg_button_top.Top;
            qg_button_bottom.Left = qg_button_top.Left + qg_button_top.Width + commandwidthtemp;
            qg_button3.Top= qg_button_top.Top;
            qg_button3.Left = qg_button_bottom.Left + qg_button_bottom.Width + commandwidthtemp;
            qg_button4.Top = qg_button_top.Top;
            qg_button4.Left = qg_button3.Left + qg_button3.Width + commandwidthtemp;
            qg_button5.Top = qg_button_top.Top;
            qg_button5.Left = qg_button4.Left + qg_button4.Width + commandwidthtemp;
            qg_button6.Top = qg_button_top.Top;
            qg_button6.Left = qg_button5.Left + qg_button5.Width + commandwidthtemp;
            qg_button7.Top = qg_button_top.Top;
            qg_button7.Left = qg_button6.Left + qg_button6.Width + commandwidthtemp;
            qg_button_quit1.Top = qg_button_top.Top;
            qg_button_quit1.Left = qg_button7.Left + qg_button7.Width + commandwidthtemp;

            Height = qg_button_top.Top + qg_button_top.Height + 10;
        }

        //本控件第一次生成时的一些值 
        private void begin_value()
        {
            try
            {
                //总的凭证数量
                accallXH_all = begin_class.vouchereditdbfacc.DefaultView.ToTable(true, "ID").Rows.Count;
                if (accallXH_all<=0)
                { MessageBox.Show("没有查询到的相应凭证记录！");return; }

                accallid_new = begin_class.vouchereditdbfacc.Rows[0]["ID"].ToString();

                DataRow[] rows = begin_class.vouchereditdbfacc.Select("ID=" + accallid_new + " and 排序=1");
                accallXH_new = rows[0]["凭证总排序"].ToString().ToInt();
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        //张数、日期、凭证号等
        private void auto_set_value()
        {
            try
            {
                label_pz_zs.Text = "第" + accallXH_new.ToString().Trim() + "张/共" + accallXH_all.ToString().Trim() + "张";

                if (accallXH_new <= 1) { qg_button_top.Enabled = false; } else { qg_button_top.Enabled = true; }
                if (accallXH_new >= accallXH_all) { qg_button_bottom.Enabled = false; } else { qg_button_bottom.Enabled = true; }

                DataRow[] rows = begin_class.vouchereditdbfacc.Select("ID=" + accallid_new + " and 排序=1");
                dateTimePicker1.Value = Convert.ToDateTime(rows[0]["日期"].ToString());
                qg_text_pjh.Text = rows[0]["票据号"].ToString();
                qg_text_spinner_pzh.Text = rows[0]["凭证号"].ToString();
                qg_text_spinner_fj.Text = rows[0]["附件数"].ToString();

                int zttempid = rows[0]["状态ID"].ToString().ToInt();
                label_pz_1_2.Text = "";
                label_pz_2_2.Text = "";
                label_pz_3_2.Text = "";
                label_pz_4_2.Text = "";
                label_pz_5_2.Text = "";
                switch (zttempid)
                {
                    case 0://制单
                        break;
                    case 2://审核
                        label_pz_2_2.Text = "√";
                        break;
                    case 5://记帐
                        label_pz_3_2.Text = "√";
                        break;
                }

                foreach(Control trol in Controls)
                {
                    if (trol is containerall)
                    {
                        ((containerall)trol).auto_set_value();//执行containerall的刷新过程
                    }
                }
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }





        private void qg_button_bottom_Click(object sender, EventArgs e)
        {
            try
            {
                if (accallXH_new == accallXH_all) { MessageBox.Show("已是最后一张凭证！"); return; }

                accallXH_new = accallXH_new + 1;

                DataRow[] rows = begin_class.vouchereditdbfacc.Select("凭证总排序=" + accallXH_new.ToString());
                accallid_new = rows[0]["ID"].ToString();

                auto_set_value();
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }

        private void qg_button_top_Click(object sender, EventArgs e)
        {
            try
            {
                if (accallXH_new <= 1) { MessageBox.Show("已是第一张凭证！"); return; }

                accallXH_new = accallXH_new - 1;

                DataRow[] rows = begin_class.vouchereditdbfacc.Select("凭证总排序=" + accallXH_new.ToString());
                accallid_new = rows[0]["ID"].ToString();

                auto_set_value();
            }
            catch (Exception ex)
            {
                ex.errormess();
            }
        }


        //结束
    }
}
