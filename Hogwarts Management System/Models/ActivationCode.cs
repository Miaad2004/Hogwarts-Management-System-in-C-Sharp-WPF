using System;
using System.Linq;

namespace Hogwarts_Management_System.Models
{
    public sealed class ActivationCode
    {
        public string Username { get; set; }
        public string Code { get; set; }
        public ActivationCode(string username)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var codeChars = Enumerable.Repeat(chars, 6)
                                      .Select(s => s[random.Next(s.Length)]);
            Code = new string(codeChars.ToArray());
            Username = username;
        }

    }
}
