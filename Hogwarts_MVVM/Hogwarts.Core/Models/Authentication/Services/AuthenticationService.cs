using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication.Exceptions;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;
using System.Security.Authentication;
using System.Text.RegularExpressions;

namespace Hogwarts.Core.Models.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HogwartsDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        private readonly ILetterService _letterService;

        public AuthenticationService(HogwartsDbContext dbContext, IPasswordService passwordService, ILetterService letterService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _letterService = letterService;
        }

        private bool IsUsernameTaken(string username)
        {
            return _dbContext.Students.Any(u => u.Username == username) ||
                   _dbContext.Professors.Any(u => u.Username == username) ||
                   _dbContext.Admins.Any(u => u.Username == username);
        }

        private bool IsActivationCodeVaild(string username, string enteredCode)
        {
            return _dbContext.ActivationCodes.Any(ac => ac.Username == username && ac.Code == enteredCode);
        }

        public void SignUpStudent(StudentRegistrationDTO DTO)
        {
            if (IsUsernameTaken(DTO.Username))
            {
                throw new UserExistsException("Username already taken.");
            }

            if (!_passwordService.IsValid(DTO.Password, DTO.PasswordRepeat))
            {
                throw new ArgumentException("The entered passwords do not match.");
            }

            if (!_passwordService.IsStrong(DTO.Password))
            {
                throw new ArgumentException("Password must be at least 8 characters and contain upper and lower letters.");
            }

            if (!IsActivationCodeVaild(DTO.Username, DTO.EnteredActivationCode))
            {
                throw new ArgumentException("Invalid activation code.");
            }

            string passwordHash = _passwordService.GetHash(DTO.Password);

            Student student = new(DTO, passwordHash);

            _ = _dbContext.Students.Add(student);
            _ = _dbContext.SaveChanges();
        }

        public void SignUpProfessor(ProfessorRegistrationDTO DTO)
        {
            if (IsUsernameTaken(DTO.Username))
            {
                throw new UserExistsException("Username already taken.");
            }

            if (!_passwordService.IsValid(DTO.Password, DTO.PasswordRepeat))
            {
                throw new ArgumentException("The entered passwords do not match.");
            }

            if (!_passwordService.IsStrong(DTO.Password))
            {
                throw new ArgumentException("Password must be at least 8 characters and contain upper and lower letters.");
            }

            string passwordHash = _passwordService.GetHash(DTO.Password);

            Professor professor = new(DTO, passwordHash);
            _ = _dbContext.Professors.Add(professor);
            _ = _dbContext.SaveChanges();
        }

        public void SignUpAdmin(AdminRegistrationDTO DTO)
        {
            if (IsUsernameTaken(DTO.Username))
            {
                throw new UserExistsException("Username already taken.");
            }

            if (!_passwordService.IsValid(DTO.Password, DTO.PasswordRepeat))
            {
                throw new ArgumentException("The entered passwords do not match.");
            }

            if (!_passwordService.IsStrong(DTO.Password))
            {
                throw new ArgumentException("Password must be at least 8 characters and contain upper and lower letters.");
            }

            string passwordHash = _passwordService.GetHash(DTO.Password);

            Admin admin = new(DTO, passwordHash);
            _ = _dbContext.Admins.Add(admin);
            _ = _dbContext.SaveChanges();
        }

        public void Login(string username, string password)
        {
            username = username.ToLower();

            string passwordHash = _passwordService.GetHash(password);

            Session? session = SessionManager.CurrentSession;
            if (session != null && !session.HasExpired)
            {
                throw new InvalidOperationException("There is an active session. Please logout first.");
            }

            User? student = _dbContext.Students.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);
            User? professor = _dbContext.Professors.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);
            User? admin = _dbContext.Admins.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);

            User? loggedInUser = student ?? professor ?? admin;

            SessionManager.CurrentSession = loggedInUser == null ? throw new InvalidCredentialException("Wrong username or password!") : new Session(loggedInUser);
        }
        public void Logout()
        {
            SessionManager.CurrentSession?.Revoke();
        }

        public void EnrollStudent(string firstName, string lastName, string username, string emailAddress)
        {
            if (SessionManager.CurrentSession == null ||
                SessionManager.CurrentSession.User.AccessLevel != AccessLevels.Admin)
            {
                throw new UnauthorizedAccessException();
            }

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException(nameof(firstName), "First name can not be null or empty.");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException(nameof(lastName), "Last name can not be null or empty.");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username), "User name can not be null or empty.");
            }

            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException(nameof(emailAddress), "Email Address can not be null or empty.");
            }

            if (username.Length < 6)
            {
                throw new ArgumentOutOfRangeException("Username must be at least 6 characters");
            }

            if (!Regex.IsMatch(emailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))      // <username>@<HOGWARTS_API_DOMAIN>.<tld>
            {
                throw new ArgumentException("Invalid Email");
            }


            ActivationCode activationCode = new(username);
            _ = _dbContext.ActivationCodes.Add(activationCode);
            _ = _dbContext.SaveChanges();

            _letterService.SendInvitationMail(sender: SessionManager.CurrentSession.User, firstName, lastName,
                                              emailAddress, activationCode);
        }

    }
}
