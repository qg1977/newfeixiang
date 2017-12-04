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
using newfeixiang.accountacc;

namespace newfeixiang.a_qg_trol.aqgvoucher
{


    public partial class containerall : UserControl
    {
        //当前正要显示的凭证总ID
        public string accallid_new = "0";

        public containerall()
        {
            InitializeComponent();
        }

        private void containerall_Load(object sender, EventArgs e)
        {
            Width = containermoneyallcon1.Width;
            auto();
        }

        private void auto()
        {
            containertitleall1.Top = 0;
            containertitleall1.Left = 0;
            containermoneyallcon1.Top = containertitleall1.Top + containertitleall1.Height;
            containermoneyallcon1.Left = 0;
            containermoneybottom1.Top = containermoneyallcon1.Top + containermoneyallcon1.Height-1;
            containermoneybottom1.Left = 0;
            Height = containermoneybottom1.Top + containermoneybottom1.Height;
        }


        //本控件第一次生成时的一些值 
        public void auto_set_value()
        {
            try
            {
                accallid_new = ((containerallall)Parent).accallid_new;

                accountacc_one accone = new accountacc_one();
                begin_class.vouchereditdbf = accone.accountacconesqlone(accallid_new);


                foreach(Control trol in Controls)
                {
                    if (trol is containermoneyallcon)
                    {
                        ((containermoneyallcon)trol).auto_set_value();
                    }
                    if (trol is containermoneybottom)
                    {
                        ((containermoneybottom)trol).auto_set_value();
                    }
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
