using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Skin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo("skins");
            try
            {
                FileInfo[] listfile = dir.GetFiles();
                for (int i = 0; i < listfile.Length; i++)
                {
                    ListViewItem item = new ListViewItem(listfile[i].ToString());
                    item.SubItems.Add(Convert.ToString(Convert.ToDouble(listfile[i].Length) / 1000) + "KB");//大小
                    item.SubItems.Add("文件皮肤ssk");
                    item.Tag = listfile[0].FullName;//文件路径
                    item.SubItems.Add(listfile[i].LastWriteTime.ToString());//修改日期
                    if(listfile[i].Extension.Trim().ToLower()==".ssk")
                        listView1.Items.Add(item);
                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }
            listView1.Select();
            label1.Text = string.Format("皮肤总数： {0}",listView1.Items.Count);
            label2.Text = string.Format("当前皮肤： {0}",listView1.Items[0].Text);
            this.skinEngine1.SkinFile = string.Format("skins\\{0}", listView1.Items[0].Text.Trim());
        }

        private void 帮助LToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label2.Text = string.Format("当前皮肤： {0}",listView1.SelectedItems[0].Text);
                this.skinEngine1.SkinFile = string.Format("skins\\{0}", listView1.SelectedItems[0].Text.Trim());

            }
            catch (Exception)
            {
                
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("这是皮肤" + label2.Text+"的效","皮肤效果",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("想交朋友请加QQ:527143423");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value==100)
            {
                progressBar1.Value = 0;
            }
        }
    }
}
