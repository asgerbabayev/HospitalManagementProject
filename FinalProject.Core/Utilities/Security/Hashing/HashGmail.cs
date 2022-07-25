using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.Utilities.Security.Hashing
{
    public class HashGmail
    {
        public static string Base64UrlEncode(string input)
        {
            var data = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(data).Replace("+", "-").Replace("/", "_").Replace("=", "");
        }
    }
}
