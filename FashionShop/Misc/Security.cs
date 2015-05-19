using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace FashionShop.Misc
{
    public class Security
    {
        public string encodeMD5(string hash)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(hash));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string encodeSHA1(string hash)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(hash));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string decodeBase64(string cipher)
        {
            var hash = Convert.FromBase64String(cipher);
            return Encoding.UTF8.GetString(hash);
        }

        public string generateID()
        {
            string time = DateTime.Now.ToString();

            return this.encodeSHA1(time);
        }
    }
}