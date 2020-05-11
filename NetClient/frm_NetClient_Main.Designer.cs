namespace NetClient
{
    partial class frm_NetClient_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NetClient_Main));
            this.bt_TimeStart = new System.Windows.Forms.Button();
            this.bt_BrowserFile = new System.Windows.Forms.Button();
            this.Text_FilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.MsgLog = new System.Windows.Forms.ListBox();
            this.groupMsglog = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Text_ServerPort = new System.Windows.Forms.NumericUpDown();
            this.Text_PackSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_ServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AutoStart_bt = new System.Windows.Forms.CheckBox();
            this.bt_TimeStop = new System.Windows.Forms.Button();
            this.bt_FileSendConfig = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Text_Time_Hour = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.Text_Time_Second = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Text_Time_Minute = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.bt_SendFile = new System.Windows.Forms.Button();
            this.Text_FileSize = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Text_FileName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Text_SendBagNumber = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Text_FileMD5 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.FileSendProgress = new System.Windows.Forms.ProgressBar();
            this.Text_LastPackSize = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Text_PackCount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupMsglog.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_ServerPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_PackSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_Time_Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_Time_Second)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_Time_Minute)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_TimeStart
            // 
            this.bt_TimeStart.Location = new System.Drawing.Point(368, 61);
            this.bt_TimeStart.Name = "bt_TimeStart";
            this.bt_TimeStart.Size = new System.Drawing.Size(75, 23);
            this.bt_TimeStart.TabIndex = 0;
            this.bt_TimeStart.Text = "启动定时";
            this.bt_TimeStart.UseVisualStyleBackColor = true;
            this.bt_TimeStart.Click += new System.EventHandler(this.bt_TimeStart_Click);
            // 
            // bt_BrowserFile
            // 
            this.bt_BrowserFile.Location = new System.Drawing.Point(471, 18);
            this.bt_BrowserFile.Name = "bt_BrowserFile";
            this.bt_BrowserFile.Size = new System.Drawing.Size(75, 23);
            this.bt_BrowserFile.TabIndex = 1;
            this.bt_BrowserFile.Text = "浏览";
            this.bt_BrowserFile.UseVisualStyleBackColor = true;
            this.bt_BrowserFile.Click += new System.EventHandler(this.bt_BrowserFile_Click);
            // 
            // Text_FilePath
            // 
            this.Text_FilePath.Location = new System.Drawing.Point(67, 20);
            this.Text_FilePath.Name = "Text_FilePath";
            this.Text_FilePath.ReadOnly = true;
            this.Text_FilePath.Size = new System.Drawing.Size(398, 21);
            this.Text_FilePath.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MsgLog
            // 
            this.MsgLog.FormattingEnabled = true;
            this.MsgLog.HorizontalScrollbar = true;
            this.MsgLog.ItemHeight = 12;
            this.MsgLog.Location = new System.Drawing.Point(6, 20);
            this.MsgLog.Name = "MsgLog";
            this.MsgLog.Size = new System.Drawing.Size(219, 400);
            this.MsgLog.TabIndex = 3;
            // 
            // groupMsglog
            // 
            this.groupMsglog.Controls.Add(this.MsgLog);
            this.groupMsglog.Location = new System.Drawing.Point(572, 34);
            this.groupMsglog.Name = "groupMsglog";
            this.groupMsglog.Size = new System.Drawing.Size(233, 430);
            this.groupMsglog.TabIndex = 4;
            this.groupMsglog.TabStop = false;
            this.groupMsglog.Text = "操作日志";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.IToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.退出EToolStripMenuItem.Text = "退出(E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // IToolStripMenuItem
            // 
            this.IToolStripMenuItem.Name = "IToolStripMenuItem";
            this.IToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.IToolStripMenuItem.Text = "关于(&I)";
            this.IToolStripMenuItem.Click += new System.EventHandler(this.关于IToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Text_ServerPort);
            this.groupBox2.Controls.Add(this.Text_PackSize);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Text_ServerIP);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 69);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送设置";
            // 
            // Text_ServerPort
            // 
            this.Text_ServerPort.Location = new System.Drawing.Point(204, 27);
            this.Text_ServerPort.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.Text_ServerPort.Name = "Text_ServerPort";
            this.Text_ServerPort.Size = new System.Drawing.Size(58, 21);
            this.Text_ServerPort.TabIndex = 7;
            this.Text_ServerPort.Value = new decimal(new int[] {
            1984,
            0,
            0,
            0});
            // 
            // Text_PackSize
            // 
            this.Text_PackSize.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Text_PackSize.Location = new System.Drawing.Point(327, 27);
            this.Text_PackSize.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.Text_PackSize.Name = "Text_PackSize";
            this.Text_PackSize.Size = new System.Drawing.Size(62, 21);
            this.Text_PackSize.TabIndex = 4;
            this.Text_PackSize.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(399, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "(范围：10000-60000)字节";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "发包大小：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口：";
            // 
            // Text_ServerIP
            // 
            this.Text_ServerIP.Location = new System.Drawing.Point(69, 27);
            this.Text_ServerIP.Name = "Text_ServerIP";
            this.Text_ServerIP.Size = new System.Drawing.Size(90, 21);
            this.Text_ServerIP.TabIndex = 0;
            this.Text_ServerIP.Text = "192.168.1.100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器IP：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AutoStart_bt);
            this.groupBox3.Controls.Add(this.bt_TimeStop);
            this.groupBox3.Controls.Add(this.bt_FileSendConfig);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.Text_Time_Hour);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.Text_Time_Second);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.Text_Time_Minute);
            this.groupBox3.Controls.Add(this.bt_TimeStart);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 94);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "定时设置";
            // 
            // AutoStart_bt
            // 
            this.AutoStart_bt.AutoSize = true;
            this.AutoStart_bt.Location = new System.Drawing.Point(252, 65);
            this.AutoStart_bt.Name = "AutoStart_bt";
            this.AutoStart_bt.Size = new System.Drawing.Size(96, 16);
            this.AutoStart_bt.TabIndex = 16;
            this.AutoStart_bt.Text = "启用自动启动";
            this.AutoStart_bt.UseVisualStyleBackColor = true;
            this.AutoStart_bt.Click += new System.EventHandler(this.AutoStart_bt_Click);
            // 
            // bt_TimeStop
            // 
            this.bt_TimeStop.Enabled = false;
            this.bt_TimeStop.Location = new System.Drawing.Point(449, 61);
            this.bt_TimeStop.Name = "bt_TimeStop";
            this.bt_TimeStop.Size = new System.Drawing.Size(100, 23);
            this.bt_TimeStop.TabIndex = 15;
            this.bt_TimeStop.Text = "暂停定时发送";
            this.bt_TimeStop.UseVisualStyleBackColor = true;
            this.bt_TimeStop.Click += new System.EventHandler(this.bt_TimeStop_Click);
            // 
            // bt_FileSendConfig
            // 
            this.bt_FileSendConfig.Location = new System.Drawing.Point(368, 21);
            this.bt_FileSendConfig.Name = "bt_FileSendConfig";
            this.bt_FileSendConfig.Size = new System.Drawing.Size(180, 23);
            this.bt_FileSendConfig.TabIndex = 14;
            this.bt_FileSendConfig.Text = "发送文件设置";
            this.bt_FileSendConfig.UseVisualStyleBackColor = true;
            this.bt_FileSendConfig.Click += new System.EventHandler(this.bt_FileSendConfig_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(11, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(209, 12);
            this.label17.TabIndex = 13;
            this.label17.Text = "定时发送可以同时设置发送多个文件。";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(9, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(221, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "每次启动定时发送都需要设置发送时间。";
            // 
            // Text_Time_Hour
            // 
            this.Text_Time_Hour.Location = new System.Drawing.Point(69, 20);
            this.Text_Time_Hour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Text_Time_Hour.Name = "Text_Time_Hour";
            this.Text_Time_Hour.Size = new System.Drawing.Size(39, 21);
            this.Text_Time_Hour.TabIndex = 6;
            this.Text_Time_Hour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Text_Time_Hour.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "发送时间：";
            // 
            // Text_Time_Second
            // 
            this.Text_Time_Second.Location = new System.Drawing.Point(206, 20);
            this.Text_Time_Second.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.Text_Time_Second.Name = "Text_Time_Second";
            this.Text_Time_Second.Size = new System.Drawing.Size(38, 21);
            this.Text_Time_Second.TabIndex = 10;
            this.Text_Time_Second.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "秒";
            // 
            // Text_Time_Minute
            // 
            this.Text_Time_Minute.Location = new System.Drawing.Point(137, 20);
            this.Text_Time_Minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.Text_Time_Minute.Name = "Text_Time_Minute";
            this.Text_Time_Minute.Size = new System.Drawing.Size(39, 21);
            this.Text_Time_Minute.TabIndex = 8;
            this.Text_Time_Minute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "点";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.bt_SendFile);
            this.groupBox4.Controls.Add(this.Text_FileSize);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.Text_FileName);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.Text_FilePath);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.bt_BrowserFile);
            this.groupBox4.Location = new System.Drawing.Point(14, 209);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(552, 87);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "手动发送";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(436, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "字节";
            // 
            // bt_SendFile
            // 
            this.bt_SendFile.Location = new System.Drawing.Point(472, 53);
            this.bt_SendFile.Name = "bt_SendFile";
            this.bt_SendFile.Size = new System.Drawing.Size(74, 23);
            this.bt_SendFile.TabIndex = 8;
            this.bt_SendFile.Text = "开始发送";
            this.bt_SendFile.UseVisualStyleBackColor = true;
            this.bt_SendFile.Click += new System.EventHandler(this.bt_SendFile_Click);
            // 
            // Text_FileSize
            // 
            this.Text_FileSize.Location = new System.Drawing.Point(326, 55);
            this.Text_FileSize.Name = "Text_FileSize";
            this.Text_FileSize.ReadOnly = true;
            this.Text_FileSize.Size = new System.Drawing.Size(107, 21);
            this.Text_FileSize.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(264, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "文件大小：";
            // 
            // Text_FileName
            // 
            this.Text_FileName.Location = new System.Drawing.Point(67, 55);
            this.Text_FileName.Name = "Text_FileName";
            this.Text_FileName.ReadOnly = true;
            this.Text_FileName.Size = new System.Drawing.Size(193, 21);
            this.Text_FileName.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "文件名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "选择文件：";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Text_SendBagNumber);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.Text_FileMD5);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.FileSendProgress);
            this.groupBox5.Controls.Add(this.Text_LastPackSize);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.Text_PackCount);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Location = new System.Drawing.Point(14, 302);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(552, 106);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "文件信息";
            // 
            // Text_SendBagNumber
            // 
            this.Text_SendBagNumber.Location = new System.Drawing.Point(470, 75);
            this.Text_SendBagNumber.Name = "Text_SendBagNumber";
            this.Text_SendBagNumber.Size = new System.Drawing.Size(70, 21);
            this.Text_SendBagNumber.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(409, 81);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 9;
            this.label21.Text = "发包数量：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label20.Location = new System.Drawing.Point(338, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 12);
            this.label20.TabIndex = 8;
            // 
            // Text_FileMD5
            // 
            this.Text_FileMD5.Location = new System.Drawing.Point(85, 49);
            this.Text_FileMD5.Name = "Text_FileMD5";
            this.Text_FileMD5.ReadOnly = true;
            this.Text_FileMD5.Size = new System.Drawing.Size(247, 21);
            this.Text_FileMD5.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 12);
            this.label19.TabIndex = 6;
            this.label19.Text = "文件MD5值：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 12);
            this.label16.TabIndex = 5;
            this.label16.Text = "文件发送进度：";
            // 
            // FileSendProgress
            // 
            this.FileSendProgress.Location = new System.Drawing.Point(98, 75);
            this.FileSendProgress.Maximum = 1;
            this.FileSendProgress.Name = "FileSendProgress";
            this.FileSendProgress.Size = new System.Drawing.Size(305, 23);
            this.FileSendProgress.Step = 1;
            this.FileSendProgress.TabIndex = 4;
            // 
            // Text_LastPackSize
            // 
            this.Text_LastPackSize.Location = new System.Drawing.Point(244, 21);
            this.Text_LastPackSize.Name = "Text_LastPackSize";
            this.Text_LastPackSize.ReadOnly = true;
            this.Text_LastPackSize.Size = new System.Drawing.Size(88, 21);
            this.Text_LastPackSize.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(174, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 2;
            this.label15.Text = "最后包大小：";
            // 
            // Text_PackCount
            // 
            this.Text_PackCount.Location = new System.Drawing.Point(85, 21);
            this.Text_PackCount.Name = "Text_PackCount";
            this.Text_PackCount.ReadOnly = true;
            this.Text_PackCount.Size = new System.Drawing.Size(82, 21);
            this.Text_PackCount.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "文件分包数：";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.linkLabel1);
            this.groupBox6.Location = new System.Drawing.Point(13, 414);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(551, 50);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "注意";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(329, 12);
            this.label18.TabIndex = 6;
            this.label18.Text = "发送端程序以在服务器上测试10天以上，占用内存15MB左右。";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(386, 22);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(155, 12);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Author:PsuAiJe 2011-09-16";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "局域网文件传输工具-发送端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // frm_NetClient_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 468);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupMsglog);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_NetClient_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时文件传输—客户端 v1.2 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_NetClient_Main_FormClosing);
            this.Load += new System.EventHandler(this.frm_NetClient_Main_Load);
            this.SizeChanged += new System.EventHandler(this.frm_NetClient_Main_SizeChanged);
            this.groupMsglog.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_ServerPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_PackSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_Time_Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_Time_Second)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_Time_Minute)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_TimeStart;
        private System.Windows.Forms.Button bt_BrowserFile;
        private System.Windows.Forms.TextBox Text_FilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox MsgLog;
        private System.Windows.Forms.GroupBox groupMsglog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Text_ServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown Text_PackSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Text_Time_Second;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Text_Time_Minute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Text_Time_Hour;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button bt_SendFile;
        private System.Windows.Forms.TextBox Text_FileSize;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Text_FileName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox Text_LastPackSize;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox Text_PackCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ProgressBar FileSendProgress;
        private System.Windows.Forms.Button bt_TimeStop;
        private System.Windows.Forms.Button bt_FileSendConfig;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ToolStripMenuItem IToolStripMenuItem;
        private System.Windows.Forms.TextBox Text_FileMD5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown Text_ServerPort;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox Text_SendBagNumber;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox AutoStart_bt;
        private System.Windows.Forms.Timer timer2;
    }
}

