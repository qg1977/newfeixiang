using newfeixiang.a_GlobalClass;
using System;
using System.Windows.Forms;

namespace newfeixiang
{
    public partial class passs :a_qg_trol.qg_form
    {
        public passs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con_sql.allczy_user.strUsrId = "111";
            //allczy_userinfo.allczy_user.strUsrId = "111";
            //allczy_userinfo.allczy_user.strUsrName = "操作员";
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void qg_button1_Click(object sender, EventArgs e)
        {
            Form two = new two();
            two.Owner = this;
            two.ShowDialog();

        }

        private void qg_button2_Click(object sender, EventArgs e)
        {
            Form only_text = new only_text();
            only_text.Owner = this;
            only_text.ShowDialog();
        }

        private void passs_Load(object sender, EventArgs e)
        {
            //Height = 700;
        }
    }
}
