using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.StudentManagement;
using System.IO;
using System.Text.RegularExpressions;
using System.Xaml;

namespace Hogwarts.Core.Models.Authentication
{
    public abstract class User : Entity
    {
        private string _username;
        public string Username
        {
            get => _username;
            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("Username must be at least 5 characters.(Not Case Sensitive)");
                }

                _username = value.ToLower();
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name can not be null.");
                }

                _firstName = value;
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name can not be null.");
                }

                _lastName = value;
            }
        }

        public string FullName => $"{FirstName}, {LastName}";

        private string _email;
        public string Email
        {
            get => _email;
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
            get => _birthDate;
            protected set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new ArgumentException("BirthDay can not be in the future.");
                }

                _birthDate = value;
            }
        }


        public int Age => DateTime.Now.Year - BirthDate.Year;
        public BloodType BloodType { get; protected set; }
        public AccessLevels AccessLevel { get; protected set; }
        public string PasswordHash { get; protected set; }
        public string FullProfileImagePath { get; private set; }

        protected User()
        {

        }
        protected User(string username, string firstName, string lastName, string email, DateOnly birthDay,
                       BloodType bloodType, AccessLevels accessLevel, string passwordHash, string profileImagePath)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            BirthDate = birthDay;
            BloodType = bloodType;
            AccessLevel = accessLevel;
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));

            if (!File.Exists(profileImagePath))
            {
                throw new ArgumentException("Invalid profile image path.");
            }

            SetProfileImagePath(profileImagePath);
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
            if (!File.Exists(DTO.ProfileImagePath))
            {
                throw new ArgumentException("Invalid profile image path.");
            }

            SetProfileImagePath(DTO.ProfileImagePath);
        }
        public override string ToString()
        {
            return $"User {Username} - Full name: {FullName} - AccessLevel: {AccessLevel} - Email: {Email}";
        }

        private void SetProfileImagePath(string profileImagePath)
        {
            string subfolderName = "Hogwarts-Management-System";
            string subfolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                                                subfolderName, "ProfileImages");

            if (!Directory.Exists(subfolderPath))
            {
                Directory.CreateDirectory(subfolderPath);
            }

            string fullImagePath = Path.Combine(subfolderPath, this.Id.ToString() + Path.GetExtension(profileImagePath));

            File.Copy(profileImagePath, fullImagePath, overwrite:true);
            File.SetAttributes(fullImagePath, FileAttributes.ReadOnly);
            this.FullProfileImagePath = fullImagePath;
        }
    }
}
