using System;
using System.Windows.Forms;

namespace newfeixiang
{
    static class Program
    {


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //System.Threading.Mutex mutex = new System.Threading.Mutex(false, "ThisShouldOnlyRunOnce");
            //bool Running = !mutex.WaitOne(0, false);
            //if (!Running)
            //{
            //    //Application.Run(new Login());
            //    passs login = new passs();
            //    if (System.Windows.Forms.DialogResult.Cancel == login.ShowDialog())
            //    {
            //        return;
            //    }
            //    MainForm main = new MainForm();
            //    main.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("程序已启动！");
            //}

        }
    }
}
