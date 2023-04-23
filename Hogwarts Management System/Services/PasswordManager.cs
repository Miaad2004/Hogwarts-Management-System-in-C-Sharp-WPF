using System;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace Hogwarts_Management_System.Services
{
    public static class PasswordManager
    {
        public static string GetHash(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        public static bool IsStrong(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
        }

        public static bool IsValid(string password, string passwordRepeat)
        {
            if (password != passwordRepeat)
                return false;
            return true;
        }

    }
}
