using System;
using System.Security.Cryptography;
using System.Text;

namespace FinalProject.Core.Utilities.Security.Hashing
{
    public class HashPassword
    {
        public static string ComputeSha512Hash(string value)
        {
            using (var sha256 = SHA512.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
                string hashedValue = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hashedValue;
            }
        }
    }
}
