using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool runone;
            System.Threading.Mutex run = new System.Threading.Mutex(true, "single_Server", out runone);
            if (runone)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frm_NetServer_Main());
            }
            else
            {
               // MessageBox.Show("已经运行了一个实例！");
            }
        }
    }
}
