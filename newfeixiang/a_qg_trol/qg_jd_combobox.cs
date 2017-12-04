using System;
using System.Drawing;
using System.Windows.Forms;

namespace newfeixiang.a_qg_trol
{
    public partial class qg_jd_combobox : ComboBox
    {
        //确保刚加载时没有选中值
        private bool _flag = true;
        public bool flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        public qg_jd_combobox()
        {

           InitializeComponent();
            DropDownStyle = ComboBoxStyle.DropDown;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void qg_jd_combobox_Enter(object sender, EventArgs e)
        {
            flag = false;
            BackColor = Color.LightCyan; //当textBox1获得焦点时，背景色变为LightCyan（淡蓝绿色）
        }

        private void qg_jd_combobox_Leave(object sender, EventArgs e)
        {
            BackColor = Color.White; //当textBox1失去焦点时，背景色恢复为White(白色)
        }

        private void qg_jd_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flag)
            { SelectedIndex = -1; }
        }

        private void qg_jd_combobox_DisplayMemberChanged(object sender, EventArgs e)
        {
            if (_flag)
            { SelectedIndex = -1; }
        }
    }
}
