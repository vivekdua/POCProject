using System;
using System.Text;
using System.Security.Cryptography;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter password in simple text : ");

            string passwordInSimpleText = "S57O2K0YAe";
            Console.WriteLine();
            Console.WriteLine("Password in MD5 Hash format : " + MD5Hash(passwordInSimpleText));
            string pwd = MD5Hash(passwordInSimpleText);
            Console.WriteLine();
            Console.Write("Press Enter to Exit....");
            Console.Read();
        }

        public static string ComputeHashSHA1(string plainText, String saltBytes)
        {
            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            HashAlgorithm hash = new SHA1Managed();

            // Compute hash value of our plain text 
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);

            string hashValue = "";
            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashValue += Convert.ToString(((hashBytes[i] & 0xff) + 0x100), 16).Substring(1);
            }
            // Return the result.
            return hashValue;
        }

        static string MD5Hash(string passwordInSimpleText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passwordInSimpleText));
            StringBuilder strBuilder = new StringBuilder();
            for (int index = 0; index < result.Length; index++)
            {
                strBuilder.Append(result[index].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}