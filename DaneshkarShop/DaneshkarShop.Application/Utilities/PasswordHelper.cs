﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DaneshkarShop.Application.Utilities
{
    public static class PasswordHelper
    {
        //Encrypt using Md5
        public static string EncodePasswordMd5(string pass)
        {
            Byte[] originalBytes;
            Byte[] encodeBytes;
            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodeBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodeBytes);

        }
    }
}
