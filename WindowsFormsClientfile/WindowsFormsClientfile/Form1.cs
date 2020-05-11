﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClientfile
{
    public partial class Form1 : Form
    {
        Thread threadClient = null; // 创建用于接收服务端消息的 线程；
        Socket sockClient = null;
        delegate void myInvoke(string msg);//定义一个自己的委托
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(textBox1.Text.Trim());
            IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(textBox2.Text.Trim()));
            sockClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                ShowMsg("与服务器连接中……");
                sockClient.Connect(endPoint);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
                return;
                //this.Close();
            }
            ShowMsg("与服务器连接成功！！！");
            threadClient = new Thread(RecMsg);
            threadClient.IsBackground = true;
            threadClient.Start();
        }
        string fileSavePath = Directory.GetCurrentDirectory() + "\\RecFile\\";
        void RecMsg()
        {
            myInvoke myinvoke = new myInvoke(ShowMsg);
            while (true)
            {
                // 定义一个2M的缓存区；
                byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                // 将接受到的数据存入到输入 arrMsgRec中；
                int length = -1;
                try
                {
                    length = sockClient.Receive(arrMsgRec); // 接收数据，并返回数据的长度；
                }
                catch (SocketException se)
                {
                    this.Invoke(myinvoke, "异常；" + se.Message);
                    return;
                }
                catch (Exception e)
                {
                    this.Invoke(myinvoke, "异常；" + e.Message);
                    return;
                }
                if (arrMsgRec[0] == 0) // 表示接收到的是消息数据；
                {
                    string strMsg = System.Text.Encoding.UTF8.GetString(arrMsgRec, 1, length - 1);// 将接受到的字节数据转化成字符串；
                    if (!strMsg.Contains("-->"))
                    {
                        fileSavePath = fileSavePath + strMsg.Split(':')[1].Replace("\r\n", "");
                    }
                    this.Invoke(myinvoke, strMsg);
                }
                if (arrMsgRec[0] == 1) // 表示接收到的是文件数据；
                {
                    try
                    {
                        // 创建文件流，然后根据路径创建文件；
                        using (FileStream fs = new FileStream(fileSavePath, FileMode.Create))
                        {
                            fs.Write(arrMsgRec, 1, length - 1);
                            this.Invoke(myinvoke, "文件保存成功：" + fileSavePath);
                        }
                    }
                    catch (Exception aaa)
                    {
                        this.Invoke(new Action(() => { MessageBox.Show(aaa.Message); }));
                    }
                }
            }
        }
        void ShowMsg(string str)
        {
            listBox1.Items.Add(str + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strMsg = textBox3.Text.Trim() + "\r\n" + " -->" + textBox4.Text.Trim() + "\r\n";
            byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
            byte[] arrSendMsg = new byte[arrMsg.Length + 1];//多一位,只是为了存放一个标识位.
            arrSendMsg[0] = 0; // 用来表示发送的是消息数据
            Buffer.BlockCopy(arrMsg, 0, arrSendMsg, 1, arrMsg.Length);
            sockClient.Send(arrSendMsg); // 发送消息；
            ShowMsg(strMsg);
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox5.Text = ofd.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("请选择要发送的文件！！！");
            }
            else
            {
                // 用文件流打开用户要发送的文件；
                using (FileStream fs = new FileStream(textBox5.Text, FileMode.Open))
                {
                    //在发送文件以前先给好友发送这个文件的名字+扩展名，方便后面的保存操作；
                    string fileName = System.IO.Path.GetFileName(textBox5.Text);
                    string fileExtension = System.IO.Path.GetExtension(textBox5.Text);
                    string strMsg = "我给你发送的文件为:" + fileName + "\r\n";
                    byte[] arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
                    byte[] arrSendMsg = new byte[arrMsg.Length + 1];
                    arrSendMsg[0] = 0; // 用来表示发送的是消息数据
                    Buffer.BlockCopy(arrMsg, 0, arrSendMsg, 1, arrMsg.Length);
                    sockClient.Send(arrSendMsg); // 发送消息；
                    byte[] arrFile = new byte[1024 * 1024 * 2];
                    int length = fs.Read(arrFile, 0, arrFile.Length); // 将文件中的数据读到arrFile数组中；
                    byte[] arrFileSend = new byte[length + 1];
                    arrFileSend[0] = 1; // 用来表示发送的是文件数据；
                    Buffer.BlockCopy(arrFile, 0, arrFileSend, 1, length);
                    // 还有一个 CopyTo的方法，但是在这里不适合； 当然还可以用for循环自己转化；
                    sockClient.Send(arrFileSend);// 发送数据到服务端；
                    textBox5.Clear();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
