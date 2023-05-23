using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;

namespace Hogwarts.Core.Models.Authentication
{
    public abstract class User : Entity
    {
        private string _username;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateOnly _birthdate;

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

        public string FirstName
        {
            get => _firstName;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name can not be null.");
                }

                value = value.ToLower();
                _firstName = char.ToUpper(value[0]) + value[1..];
            }
        }

        public string LastName
        {
            get => _lastName;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name can not be null.");
                }

                value = value.ToLower();
                _lastName = char.ToUpper(value[0]) + value[1..];
            }
        }

        public string Email
        {
            get => _email;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(Email)} can not be empty.");
                }

                if (!StaticMailService.IsValidEmail(value))
                {
                    throw new ArgumentException("Invalid Email!");
                }
                _email = value;
            }
        }

        public DateOnly Birthdate
        {
            get => _birthdate;
            protected set
            {
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new ArgumentException("Birthdate can not be in the future.");
                }

                _birthdate = value;
            }
        }

        public BloodType BloodType { get; protected set; }
        public AccessLevels AccessLevel { get; protected set; }
        public string PasswordHash { get; protected set; }
        public string FullProfileImagePath { get; private set; }
        public int Age => DateTime.Now.Year - Birthdate.Year;
        public string FullName => $"{FirstName}, {LastName}";

        protected User()
            : base()
        {

        }

        protected User(string username, string firstName, string lastName, string email, DateOnly birthDay,
                       BloodType bloodType, AccessLevels accessLevel, string passwordHash, string profileImagePath)
            : base()
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Birthdate = birthDay;
            BloodType = bloodType;
            AccessLevel = accessLevel;
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));

            SetProfileImagePath(profileImagePath);
        }

        protected User(BaseRegistrationDTO DTO, string passwordHash)
            : base()
        {
            Username = DTO.Username ?? throw new ArgumentNullException(nameof(DTO.Username));
            FirstName = DTO.FirstName ?? throw new ArgumentNullException(nameof(DTO.FirstName));
            LastName = DTO.LastName ?? throw new ArgumentNullException(nameof(DTO.LastName));
            Email = DTO.Email ?? throw new ArgumentNullException("Email can't be empty.");
            Birthdate = DTO.BirthDate;
            BloodType = DTO.BloodType;
            AccessLevel = DTO.AccessLevel;
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));

            SetProfileImagePath(DTO.ProfileImagePath);
        }

        private void SetProfileImagePath(string? profileImagePath)
        {
            if (profileImagePath is null || !File.Exists(profileImagePath))
            {
                throw new ArgumentException("Invalid profile image path.");
            }

            string subfolderName = "Hogwarts-Management-System";
            string subfolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                                                subfolderName, "ProfileImages");

            if (!Directory.Exists(subfolderPath))
            {
                Directory.CreateDirectory(subfolderPath);
            }

            string fullImagePath = Path.Combine(subfolderPath, this.Id.ToString() + Path.GetExtension(profileImagePath));

            File.Copy(profileImagePath, fullImagePath, overwrite: true);
            File.SetAttributes(fullImagePath, FileAttributes.ReadOnly);
            this.FullProfileImagePath = fullImagePath;
        }

        public override string ToString()
        {
            return $"User {Username} - Full name: {FullName} - AccessLevel: {AccessLevel} - Email: {Email}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Email);
        }
    }
}
