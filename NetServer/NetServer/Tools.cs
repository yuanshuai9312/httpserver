using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace NetServer
{
    public class Tools
    {

        #region 生成随即字符串
        private static string sCharUpp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 生成随即数
        /// </summary>
        /// <param name="StrLength">生成随机数的长度</param>
        /// <returns></returns>
        public static string GetRandomStringOnly(int StrLength)
        {
            return BuildRndCodeOnly(sCharUpp, StrLength);  
        }


        private static string BuildRndCodeOnly(string StrOf, int strLen)
        {
            System.Random RandomObj = new System.Random(GetNewSeed());
            string buildRndCodeReturn = null;
            for (int i = 0; i < strLen; i++)
            {
                buildRndCodeReturn += StrOf.Substring(RandomObj.Next(0, StrOf.Length - 1), 1);
            }
            return buildRndCodeReturn;
        }


        private static int GetNewSeed()
        {
            byte[] rndBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(rndBytes);
            return BitConverter.ToInt32(rndBytes, 0);
        }

        #endregion
    }
}
