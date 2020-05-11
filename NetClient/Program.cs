using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NetClient
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
            System.Threading.Mutex run = new System.Threading.Mutex(true, "single_Client", out runone);
            if (runone)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frm_NetClient_Main());
            }
            else
            {
                //MessageBox.Show("已经运行了一个实例！");
            }
        }
    }
}
