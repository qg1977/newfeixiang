using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace newfeixiang.a_qg_trol.aqgvoucher
{
    public partial class containerselect : a_qg_trol.qg_combobox
    {
        public containerselect()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void containerselect_Leave(object sender, EventArgs e)
        {

        }

        private void containerselect_SelectedValueChanged(object sender, EventArgs e)
        {

        }

//结束
    }
}
