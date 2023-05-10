using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Hogwarts.Core.Models.Authentication
{
    public class PasswordService: IPasswordService
    {
        public string GetHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        public bool IsStrong(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));
            }

            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
        }

        public bool IsValid(string password,
                            string passwordRepeat)
        {
            if (string.IsNullOrEmpty(passwordRepeat))
            {
                throw new ArgumentException($"'{nameof(passwordRepeat)}' cannot be null or empty.", nameof(passwordRepeat));
            }

            if (password != passwordRepeat)
                return false;

            return true;
        }
    }
}
