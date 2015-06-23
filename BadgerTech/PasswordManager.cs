using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


namespace BadgerTech
{
    public class PasswordManager
    {
      
        public static string CreateSalt(string UserName)
        {
            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(UserName,
                Encoding.UTF8.GetBytes("DoTheSaltyDance"), 1000);
            return Convert.ToBase64String(hasher.GetBytes(25));
        }

        public static string HashPassword(string Salt, string Password)
        {
            Rfc2898DeriveBytes Hasher = new Rfc2898DeriveBytes(Password,
                Encoding.UTF8.GetBytes(Salt), 1000);
            return Convert.ToBase64String(Hasher.GetBytes(25));
        }

        public static bool Verify(string UserSalt, string UserPass)
        {
            return MyUser._Hash == HashPassword(UserSalt, UserPass);
        }

    }
}
