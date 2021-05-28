using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GestionDesAbsence.Common
{
    public static class Encryption
    {
        public static string Key = "Csrsx8&amp;GoD3yt@YJhSCbGQ1u";

        public static string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password + Key));
        }        
        
        public static string Decrypt(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword)) return "";

            var encrypte =   Convert.FromBase64String(encryptedPassword);
            var res = Encoding.UTF8.GetString(encrypte);
            res = res.Substring(0, res.Length - Key.Length);

            return res;
        }
    }
}