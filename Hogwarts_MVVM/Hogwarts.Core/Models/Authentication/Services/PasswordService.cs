using System.Security.Cryptography;
using System.Text;

namespace Hogwarts.Core.Models.Authentication.Services
{
    public class PasswordService : IPasswordService
    {
        public string GetHash(string? password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        public bool IsStrong(string? password)
        {
            return string.IsNullOrWhiteSpace(password)
                ? throw new ArgumentNullException(nameof(password))
                : password.Length >= 8 &&
                  password.Any(char.IsUpper) &&
                  password.Any(char.IsLower) &&
                  password.Any(char.IsDigit);
        }

        public bool IsValid(string? password,
                            string? passwordRepeat)
        {
            if (password is null) throw new ArgumentNullException(nameof(password));
            if (passwordRepeat is null) throw new ArgumentNullException(nameof(passwordRepeat));

            return password == passwordRepeat;
        }
    }
}
