using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hogwarts_Management_System.Models
{
    public abstract class User
    {
        public string PasswordHash { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length <= 6)
                    throw new ArgumentException("Username must be at least 6 characters.");

                _username = value;
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("First name can not be null.");

                _firstName = value;
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Last name can not be null.");

                _lastName = value;
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))      // <username>@<domain>.<tld>
                {
                    throw new ArgumentException("Invalid Email");
                }
                _email = value;
            }
        }
    }
}
