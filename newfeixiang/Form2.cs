using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace newfeixiang
{
    public partial class Form2 : a_qg_trol.qg_form
    {
        public DataTable dt;

        public Form2()
        {
            InitializeComponent();
        }

        int times;
        private void ExecWaitForm()
        {
            try
            {
                WaitFormService.Show();



                times++;

                for (int i = 0; i < 10000; i++)
                {
                    WaitFormService.SetText(times.ToString() + "正在执行 ，请耐心等待...." + i.ToString());

                }

                WaitFormService.Close();
                if (times == 3)
                {
                    button1.Enabled = true;
                    return;
                }
                ExecWaitForm();


            }
            catch (Exception ex)
            {
                WaitFormService.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            times = 0;
            Thread th = new Thread(new ThreadStart(this.ExecWaitForm));
            th.Start();
            button1.Enabled = false;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            qg_grid1.DataSource = dt;
            qg_grid1.AutoGenerateColumns = true;
        }
    }
}
