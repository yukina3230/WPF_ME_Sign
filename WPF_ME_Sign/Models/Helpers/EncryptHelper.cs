using OracleInternal.Secure.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MD5 = System.Security.Cryptography.MD5;

namespace WPF_ME_Sign.Models.Helpers
{
    public static class EncryptHelper
    {
        public static string EncodeString(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
