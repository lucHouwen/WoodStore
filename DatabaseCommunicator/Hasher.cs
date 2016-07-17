using System;
using System.Security.Cryptography;
using System.Text;

namespace DatabaseCommunicator
{
    public class Hasher
    {
        public static string Hash(string password)
        {
            return Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.UTF32.GetBytes(password)));
        }
    }    
}