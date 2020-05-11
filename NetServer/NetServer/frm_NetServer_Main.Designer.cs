namespace NetServer
{
    partial class frm_NetServer_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NetServer_Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AutoStart = new System.Windows.Forms.CheckBox();
            this.StopListent = new System.Windows.Forms.Button();
            this.StartListent = new System.Windows.Forms.Button();
            this.Text_ServerPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_ServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Bt_SaveBrowser = new System.Windows.Forms.Button();
            this.Text_SavePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveLogListBox = new System.Windows.Forms.GroupBox();
            this.ListBox_LogMsg = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DelFileTime = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Check_SaveFileAS = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Text_DelFileTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_ServerPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SaveLogListBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelFileTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_DelFileTime)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AutoStart);
            this.groupBox1.Controls.Add(this.StopListent);
            this.groupBox1.Controls.Add(this.StartListent);
            this.groupBox1.Controls.Add(this.Text_ServerPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Text_ServerIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务端配置";
            // 
            // AutoStart
            // 
            this.AutoStart.AutoSize = true;
            this.AutoStart.Location = new System.Drawing.Point(352, 30);
            this.AutoStart.Name = "AutoStart";
            this.AutoStart.Size = new System.Drawing.Size(120, 16);
            this.AutoStart.TabIndex = 6;
            this.AutoStart.Text = "随电脑启动并监听";
            this.AutoStart.UseVisualStyleBackColor = true;
            this.AutoStart.Click += new System.EventHandler(this.AutoStart_Click);
            // 
            // StopListent
            // 
            this.StopListent.Enabled = false;
            this.StopListent.Location = new System.Drawing.Point(572, 25);
            this.StopListent.Name = "StopListent";
            this.StopListent.Size = new System.Drawing.Size(75, 23);
            this.StopListent.TabIndex = 5;
            this.StopListent.Text = "停止监听";
            this.StopListent.UseVisualStyleBackColor = true;
            this.StopListent.Click += new System.EventHandler(this.StopListent_Click);
            // 
            // StartListent
            // 
            this.StartListent.Enabled = false;
            this.StartListent.Location = new System.Drawing.Point(491, 26);
            this.StartListent.Name = "StartListent";
            this.StartListent.Size = new System.Drawing.Size(75, 23);
            this.StartListent.TabIndex = 4;
            this.StartListent.Text = "启动监听";
            this.StartListent.UseVisualStyleBackColor = true;
            this.StartListent.Click += new System.EventHandler(this.StartListent_Click);
            // 
            // Text_ServerPort
            // 
            this.Text_ServerPort.Location = new System.Drawing.Point(262, 27);
            this.Text_ServerPort.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.Text_ServerPort.Name = "Text_ServerPort";
            this.Text_ServerPort.Size = new System.Drawing.Size(51, 21);
            this.Text_ServerPort.TabIndex = 3;
            this.Text_ServerPort.Value = new decimal(new int[] {
            1984,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "监听端口：";
            // 
            // Text_ServerIP
            // 
            this.Text_ServerIP.Location = new System.Drawing.Point(71, 27);
            this.Text_ServerIP.Name = "Text_ServerIP";
            this.Text_ServerIP.Size = new System.Drawing.Size(100, 21);
            this.Text_ServerIP.TabIndex = 1;
            this.Text_ServerIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务端IP：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Bt_SaveBrowser);
            this.groupBox2.Controls.Add(this.Text_SavePath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(652, 66);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件保存设置";
            // 
            // Bt_SaveBrowser
            // 
            this.Bt_SaveBrowser.Location = new System.Drawing.Point(571, 25);
            this.Bt_SaveBrowser.Name = "Bt_SaveBrowser";
            this.Bt_SaveBrowser.Size = new System.Drawing.Size(75, 23);
            this.Bt_SaveBrowser.TabIndex = 2;
            this.Bt_SaveBrowser.Text = "浏览";
            this.Bt_SaveBrowser.UseVisualStyleBackColor = true;
            this.Bt_SaveBrowser.Click += new System.EventHandler(this.Text_SaveBrowser_Click);
            // 
            // Text_SavePath
            // 
            this.Text_SavePath.Location = new System.Drawing.Point(70, 27);
            this.Text_SavePath.Name = "Text_SavePath";
            this.Text_SavePath.ReadOnly = true;
            this.Text_SavePath.Size = new System.Drawing.Size(495, 21);
            this.Text_SavePath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "保存路径：";
            // 
            // SaveLogListBox
            // 
            this.SaveLogListBox.Controls.Add(this.ListBox_LogMsg);
            this.SaveLogListBox.Location = new System.Drawing.Point(12, 298);
            this.SaveLogListBox.Name = "SaveLogListBox";
            this.SaveLogListBox.Size = new System.Drawing.Size(652, 221);
            this.SaveLogListBox.TabIndex = 2;
            this.SaveLogListBox.TabStop = false;
            this.SaveLogListBox.Text = "传输日志";
            // 
            // ListBox_LogMsg
            // 
            this.ListBox_LogMsg.FormattingEnabled = true;
            this.ListBox_LogMsg.HorizontalScrollbar = true;
            this.ListBox_LogMsg.ItemHeight = 12;
            this.ListBox_LogMsg.Location = new System.Drawing.Point(12, 21);
            this.ListBox_LogMsg.Name = "ListBox_LogMsg";
            this.ListBox_LogMsg.Size = new System.Drawing.Size(624, 184);
            this.ListBox_LogMsg.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "局域网文件传输工具-接收端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.DelFileTime);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.Check_SaveFileAS);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.Text_DelFileTime);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(13, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(651, 105);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件另存设置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(477, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "点开始删除过期文件";
            // 
            // DelFileTime
            // 
            this.DelFileTime.Enabled = false;
            this.DelFileTime.Location = new System.Drawing.Point(425, 18);
            this.DelFileTime.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.DelFileTime.Name = "DelFileTime";
            this.DelFileTime.Size = new System.Drawing.Size(46, 21);
            this.DelFileTime.TabIndex = 5;
            this.DelFileTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(388, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "每天";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(12, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(449, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "未选中“按传输时间另存文件”程序会按传输的文件名存储文件，并覆盖同名文件。";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(10, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(461, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "选中“按传输时间另存文件”需要设置自动删除之前几天的文件，防止硬盘容量不够。";
            // 
            // Check_SaveFileAS
            // 
            this.Check_SaveFileAS.AutoSize = true;
            this.Check_SaveFileAS.Location = new System.Drawing.Point(14, 23);
            this.Check_SaveFileAS.Name = "Check_SaveFileAS";
            this.Check_SaveFileAS.Size = new System.Drawing.Size(132, 16);
            this.Check_SaveFileAS.TabIndex = 5;
            this.Check_SaveFileAS.Text = "按传输时间另存文件";
            this.Check_SaveFileAS.UseVisualStyleBackColor = true;
            this.Check_SaveFileAS.Click += new System.EventHandler(this.Check_SaveFileAS_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "天的文件";
            // 
            // Text_DelFileTime
            // 
            this.Text_DelFileTime.Enabled = false;
            this.Text_DelFileTime.Location = new System.Drawing.Point(222, 18);
            this.Text_DelFileTime.Name = "Text_DelFileTime";
            this.Text_DelFileTime.Size = new System.Drawing.Size(55, 21);
            this.Text_DelFileTime.TabIndex = 3;
            this.Text_DelFileTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "保留近";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(504, 532);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(155, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Author:PsuAiJe 2011-09-16";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 532);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(329, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "接收端程序以在服务器上测试10天以上，占用内存15MB左右。";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 25);
            this.menuStrip1.TabIndex = 6;
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
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.退出EToolStripMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            this.帮助HToolStripMenuItem.Click += new System.EventHandler(this.帮助HToolStripMenuItem_Click);
            // 
            // frm_NetServer_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 558);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SaveLogListBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frm_NetServer_Main";
            this.Text = "局域网文件传输—服务端 v1.2 ";
            this.Load += new System.EventHandler(this.frm_NetServer_Main_Load);
            this.SizeChanged += new System.EventHandler(this.frm_NetServer_Main_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Text_ServerPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SaveLogListBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelFileTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text_DelFileTime)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StopListent;
        private System.Windows.Forms.Button StartListent;
        private System.Windows.Forms.NumericUpDown Text_ServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Text_ServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Bt_SaveBrowser;
        private System.Windows.Forms.TextBox Text_SavePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox SaveLogListBox;
        private System.Windows.Forms.ListBox ListBox_LogMsg;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Text_DelFileTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Check_SaveFileAS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown DelFileTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.CheckBox AutoStart;
    }
}

