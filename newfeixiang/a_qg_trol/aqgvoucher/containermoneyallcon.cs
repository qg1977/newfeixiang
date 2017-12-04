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
    public partial class containermoneyallcon : UserControl
    {
        public containermoneyallcon()
        {
            InitializeComponent();
            //this.SuspendLayout();
            //auto();

            //this.ResumeLayout(false);
        }

        private void containermoneyallcon_Load(object sender, EventArgs e)
        {
            Width = containermoneyall1.Width;
            Height = containermoneyall1.Height * 5+1;
            auto();
        }

        private void auto()
        {
            int heighttemp = containermoneyall1.Height;
            containermoneyall1.Left = 0;
            containermoneyall1.Top = 0;
            containermoneyall2.Left = containermoneyall1.Left;
            containermoneyall2.Top = containermoneyall1.Top + heighttemp;
            containermoneyall3.Left = containermoneyall1.Left;
            containermoneyall3.Top = containermoneyall2.Top + heighttemp;
            containermoneyall4.Left = containermoneyall1.Left;
            containermoneyall4.Top = containermoneyall3.Top + heighttemp;
            containermoneyall5.Left = containermoneyall1.Left;
            containermoneyall5.Top = containermoneyall4.Top + heighttemp;
        }


        //本控件第一次生成时的一些值 
        public void auto_set_value()
        {
            try
            {
                foreach(Control trol in Controls)
                {
                    if (trol is containermoneyall)
                    {
                        ((containermoneyall)trol).auto_set_value();
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
