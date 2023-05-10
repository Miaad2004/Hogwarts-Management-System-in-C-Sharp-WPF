using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.StudentManagement;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Hogwarts.Core.Models.Authentication
{
    public abstract class User: Entity
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                    throw new ArgumentException("Username must be at least 5 characters.");

                _username = value;
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            protected set
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
            protected set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Last name can not be null.");

                _lastName = value;
            }
        }

        public string FullName
        {
            get { return $"{FirstName}, {LastName}"; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            protected set
            {
                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))      // <username>@<HOGWARTS_API_DOMAIN>.<tld>
                {
                    throw new ArgumentException("Invalid Email");
                }
                _email = value;
            }
        }

        private DateOnly _birthDate;
        public DateOnly BirthDate
        {
            get { return _birthDate; }
            protected set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("BirthDay can not be in the future.");
                _birthDate = value;
            }
        }


        public int Age => (int)(DateTime.Now.Year - BirthDate.Year);
        public BloodType BloodType { get; protected set; }
        public AccessLevel AccessLevel { get; protected set; }
        public string PasswordHash { get; protected set; }

        protected User()
        {

        }
        protected User(string username, string firstName, string lastName, string email, DateOnly birthDay,
                       BloodType bloodType, AccessLevel accessLevel, string passwordHash)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            BirthDate = birthDay;
            BloodType = bloodType;
            AccessLevel = accessLevel;
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        }

        protected User(BaseRegistrationDTO DTO, string passwordHash)
        {
            Username = DTO.Username ?? throw new ArgumentNullException(nameof(DTO.Username));
            FirstName = DTO.FirstName ?? throw new ArgumentNullException(nameof(DTO.FirstName));
            LastName = DTO.LastName ?? throw new ArgumentNullException(nameof(DTO.LastName));
            Email = DTO.Email ?? throw new ArgumentNullException(nameof(DTO.Email));
            BirthDate = DTO.BirthDate;
            BloodType = DTO.BloodType;
            AccessLevel = DTO.AccessLevel;
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        }
        public override string ToString()
        {
            return $"User {Username} - Full name: {FullName} - AccessLevel: {AccessLevel} - Email: {Email}";
        }
    }
}
