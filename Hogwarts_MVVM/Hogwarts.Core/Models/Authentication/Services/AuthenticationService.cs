using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;
using System;
using System.Linq;
using System.Security.Authentication;
using System.Text.RegularExpressions;

namespace Hogwarts.Core.Models.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HogwartsDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        private readonly LetterService _letterService;

        public AuthenticationService(HogwartsDbContext dbContext, IPasswordService passwordService, LetterService letterService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _letterService = letterService;
        }

        public bool IsUsernameTaken(string username)   
        {
            return _dbContext.Students.Any(u => u.Username == username) ||
                   _dbContext.Professors.Any(u => u.Username == username) ||
                   _dbContext.Admins.Any(u => u.Username == username);
        }

        public bool IsActivationCodeVaild(string username, string enteredCode)
        {
            return _dbContext.ActivationCodes.Any(ac => ac.Username == username && ac.Code == enteredCode);
        }

        public void SignUpStudent(StudentRegistrationDTO DTO)
        {
            if (IsUsernameTaken(DTO.Username))
                throw new ArgumentException("Username already taken.");

            if (!_passwordService.IsValid(DTO.Password, DTO.PasswordRepeat))
                throw new ArgumentException("The entered passwords do not match.");

            if (!_passwordService.IsStrong(DTO.Password))
                throw new ArgumentException("Password must be at least 8 characters and contain upper and lower letters.");

            if (!IsActivationCodeVaild(DTO.Username, DTO.EnteredActivationCode))
                throw new ArgumentException("Invalid activation code.");

            string passwordHash = _passwordService.GetHash(DTO.Password);

            Student student = new(DTO, passwordHash);

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void SignUpProfessor(ProfessorRegistrationDTO DTO)
        {
            if (IsUsernameTaken(DTO.Username))
                throw new ArgumentException("Username already taken.");

            if (!_passwordService.IsValid(DTO.Password, DTO.PasswordRepeat))
                throw new ArgumentException("The entered passwords do not match.");

            if (!_passwordService.IsStrong(DTO.Password))
                throw new ArgumentException("Password must be at least 8 characters and contain upper and lower letters.");

            string passwordHash = _passwordService.GetHash(DTO.Password);

            Professor professor = new(DTO, passwordHash);
            _dbContext.Professors.Add(professor);
            _dbContext.SaveChanges();
        }

        public void SignUpAdmin(AdminRegistrationDTO DTO)
        {
            if (IsUsernameTaken(DTO.Username))
                throw new ArgumentException("Username already taken.");

            if (!_passwordService.IsValid(DTO.Password, DTO.PasswordRepeat))
                throw new ArgumentException("The entered passwords do not match.");

            if (!_passwordService.IsStrong(DTO.Password))
                throw new ArgumentException("Password must be at least 8 characters and contain upper and lower letters.");

            string passwordHash = _passwordService.GetHash(DTO.Password);

            Admin admin = new(DTO, passwordHash);
            _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();
        }

        public void Login(string username, string password)
        {
            string passwordHash = _passwordService.GetHash(password);

            var session = SessionManager.CurrentSession;
            if (session != null && !session.HasExpired)
            {
                throw new InvalidOperationException("There is an active session. Please logout first.");
            }

            User? student = _dbContext.Students.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);
            User? professor = _dbContext.Professors.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);
            User? admin = _dbContext.Admins.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);

            User? loggedInUser = student ?? professor ?? admin;

            if (loggedInUser == null)
            {
                throw new InvalidCredentialException("Wrong username or password!");
            }
            else
            {
                session = new Session(loggedInUser);
            }
        }
        public void Logout()
        {
            SessionManager.CurrentSession?.Revoke();
        }

        public void EnrollStudent(Admin admin, string firstName, string lastName, string username, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName), "First name can not be null or empty.");

            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName), "Last name can not be null or empty.");

            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username), "Last name can not be null or empty.");

            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException(nameof(emailAddress), "Last name can not be null or empty.");

            if (username.Length < 6)
                throw new ArgumentOutOfRangeException("Username must be at least 6 characters");

            if (!Regex.IsMatch(emailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))      // <username>@<HOGWARTS_API_DOMAIN>.<tld>
            {
                throw new ArgumentException("Invalid Email");
            }


            ActivationCode activationCode = new(username);
            _dbContext.ActivationCodes.Add(activationCode);
            _dbContext.SaveChanges();

            _letterService.SendInvitationMail(admin, firstName, lastName, emailAddress, activationCode);
        }

    }
}
