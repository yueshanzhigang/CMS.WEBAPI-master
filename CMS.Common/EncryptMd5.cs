﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace CMS.Common
{
    public class EncryptMd5
    {
        /// <summary>
        /// Md5加密(转大写)
        /// </summary>
        /// <param name="source">明文</param>
        /// <returns></returns>
        public string EncryptByte(string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                string hash = sBuilder.ToString();
                return hash.ToUpper();
            }
        }
    }
}
