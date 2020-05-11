using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
namespace NetClient
{
    public class FileSendThread_Class
    {
        public void StartSendFile(string IP, string Port, string FilePath, string PackSize, string LastPackSize, string PackCount)
        {
            try
            {

                //指向远程服务器
                IPEndPoint iped = new IPEndPoint(IPAddress.Parse(IP), int.Parse(Port));
                //创建套接字
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //连接到远程服务器
                client.Connect(iped);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
