using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using NetClassLibrary;
using System.Diagnostics;



namespace NetServer
{
    public class StartThreads : IDisposable
    {
        /// <summary>
        /// 传入的Socket实例
        /// </summary>
        private Socket socket;
        /// <summary>
        /// 定义私有的线程
        /// </summary>
        private Thread thread;
        /// <summary>
        /// 是否坚挺中
        /// </summary>
        private bool isListenner;
        /// <summary>
        /// 保存文件的位置
        /// </summary>
        private string saveFilePath;

        //private string OldFileMD5;

        /// <summary>
        /// 是否按发送时间另存文件
        /// </summary>
        private string SaveASSate;
        /// <summary>
        /// 删除多少天之前的文件
        /// </summary>
        //private int DelOldFileTime;

        private frm_NetServer_Main _objForm;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="socket">Socket实例</param>
        /// <param name="objForm">窗体实例</param>
        /// <param name="filePath">文件保存位置</param>
        /// <param name="SaveAS">按发送时间另存设置</param>
        /// <param name="DelTime">删除多少天之前的文件</param>
        public StartThreads(Socket socket, frm_NetServer_Main objForm, string filePath , string SaveAS )
        {
            this.socket = socket;
            isListenner = true;
            this._objForm = objForm;
            saveFilePath = filePath;

            this.SaveASSate = SaveAS;

           // this.DelOldFileTime = DelTime;

            thread = new Thread(new ThreadStart(test));
            thread.Start();

        }



        #region 测试用方法
        private void test()
        {
            string FileLastName;
            //是否修改文件名
            bool EditEx = false;
            //MessageBox.Show(DelOldFileTime.ToString());
            
            //try
            //{
                //获取线程ID
                string ThID = Thread.CurrentThread.ManagedThreadId.ToString();


                IPEndPoint clientep = (IPEndPoint)socket.RemoteEndPoint;
                //显示服务端信息
                

                //开始接受数据
                //接受文件名
                string fileName = System.Text.Encoding.Unicode.GetString(TransferFiles.ReceiveVarData(socket));
                //接受文件大小
                string fileSize = System.Text.Encoding.Unicode.GetString(TransferFiles.ReceiveVarData(socket));
                //接受包的大小
                string filebagSize = System.Text.Encoding.Unicode.GetString(TransferFiles.ReceiveVarData(socket));
                //接受包的数量
                string filebagCount = System.Text.Encoding.Unicode.GetString(TransferFiles.ReceiveVarData(socket));
                //接受最后一个包的大小
                string fileLastbagSize = System.Text.Encoding.Unicode.GetString(TransferFiles.ReceiveVarData(socket));
                //接受文件MD5值
                //string fileMD5 = System.Text.Encoding.Unicode.GetString(TransferFiles.ReceiveVarData(socket));

                if (fileName != "" && fileSize != "")
                {
                    _objForm.SetListBoxMsg = "开始接受数据！";
                    _objForm.SetListBoxMsg = "线程[" + ThID + "]文件名为：【" + fileName + "】";
                    _objForm.SetListBoxMsg = "线程[" + ThID + "]文件大小：【" + fileSize + "】字节";
                    _objForm.SetListBoxMsg = "线程[" + ThID + "]单个包大小：【" + filebagSize + "】字节";
                    _objForm.SetListBoxMsg = "线程[" + ThID + "]共发送：【" + filebagCount + "】个数据包";
                    _objForm.SetListBoxMsg = "线程[" + ThID + "]最后一个包：【" + fileLastbagSize + "】字节";
                   
                    //_objForm.SetListBoxMsg = "发送文件MD5值：[" + fileMD5 + "]";

                    //获取文件后缀名
                    FileLastName = fileName.Substring(fileName.LastIndexOf("."));

                    string SaveFile = saveFilePath + "\\" + fileName.Substring(0, fileName.LastIndexOf(".")) + ".SDM";
                    //判断是否按发送时间另存文件
                    if (SaveASSate == "Checked")
                    {
                        
                        SaveFile = saveFilePath + "\\" + fileName.Substring(0, fileName.LastIndexOf(".")) +"-"+ System.DateTime.Now.ToString().Replace(":", "").Replace("-", "").Replace(" ", "") + "-" + Tools.GetRandomStringOnly(5) + ".SDM";
                        //设置修改文件名
                        EditEx = true;
                         //MessageBox.Show(SaveFile);

                    }
                    else
                    {
                        //当文件以覆盖形式保存时，直接使用原始文件名及后缀
                        SaveFile = saveFilePath + "\\" + fileName.Substring(0, fileName.LastIndexOf(".")) + FileLastName;
                    }


                    System.IO.FileStream _myFileStream = new System.IO.FileStream(SaveFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                    int SendBagCount = 0;
                    _objForm.SetListBoxMsg = "线程[" + ThID + "][" + System.DateTime.Now.ToString() + "]:【" + fileName + "】正在接收中...";
                    while (true)
                    {
                        byte[] data = TransferFiles.ReceiveVarData(socket);
                        if (data.Length == 0)
                        {
                            break;
                        }
                        else
                        {
                            SendBagCount++;
                            _myFileStream.Write(data, 0, data.Length);
                            //_objForm.SetListBoxMsg = "已经接收" + SendBagCount.ToString() + "个数据包";


                        }

                        if (Convert.ToInt64(_myFileStream.Length) == Convert.ToInt64(fileSize))
                        {
                            ////接受文件MD5值
                            //OldFileMD5 = System.Text.Encoding.Unicode.GetString(TransferFiles.ReceiveVarData(socket));

                            //_objForm.SetListBoxMsg = "线程[" + ThID + "]原始文件MD5值：【" + OldFileMD5 + "】";

                            

                            _objForm.SetListBoxMsg = "线程[" + ThID + "][" + System.DateTime.Now.ToString() + "]:【" + fileName + "】接收完毕，服务端与客户端文件大小相同！";
                        }
                    }

                    _myFileStream.Dispose();
                    _myFileStream.Close();

                    System.IO.FileInfo f = new System.IO.FileInfo(SaveFile);
                    if (EditEx == true)
                    {
                        //把文件改名为传输文件名
                        f.MoveTo(SaveFile.Substring(0, SaveFile.LastIndexOf(".")) + FileLastName);
                        EditEx = false;
                    }
                    
                   
                }

                socket.Close();
                _objForm.SetListBoxMsg = "线程[" + ThID + "]客户端连接已经断开！";
                

                    _objForm.SetListBoxMsg = "***********************************************";
                //Thread.CurrentThread.Abort();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        #endregion




         public void Dispose()
        {

            isListenner = false;
            //确定线程状态是否为空，并结束该线程
            if (thread != null)
            {
                if (thread.ThreadState != System.Threading.ThreadState.Aborted)
                {
                    thread.Abort();
                }
                thread = null;
            }

            //判断连接是否已经断开。并结断开该连接
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }





    }
}
