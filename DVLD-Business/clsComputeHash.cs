using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DVLD_Business
{
    public class clsComputeHash
    {
        private static string _ComputeHashHelper(string Message)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] EncodingMessage = Encoding.UTF8.GetBytes(Message);
                byte[] DigestBytes = sha.ComputeHash(EncodingMessage);

                return BitConverter.ToString(DigestBytes).ToString().ToLower()
                    .Replace("-", "");
            }
        }

        public static string ComputeHash(string Message)
        {
            return _ComputeHashHelper(Message);
        }
    }
}
