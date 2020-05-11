using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace NetClassLibrary
{
    public class FileTools
    {

        

        #region 获取文件的MD5值
        /// <summary>
        /// 返回文件的MD5值
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public   string GetFileMD5(string FilePath)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHasValue;

            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            try
            {
                oFileStream = new System.IO.FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                //计算文件的MD5值
                arrbytHasValue = oMD5Hasher.ComputeHash(oFileStream);
                oFileStream.Close();
                strHashData = System.BitConverter.ToString(arrbytHasValue);
                //替换掉计算出MD5值中的"-"
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
                //MessageBox.Show(strHashData);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return strResult;
        }
        #endregion

    }


     


}
