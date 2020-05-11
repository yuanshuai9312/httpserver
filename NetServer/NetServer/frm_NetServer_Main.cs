using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using Microsoft.Win32;
using System.IO;


namespace NetServer
{
    public partial class frm_NetServer_Main : Form
    {


        #region 定义函数的委托
        /// <summary>
        /// 定义监听函数委托
        /// </summary>
        public delegate void D_ThreadRec();

        /// <summary>
        /// 定义利用委托显示界面信息
        /// </summary>
        /// <param name="str"></param>
        public delegate void D_UpdateUI_Log(string str);

        #endregion


        #region 定义公共变量
        /// <summary>
        /// 是否监听
        /// </summary>
        private bool isLis;
        /// <summary>
        /// 定义一个连接
        /// </summary>
        Socket ServerSocket;
        #endregion

        /// <summary>
        /// 定义个一个属性来修改ListBox_LogMsg控件，显示信息
        /// </summary>
        public string SetListBoxMsg
        {
            set
            {
                this.ListBox_LogMsg.Items.Add(value);
                ListBox_LogMsg.TopIndex = ListBox_LogMsg.Items.Count - 1;
            }
        }


        public frm_NetServer_Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置文件保存目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Text_SaveBrowser_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Text_SavePath.Text = folderBrowserDialog1.SelectedPath.ToString();
                StartListent.Enabled = true;
            }
        }

        /// <summary>
        /// 启动监听服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartListent_Click(object sender, EventArgs e)
        {
            StartListentServer();
        }
        /// <summary>
        /// 启动监听服务
        /// </summary>
        public void StartListentServer()
        {

            isLis = true;
            Bt_SaveBrowser.Enabled = false;
            StopListent.Enabled = true;
            StartListent.Enabled = false;
            DelFileTime.Enabled = false;
            Check_SaveFileAS.Enabled = false;
            Text_DelFileTime.Enabled = false;
            Text_ServerIP.Enabled = false;
            Text_ServerPort.Enabled = false;

            if (Check_SaveFileAS.Checked)
            {
                ListBox_LogMsg.Items.Add("********文件会按接收的时间保存，并只保留近" + Text_DelFileTime.Value.ToString() + "天的文件********");
            }
            else
            {
                ListBox_LogMsg.Items.Add("********文件会按传输的原始文件名保存，并覆盖已存在的同名文件********");
            }

            Control.CheckForIllegalCrossThreadCalls = false;

            D_ThreadRec _D_ThreadRec = new D_ThreadRec(ThreadRec);
            _D_ThreadRec.BeginInvoke(null, null);

        }



        /// <summary>
        /// 停止监听服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopListent_Click(object sender, EventArgs e)
        {
            isLis = false;
            Check_SaveFileAS.Enabled = true;
            Text_DelFileTime.Enabled = true;
            DelFileTime.Enabled = true;
            Text_ServerIP.Enabled = true;
            Text_ServerPort.Enabled = true;
            ServerSocket.Close();

            Bt_SaveBrowser.Enabled = true;

            StopListent.Enabled = false;

            if (Text_SavePath.Text != "")
            {
                StartListent.Enabled = true;
            }
        }

        #region 启动监听服务
        /// <summary>
        /// 监听服务函数
        /// </summary>
        private void ThreadRec()
        {
            try
            {
                int port = Convert.ToInt32(Text_ServerPort.Value);
                string strIp = Text_ServerIP.Text;

                IPAddress ip = IPAddress.Parse(strIp);
                IPEndPoint ipe = new IPEndPoint(ip, port);

                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                ServerSocket.Bind(ipe);
                ServerSocket.Listen(10);

                this.BeginInvoke(new D_UpdateUI_Log(UpdateUI_Log), new object[] { System.DateTime.Now + ":服务器开始监听" + Text_ServerPort.Value.ToString()+ "端口！" });
                while (true)
                {
                    // ListBox_LogMsg.Items.Add("开始监听!");
                    if (isLis == true)
                    {
                        try
                        {
                            //阻塞监听至到有新的连接
                            Socket temp = ServerSocket.Accept();

                            IPEndPoint clientip = (IPEndPoint)temp.RemoteEndPoint;
                            //如果连接上
                            if (temp.Connected)
                            {
                                //显示客户端连接状态
                                this.BeginInvoke(new D_UpdateUI_Log(UpdateUI_Log), new object[] { "客户端[" + clientip.Address.ToString() + "]在" + System.DateTime.Now + "连接到服务器！" });
                                StartThreads startThreads = new StartThreads(temp, this, Text_SavePath.Text.Trim(), Check_SaveFileAS.CheckState.ToString());
                                //.....................
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message != "一个封锁操作被对 WSACancelBlockingCall 的调用中断。")//断开socket时阻塞监听的报错提示
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                    else
                    {

                        ServerSocket.Close();
                        this.BeginInvoke(new D_UpdateUI_Log(UpdateUI_Log), new object[] { System.DateTime.Now + ":停止监听服务！" });
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.BeginInvoke(new D_UpdateUI_Log(UpdateUI_Log), new object[] { ex.Message });
            }
        }
       

        #endregion


        /// <summary>
        /// 更新界面信息
        /// </summary>
        /// <param name="str"></param>
        public void UpdateUI_Log(string str)
        {
            ListBox_LogMsg.Items.Add(str);
            ListBox_LogMsg.TopIndex = ListBox_LogMsg.Items.Count - 1;
            if (ListBox_LogMsg.Items.Count > 200)
            {
                ListBox_LogMsg.Items.Clear();
            }
        }

        private void frm_NetServer_Main_Load(object sender, EventArgs e)
        {

           
            string XmlFilePath = Application.StartupPath + "\\BackFilePath.xml";

            if (System.IO.File.Exists(XmlFilePath))
            {

                //创建XML实例
                XmlDocument xmlDoc = new XmlDocument();
                //加载XML文件
                xmlDoc.Load(XmlFilePath);

                //设置要查询的节点
                string XmlPathNode = "//ConfigInfo/AutoStart";
                //获取查询节点的属性值
                if (xmlDoc.SelectSingleNode(XmlPathNode).Attributes["State"].Value.ToString() == "True")
                {
                    
                    AutoStart.Checked = true;

                    Text_SavePath.Text = xmlDoc.SelectSingleNode("//ConfigInfo/BackFilePath").Attributes["Path"].Value.ToString();
                    Text_ServerIP.Text = xmlDoc.SelectSingleNode("//ConfigInfo/ServerIP").Attributes["IP"].Value.ToString();
                    Text_ServerPort.Value = Convert.ToInt32(xmlDoc.SelectSingleNode("//ConfigInfo/ServerPort").Attributes["Port"].Value);


                    if (xmlDoc.SelectSingleNode("//ConfigInfo/SaveAllFileAndDelfile").Attributes["SaveState"].Value.ToString() == "True")
                    {
                        Check_SaveFileAS.Checked = true;
                    }
                    else
                    {
                        Check_SaveFileAS.Checked = false;
                    }
                    
                    Text_DelFileTime.Value = Convert.ToInt32(xmlDoc.SelectSingleNode("//ConfigInfo/SaveDayFile").Attributes["Days"].Value);
                    DelFileTime.Value = Convert.ToInt32(xmlDoc.SelectSingleNode("//ConfigInfo/DelFileTime").Attributes["Time"].Value);

                    StartListentServer();
                    
                }
                else
                {
                   
                    AutoStart.Checked = false;
                }

               
            }


            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());

            Text_ServerIP.Text = ipe.AddressList[0].ToString();

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;
        }

        private void frm_NetServer_Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

       


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "http://blog.csdn.net/psuaije"); 
            

        }

        /// <summary>
        /// 开始删除过期文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //获取计算机当前时间
            int intHour = DateTime.Now.Hour;
            int intMinute = DateTime.Now.Minute;
            int intSecond = DateTime.Now.Second;
           // MessageBox.Show(intHour.ToString() + " " + intMinute.ToString() + " " + intSecond.ToString());

            if (intHour == Convert.ToInt32(DelFileTime.Value) && intMinute == 0 && intSecond == 1 && Check_SaveFileAS.Checked == true)
            {
                
                    ListBox_LogMsg.Items.Add(System.DateTime.Now.ToString() + ":开始删除过期文件...");

                    System.IO.DirectoryInfo aDirFile = new System.IO.DirectoryInfo(Text_SavePath.Text);
                    System.IO.FileInfo[] aFileList = aDirFile.GetFiles();
                    for (int i = 0; i < aFileList.Length; i++)
                    {
                        string aFIle = aFileList[i].FullName;
                        if (aFIle.Substring(aFIle.LastIndexOf(".")).ToString().ToLower() != ".SDM")
                        {
                            System.IO.FileInfo file = new System.IO.FileInfo(aFIle);

                            if (Convert.ToInt32(file.CreationTime.ToString("yyyy-MM-dd").Replace("-", "")) < Convert.ToInt32(System.DateTime.Now.AddDays(-1 * Convert.ToInt32(Text_DelFileTime.Value)).ToString("yyyy-MM-dd").Replace("-", "")))
                            {
                                System.IO.File.Delete(aFIle);
                                ListBox_LogMsg.Items.Add("过期文件[" + aFIle + "]文件删除成功.");
                            }
                        }
                        else
                        {
                            ListBox_LogMsg.Items.Add("文件" + aFIle + "为传输临时文件，不要删除，如果需除请手动删除。");
                        }

                    }
              

                


            }
        }

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Help _frm_Help = new frm_Help();
            _frm_Help.Show();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 设置自动启动程序和备份文件参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoStart_Click(object sender, EventArgs e)
        {
            if (AutoStart.Checked)
            {
                if (Text_SavePath.Text != "" && Text_ServerIP.Text != "" && Text_ServerPort.Value > 0)
                {
                    if (MessageBox.Show("是否启用开机自动启动程序，并自动监听端口？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        try
                        {
                            //获取程序的完整路径
                            string dir = System.Windows.Forms.Application.ExecutablePath;
                            //设置开启启动
                            RegistryKey akey = Registry.LocalMachine;
                            akey = akey.OpenSubKey(@"SOFTWARE\Microsoft\windows\CurrentVersion\Run", true);
                            akey.SetValue("NetServer", dir);
                            akey.Close();
                            //设置开机启动参数
                            XmlDocument doc = new XmlDocument();
                            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null); doc.AppendChild(dec);  //创建一个根节点（一级）  

                            XmlElement root = doc.CreateElement("ConfigInfo");
                            doc.AppendChild(root);

                            //自动启动状态
                            XmlElement AuotStart = doc.CreateElement("AutoStart");
                            AuotStart.SetAttribute("State", "True");
                            root.AppendChild(AuotStart);

                            //存储备份文件保存路径
                            XmlElement BackSavePath = doc.CreateElement("BackFilePath");
                            BackSavePath.SetAttribute("Path", Text_SavePath.Text.Trim().ToString());
                            root.AppendChild(BackSavePath);

                            //存储服务端IP
                            XmlElement ServerIP = doc.CreateElement("ServerIP");
                            ServerIP.SetAttribute("IP", Text_ServerIP.Text);
                            root.AppendChild(ServerIP);

                            //存储监听端口
                            XmlElement ServerPort = doc.CreateElement("ServerPort");
                            ServerPort.SetAttribute("Port", Text_ServerPort.Value.ToString());
                            root.AppendChild(ServerPort);

                            //是否按时间保存文件，并删除过期文件
                            XmlElement DateTimeSaveFileAndDelFile = doc.CreateElement("SaveAllFileAndDelfile");
                            DateTimeSaveFileAndDelFile.SetAttribute("SaveState", Check_SaveFileAS.Checked.ToString());
                            root.AppendChild(DateTimeSaveFileAndDelFile);

                            //保存几天之前的文件
                            XmlElement SaveDayFile = doc.CreateElement("SaveDayFile");
                            SaveDayFile.SetAttribute("Days", Text_DelFileTime.Value.ToString());
                            root.AppendChild(SaveDayFile);

                            //删除过期文件时间
                            XmlElement DelFileDateTime = doc.CreateElement("DelFileTime");
                            DelFileDateTime.SetAttribute("Time", DelFileTime.Value.ToString());
                            root.AppendChild(DelFileDateTime);

                            //保存配置文件
                            doc.Save(Application.StartupPath + "\\BackFilePath.xml");
                            AutoStart.Checked = true;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
                else
                {
                    AutoStart.Checked = false;

                    MessageBox.Show("请查看文件保存路径及其他参数设置是否为空！");
                }

            }
            else
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null); doc.AppendChild(dec);  //创建一个根节点（一级）  

                    XmlElement root = doc.CreateElement("ConfigInfo");
                    doc.AppendChild(root);

                    //自动启动状态
                    XmlElement AuotStart = doc.CreateElement("AutoStart");
                    AuotStart.SetAttribute("State", "false");
                    root.AppendChild(AuotStart);
                    //保存配置文件
                    doc.Save(Application.StartupPath + "\\BackFilePath.xml");
                    AutoStart.Checked = true;


                    RegistryKey akey = Registry.LocalMachine;
                    akey = akey.OpenSubKey(@"SOFTWARE\Microsoft\windows\CurrentVersion\Run", true);
                    akey.DeleteValue("NetServer", false);
                    akey.Close();
                    AutoStart.Checked = false;
                    MessageBox.Show("随机启动功能已经关闭！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void Check_SaveFileAS_Click(object sender, EventArgs e)
        {
            if (Check_SaveFileAS.Checked)
            {

                if (MessageBox.Show("开启按时间另存功能后，将自动开启清理过期文件！\n注意：将会删除文件夹内的所有过期文件！是否启动？", "自动清理提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Check_SaveFileAS.Checked = true;
                    Text_DelFileTime.Enabled = true;
                    DelFileTime.Enabled = true;
                }
                else
                {
                    Check_SaveFileAS.Checked = false;


                }

            }
            else
            {
                Text_DelFileTime.Enabled = false;
                DelFileTime.Enabled = false;
            }
        }

    
    }
}