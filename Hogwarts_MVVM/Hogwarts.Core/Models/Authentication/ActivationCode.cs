﻿using System;
using System.Linq;

namespace Hogwarts.Core.Models.Authentication
{
    public sealed class ActivationCode: Entity
    {
        public string Username { get; set; }
        public string Code { get; set; }
        public ActivationCode(string username)
            : base()
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
