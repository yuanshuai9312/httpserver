using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Net;
using System.Net.Sockets;
using NetClassLibrary;
using System.Threading;
using System.Xml;
using Microsoft.Win32;


namespace NetClient
{
    public partial class frm_NetClient_Main : Form
    {
        public frm_NetClient_Main()
        {
            InitializeComponent();
        }

        #region 定义委托
        /// <summary>
        /// 定义一个更新进度条最大值的委托
        /// </summary>
        /// <param name="x"></param>
        public delegate void D_UpFileSendProgressMax(int x);

        /// <summary>
        /// 定义一个更新发包数量的委托
        /// </summary>
        /// <param name="msg"></param>
        public delegate void D_UpSendBagNu(string msg);


        /// <summary>
        /// 定义一个获取文件MD5值的委托
        /// </summary>
        /// <param name="MD5filePath"></param>
        /// <returns></returns>
        public delegate string D_MyGetMD5(string MD5filePath);

        /// <summary>
        /// 定义更新进度条委托
        /// </summary>
        /// <param name="x"></param>
        public delegate void FileSendProgressB(int x);

        /// <summary>
        /// 定义一个UI控件更新委托 
        /// </summary>
        /// <param name="str"></param>
        public delegate void MyInvoke(string str); 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP">服务器IP地址</param>
        /// <param name="Port">服务器端口</param>
        /// <param name="FilePath">发送文件的路径</param>
        /// <param name="PackSize">包的大小</param>
        /// <param name="LastPackSize">最后一个包的大小</param>
        /// <param name="PackCount">包的数量</param>
        /// <param name="FileName">文件名</param>
        /// <param name="FileSize">文件大小</param>
        public delegate void D_StartSendFIle(bool Sate,  string IP, string Port, string FilePath, string PackSize, string LastPackSize, string PackCount, string FileName, string FileSize);

        /// <summary>
        /// 定义一个委托更新Log
        /// </summary>
        /// <param name="msg"></param>
        public delegate void D_UpMsgLog(string msg);

        /// <summary>
        /// 定义一个委托发送按钮可以使用
        /// </summary>
        public delegate void D_SendBtState(bool state);

        #endregion


        #region 公共变量
        /// <summary>
        /// 定义打开的文件对象
        /// </summary>
        private System.IO.FileInfo fileInfo;
        /// <summary>
        /// 定义包的个数
        /// </summary>
        //private Int32 _bagCount;
        
        /// <summary>
        /// 判断是否继续进行连接检测
        /// </summary>
        private bool CheckConnection = false;
       


        #endregion


        /// <summary>
        /// 选择需要发送的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_BrowserFile_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Text_FileMD5.Text = "";
                string FilePath = openFileDialog1.FileName;
                Text_FilePath.Text = FilePath;
                Text_FileName.Text = System.IO.Path.GetFileName(FilePath);
                //创建文件流
                fileInfo = new System.IO.FileInfo(FilePath);

                //获取文件大小
                Text_FileSize.Text = fileInfo.Length.ToString();

                //获取文件包个数(文件总数除以包的大小)
                Text_PackCount.Text = Convert.ToInt32(fileInfo.Length / (long)Text_PackSize.Value).ToString();
                //Text_PackCount.Text = _bagCount.ToString();

                //获取最后一个文件包大小
                Text_LastPackSize.Text = (fileInfo.Length - Convert.ToInt32(Text_PackCount.Text.Trim()) * (long)Text_PackSize.Value).ToString();

                //获取文件的MD5值
                //Text_FileMD5.Text = NetClassLibrary.FileTools.GetFileMD5(FilePath);

                //使用委托来创建新的线程计算文件MD5值；并传递文件路径和返回MD5值
                label20.Text = "正在计算文件MD5值...";
                FileTools _fileMD5 = new FileTools();
                D_MyGetMD5 myMD5 = new D_MyGetMD5(_fileMD5.GetFileMD5);
                myMD5.BeginInvoke(FilePath, new AsyncCallback(OutMD5), null);

            }   
        }


        /// <summary>
        /// 开始发送文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
 
        private void bt_SendFile_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Text_FilePath.Text))
            {
                //FileSendThread_Class _SendFile = new FileSendThread_Class();
                D_StartSendFIle my_D_StartSendFIle = new D_StartSendFIle(StartSendFile);
                //调用文件发送函数
                my_D_StartSendFIle.BeginInvoke(true, Text_ServerIP.Text, Text_ServerPort.Value.ToString(), Text_FilePath.Text, Text_PackSize.Value.ToString(), Text_LastPackSize.Text, Text_PackCount.Text.Trim().ToString(), Text_FileName.Text, Text_FileSize.Text, null, null);

                bt_SendFile.Enabled = false;
            }
            else
            {
                MyInvoke _myInvoke = new MyInvoke(UpMsgLog);
                BeginInvoke(_myInvoke, new object[] { "ERROR:" + Text_FilePath.Text + "文件不存在!" });
                 
            }

        }


        /// <summary>
        /// 文件发送函数
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Port"></param>
        /// <param name="FilePath"></param>
        /// <param name="PackSize"></param>
        /// <param name="LastPackSize"></param>
        /// <param name="PackCount"></param>
        public void StartSendFile(bool Sate, string IP, string Port, string FilePath, string PackSize, string LastPackSize, string PackCount , string FileName , string FileSize )
        {
            try
            {
                //设置进度条
                if (Sate == true)
                {

                    if (Convert.ToInt32(PackCount) > 0)
                    {
                        D_UpFileSendProgressMax _D_UpFileSendProgressMax = new D_UpFileSendProgressMax(UpFileSendProgressMax);
                        this.BeginInvoke(_D_UpFileSendProgressMax, new object[] { Convert.ToInt32(PackCount) });
                    }
                    else
                    {
                        D_UpFileSendProgressMax _D_UpFileSendProgressMax = new D_UpFileSendProgressMax(UpFileSendProgressMax);
                        this.BeginInvoke(_D_UpFileSendProgressMax, new object[] { 1 });
                    }

                }
                //指向远程服务器
                IPEndPoint iped = new IPEndPoint(IPAddress.Parse(IP), int.Parse(Port));
                //创建套接字
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //连接到远程服务器
                client.Connect(iped);

                IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

                //MsgLog.Items.Add();

                D_UpMsgLog _D_UpMsgLog = new D_UpMsgLog(UpMsgLog);
                this.BeginInvoke(_D_UpMsgLog, new object[] { System.DateTime.Now.ToString() + ":发送文件【"+FileName+"】->["+clientep.Address.ToString()+"]" });

                //发送文件名
                NetClassLibrary.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(FileName));
                //发送文件大小
                NetClassLibrary.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(FileSize));
                //发送包的大小
                NetClassLibrary.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(PackSize));
                //发送包的数量
                NetClassLibrary.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(PackCount));
                //发送最后一个包的大小
                NetClassLibrary.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(LastPackSize));
                //发送文件MD5值
                //NetClassLibrary.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(Text_FileMD5.Text.ToString()));

                
                System.IO.FileInfo tmp_FileInfo = new System.IO.FileInfo(FilePath);
                

                //打开文件
                System.IO.FileStream _fileStream = tmp_FileInfo.OpenRead();

                //定义数据包
                byte[] SendbagData = new byte[Convert.ToInt32(Text_PackSize.Value)];

                //开始循环发送数据包
                for (int i = 0; i < Convert.ToInt32(PackCount); i++)
                {
                    //从文件流中读取指定大小的数据，并填充到SendbagData字节变量中
                    _fileStream.Read(SendbagData, 0, SendbagData.Length);
                    
                    //发送读取的数据包
                    NetClassLibrary.TransferFiles.SendVarData(client, SendbagData);


                    if (Sate == true)
                    {
                        //更新发包的数量(文本框中显示)
                        D_UpSendBagNu _D_UpSendBagNu = new D_UpSendBagNu(UpSendBagNu);
                        this.BeginInvoke(_D_UpSendBagNu, new object[] { (i + 1).ToString() });

                        //更新进度条
                        FileSendProgressB B = new FileSendProgressB(UpB);
                        this.BeginInvoke(B, new object[] { i + 1 });
                    }
                }

                if (Convert.ToInt32(LastPackSize) != 0)
                {
                    //读取最后一个包
                    SendbagData = new byte[Convert.ToInt32(Convert.ToInt32(LastPackSize))];
                    //发送最后一个包
                    _fileStream.Read(SendbagData, 0, SendbagData.Length);
                    NetClassLibrary.TransferFiles.SendVarData(client, SendbagData);


                    if (Sate == true)
                    {
                        if (Convert.ToInt32(PackCount) == 0)
                        {
                            //更新进度条
                            FileSendProgressB B = new FileSendProgressB(UpB);
                            this.BeginInvoke(B, new object[] { 1 });
                        }
                    }

                }


                MyInvoke _myInvoke = new MyInvoke(UpMsgLog);
                BeginInvoke(_myInvoke, new object[] { System.DateTime.Now.ToString() + ":【" + FileName + "】发送完成！" });
                    

                 //发送文件MD5值
                // NetClassLibrary.TransferFiles.SendVarData(client, System.Text.Encoding.Unicode.GetBytes(Text_FileMD5.Text.ToString()));
                
                //关闭读取的文件

                
                _fileStream.Close();

                //关闭网络连接
                client.Close();


                
                D_SendBtState _D_SendBtState = new D_SendBtState(SendBtState);
                this.BeginInvoke(_D_SendBtState, new object[] { true });


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        #region 利用委托在UI界面上显示内容

        /// <summary>
        /// 设置发送安装状态
        /// </summary>
        public void SendBtState(bool state)
        {
            bt_SendFile.Enabled = state;
        }



        /// <summary>
        /// 定义一个用于显示返回值的函数
        /// </summary>
        /// <param name="result"></param>
        public void OutMD5(IAsyncResult result)
        {
            AsyncResult async = (AsyncResult)result;

            D_MyGetMD5 Deletget = (D_MyGetMD5)async.AsyncDelegate;

            ////把文件的MD5值显示在文本框中
            //Text_FileMD5.Text = Deletget.EndInvoke(result);

            //实例化界面更新委托，调用界面跟新函数更新MD5显示文本框
            MyInvoke mi = new MyInvoke(UpText);
            this.BeginInvoke(mi, new object[] { Deletget.EndInvoke(result) });
        }

        /// <summary>
        /// 更新MD5文本框函数
        /// </summary>
        /// <param name="MD5str"></param>
        public void UpText(string MD5str)
        {
            Text_FileMD5.Text = MD5str;
            label20.Text = "";
        }


        /// <summary>
        /// 更新Log内容显示
        /// </summary>
        /// <param name="msg"></param>
        public void UpMsgLog(string msg)
        {
            MsgLog.Items.Add(msg);
            MsgLog.TopIndex = MsgLog.Items.Count - 1;
            if (MsgLog.Items.Count > 200)
            {
                MsgLog.Items.Clear();
            }
        }

        /// <summary>
        /// 更新进度条
        /// </summary>
        /// <param name="x"></param>
        public void UpB(int x)
        {
            FileSendProgress.Value = x;
        }

        /// <summary>
        /// 定义更新进度条最大值
        /// </summary>
        /// <param name="x"></param>
        public void UpFileSendProgressMax(int x)
        {
            FileSendProgress.Maximum = x;
        }
        #endregion

        /// <summary>
        /// 更新发包数量
        /// </summary>
        /// <param name="msg"></param>
        public void UpSendBagNu(string msg)
        {
            Text_SendBagNumber.Text = msg;
        }

        private void bt_FileSendConfig_Click(object sender, EventArgs e)
        {
            frm_SendFileConfig _frm = new frm_SendFileConfig();
            _frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //获取计算机当前时间
            int intHour = DateTime.Now.Hour;
            int intMinute = DateTime.Now.Minute;
            int intSecond = DateTime.Now.Second;
            
            //获取设定的时间
            int _intHour = Convert.ToInt32(Text_Time_Hour.Value);
            int _intMinute = Convert.ToInt32(Text_Time_Minute.Value);
            int _intSecond = Convert.ToInt32(Text_Time_Second.Value);

            if (intHour == _intHour && intMinute == _intMinute && intSecond == _intSecond)
            {



                string XmlFilePath = Application.StartupPath + "\\FilePath.xml";

                if (System.IO.File.Exists(XmlFilePath))
                {

                    //创建XML实例
                    XmlDocument xmlDoc = new XmlDocument();
                    //加载XML文件
                    xmlDoc.Load(XmlFilePath);
                    //选择一个匹配的节点
                    XmlNode xn = xmlDoc.SelectSingleNode("FileLists");
                    //获取这个节点的所有子节点
                    XmlNodeList xnl = xn.ChildNodes;

                    string[,] datalist = new string[xnl.Count, 2];
                    //循环读取所有子节点，并显示节点的信息
                    foreach (XmlNode xnf in xnl)
                    {
                        XmlElement xe = (XmlElement)xnf;

                        //想ListView中添加数据
                        //ListViewItem p = new ListViewItem();
                        //p = new ListViewItem(new string[] { xe.GetAttribute("FileName"), xe.GetAttribute("FilePath") });
                        if (System.IO.File.Exists(xe.GetAttribute("FilePath")))
                        {

                            System.IO.FileInfo fi = new System.IO.FileInfo(xe.GetAttribute("FilePath"));

                            //文件包数量
                            string tmp_BagCount = Convert.ToInt32(fi.Length / (long)Text_PackSize.Value).ToString();
                            //最后一个包的大小
                            string tmp_LastBagSize = (fi.Length - Convert.ToInt32(tmp_BagCount) * (long)(Text_PackSize.Value)).ToString();

                            D_StartSendFIle my_D_StartSendFIle = new D_StartSendFIle(StartSendFile);
                            my_D_StartSendFIle.BeginInvoke(
                                                            false,
                                                            Text_ServerIP.Text,
                                                            Text_ServerPort.Value.ToString(),
                                                            xe.GetAttribute("FilePath"),
                                                            Text_PackSize.Value.ToString(),
                                                            tmp_LastBagSize,
                                                            tmp_BagCount,
                                                            xe.GetAttribute("FileName"),
                                                            fi.Length.ToString(),
                                                            null,
                                                            null
                                                            );
                        }
                        else
                        {
                            MyInvoke _myInvoke = new MyInvoke(UpMsgLog);
                            BeginInvoke(_myInvoke, new object[] { "ERROR:" + xe.GetAttribute("FilePath") + "文件不存在!" });
                 
                        }
                    }
                }
            }
        }

        private void bt_TimeStart_Click(object sender, EventArgs e)
        {
            MsgLog.Items.Add("10秒后开始连接服务器!"); 
            CheckConnection = true;
            bt_TimeStop.Enabled = true;
            bt_TimeStart.Enabled = false;
            StartLinsts();
            
                 
        }

        /// <summary>
        /// 开始监听并发送
        /// </summary>
        public void StartLinsts()
        {


            
           


            isconnect();

            if (ConnState == true)
            {

                //设置时间间隔为1秒钟执行一次
                timer1.Interval = 1000;

                timer1.Enabled = true;
                MsgLog.Items.Add("已连接到服务器" + Text_ServerIP.Text + ":" + Text_ServerPort.Value.ToString());
                MsgLog.Items.Add(System.DateTime.Now.ToString() + "定时器已经启动！");
                MsgLog.Items.Add("在" + Text_Time_Hour.Value.ToString() + "点" + Text_Time_Minute.Value.ToString() + "分" + Text_Time_Second.Value.ToString() + "秒开始传输！");
                bt_TimeStop.Enabled = true;
                bt_FileSendConfig.Enabled = false;
                bt_TimeStart.Enabled = false;
                Text_Time_Hour.Enabled = false;
                Text_Time_Minute.Enabled = false;
                Text_Time_Second.Enabled = false;
            }
            else
            {

                //MyInvoke _myInvoke = new MyInvoke(UpMsgLog);
                //BeginInvoke(_myInvoke, new object[] { System.DateTime.Now.ToString() + System.DateTime.Now.ToShortTimeString() + "无法连接远程计算机，正在进行重试或请检查IP地址及端口号是否正确！" });


                //MsgLog.Items.Add(System.DateTime.Now.ToShortTimeString() + "无法连接远程计算机，正在进行重试或请检查IP地址及端口号是否正确！");
                //Thread.Sleep(9000);
                StartLinsts();

            }
        }


        #region #*******************************************************************************************
        //private void sinvoke()
        //{
        //    this.Invoke(new ttst(startLin));
        //}

        //delegate void ttst();

        
        //public void startLin()
        //{
           
            
        //}

        #endregion



        private void bt_TimeStop_Click(object sender, EventArgs e)
        {


            timer1.Enabled = false;
            bt_FileSendConfig.Enabled = true;
            bt_TimeStart.Enabled = true;
            Text_Time_Hour.Enabled = true;
            Text_Time_Minute.Enabled = true;
            Text_Time_Second.Enabled = true;

            CheckConnection = false;
            bt_TimeStart.Enabled = true;
            bt_TimeStop.Enabled = false;

            MsgLog.Items.Add(System.DateTime.Now.ToString() + ":停止了定时发送！");

        }

        private void 关于IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Help _frm_Help = new frm_Help();
            _frm_Help.ShowDialog();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_StopSend_Click(object sender, EventArgs e)
        {

        }



        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;
        }



        private void frm_NetClient_Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private bool ConnState = false;

        /// <summary>
        /// 连接远程服务器
        /// </summary>
        /// <returns>True为已连接，False为远程服务器不可用</returns>
        //private void IsConnect()
        //{

        //    Thread ttt = new Thread(isC);
        //    ttt.Start();



        //}

        /// <summary>
        /// 定义委托
        /// </summary>
        /// <returns></returns>
        //delegate bool MyDeisConn();

        //private void isC()
        //{

        //    //MyDeisConn mydeIsConn = new MyDeisConn(isconnect);
        //    //IAsyncResult reff = mydeIsConn.BeginInvoke(null,null);

        //    //return mydeIsConn.EndInvoke(reff);

        //    this.Invoke(new ttst(isconnect));
        //}
        


        /// <summary>
        /// 判断服务器是否开放
        /// </summary>
        /// <returns>True为已连接，False为远程服务器不可用</returns>
        private void isconnect()
        {
            
            
           
            //系统等待1秒钟后开始执行
            DateTime d = DateTime.Now;
            while ((DateTime.Now - d).TotalMilliseconds <= 10000)
            {
                Thread.Sleep(100);//加上这句可以减少系统资源消耗。不知道为什么
                Application.DoEvents();
            }

            if (CheckConnection == true)
            { 
                try
                {
                //指向远程服务器
                IPEndPoint iped = new IPEndPoint(IPAddress.Parse(Text_ServerIP.Text.Trim()), int.Parse(Text_ServerPort.Text.Trim().ToString()));
                //创建套接字
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //连接到远程服务器
               
                    client.Connect(iped);
                    client.Close();
                    //return true;
                    ConnState = true;

                }
                catch (Exception ex)
                {
                    MyInvoke _myInvoke = new MyInvoke(UpMsgLog);
                    BeginInvoke(_myInvoke, new object[] { System.DateTime.Now.ToString() + ex.Message  + "   10秒后重试！"});

                    //MsgLog.Items.Add();
                    //return false;
                    ConnState = false;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", "http://blog.csdn.net/psuaije"); 
        }

        private void AutoStart_bt_Click(object sender, EventArgs e)
        {
            if (AutoStart_bt.Checked)
            {
                try
                {
                    MsgLog.Items.Add("【" + System.DateTime.Now.ToString() + "】" + "正在配置开机自动启动...");
                    //设置开机启动参数
                    XmlDocument doc = new XmlDocument();
                    XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null); doc.AppendChild(dec);  //创建一个根节点（一级）  

                    XmlElement root = doc.CreateElement("ConfigInfo");
                    doc.AppendChild(root);

                    //自动启动状态
                    XmlElement AuotStart = doc.CreateElement("AutoStart");
                    AuotStart.SetAttribute("State", "True");
                    root.AppendChild(AuotStart);

                    //服务端IP
                    XmlElement ServerIP = doc.CreateElement("ServerIP");
                    ServerIP.SetAttribute("IP", Text_ServerIP.Text);
                    root.AppendChild(ServerIP);

                    //服务端IP
                    XmlElement ServerPort = doc.CreateElement("ServerPort");
                    ServerPort.SetAttribute("Port", Text_ServerPort.Value.ToString());
                    root.AppendChild(ServerPort);

                    //设置发送时间(小时)
                    XmlElement PostH = doc.CreateElement("PostH");
                    PostH.SetAttribute("Hour", Text_Time_Hour.Value.ToString());
                    root.AppendChild(PostH);

                    //设置发送时间(分钟)
                    XmlElement PostM = doc.CreateElement("PostM");
                    PostM.SetAttribute("Minute", Text_Time_Minute.Value.ToString());
                    root.AppendChild(PostM);

                    //设置发送时间(秒)
                    XmlElement PostS = doc.CreateElement("PostS");
                    PostS.SetAttribute("Second", Text_Time_Second.Value.ToString());
                    root.AppendChild(PostS);


                    //保存配置文件
                    doc.Save(Application.StartupPath + "\\AutoStartConfig.xml");

                    //获取程序的完整路径
                    string dir = System.Windows.Forms.Application.ExecutablePath;

                    //设置开启启动
                    RegistryKey akey = Registry.LocalMachine;
                    akey = akey.OpenSubKey(@"SOFTWARE\Microsoft\windows\CurrentVersion\Run", true);
                    akey.SetValue("NetClient", dir);
                    akey.Close();
                    AutoStart_bt.Checked = true;

                    MsgLog.Items.Add("【" + System.DateTime.Now.ToString() + "】" + "开启启动配置成功.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MsgLog.Items.Add("【" + System.DateTime.Now.ToString() + "】" + "正在取消开机自动启动...");
                //取消开机自动启动
                RegistryKey akey = Registry.LocalMachine;
                akey = akey.OpenSubKey(@"SOFTWARE\Microsoft\windows\CurrentVersion\Run", true);
                akey.DeleteValue("NetClient", false);
                akey.Close();
                AutoStart_bt.Checked = false;

                //自动启动状态
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null); doc.AppendChild(dec);  //创建一个根节点（一级）  

                XmlElement root = doc.CreateElement("ConfigInfo");
                doc.AppendChild(root);

                XmlElement AuotStart = doc.CreateElement("AutoStart");
                AuotStart.SetAttribute("State", "false");
                root.AppendChild(AuotStart);
                //保存配置文件
                doc.Save(Application.StartupPath + "\\AutoStartConfig.xml");


                MsgLog.Items.Add("【" + System.DateTime.Now.ToString() + "】" + "开机启动取消成功.");               
            }

        }

        private void frm_NetClient_Main_Load(object sender, EventArgs e)
        {
            string XmlFilePath = Application.StartupPath + "\\AutoStartConfig.xml";

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
                    AutoStart_bt.Checked = true;

                    Text_ServerIP.Text = xmlDoc.SelectSingleNode("//ConfigInfo/ServerIP").Attributes["IP"].Value.ToString();
                    Text_ServerPort.Value = Convert.ToInt32(xmlDoc.SelectSingleNode("//ConfigInfo/ServerPort").Attributes["Port"].Value.ToString());
                    Text_Time_Hour.Value = Convert.ToInt32(xmlDoc.SelectSingleNode("//ConfigInfo/PostH").Attributes["Hour"].Value.ToString());
                    Text_Time_Minute.Value = Convert.ToInt32(xmlDoc.SelectSingleNode("//ConfigInfo/PostM").Attributes["Minute"].Value.ToString());
                    Text_Time_Second.Value = Convert.ToInt32(xmlDoc.SelectSingleNode("//ConfigInfo/PostS").Attributes["Second"].Value.ToString());


                    
                        //开始定时监听并发送
                    MsgLog.Items.Add("10秒后开始连接服务器!"); 
                    CheckConnection = true;
                    bt_TimeStop.Enabled = true;
                    bt_TimeStart.Enabled = false;
                    StartLinsts();
                   
                    
                   

                   
                }
                else
                {
                    AutoStart_bt.Checked = false;
                }
            }
        }

        private void frm_NetClient_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckConnection = false;
        }
 

    }
  
}

