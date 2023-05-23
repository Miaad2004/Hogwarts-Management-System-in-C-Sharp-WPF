using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.Authentication.Exceptions;
using Hogwarts.Core.Models.DormitoryManagement.Services;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.HouseManagement.Services;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.SharedServices;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace Hogwarts.Core.Models.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HogwartsDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        private readonly ILetterService _letterService;
        private readonly IDormitoryService _dormitoryService;
        private readonly IHouseService _houseService;

        public AuthenticationService(HogwartsDbContext dbContext,
                                     IPasswordService passwordService,
                                     ILetterService letterService,
                                     IDormitoryService dormitoryService,
                                     IHouseService houseService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _letterService = letterService;
            _dormitoryService = dormitoryService;
            _houseService = houseService;
        }

        private async Task<bool> IsUsernameTakenAsync(string username)
        {
            username = username.ToLower();
            return await _dbContext.Students.AnyAsync(u => u.Username == username) ||
                   await _dbContext.Professors.AnyAsync(u => u.Username == username) ||
                   await _dbContext.Admins.AnyAsync(u => u.Username == username);
        }

        private async Task<bool> IsActivationCodeVaildAsync(string username, string enteredCode)
        {
            username = username.ToLower();
            return await _dbContext.ActivationCodes.AnyAsync(ac => ac.Username == username && ac.Code == enteredCode);
        }

        public async Task SignUpStudentAsync(StudentRegistrationDTO DTO)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            if (await IsUsernameTakenAsync(DTO.Username))
            {
                throw new UserExistsException(DTO.Username);
            }

            if (!_passwordService.IsValid(DTO.Password, DTO.PasswordRepeat))
            {
                throw new ArgumentException("The entered passwords do not match.");
            }

            if (!_passwordService.IsStrong(DTO.Password))
            {
                throw new ArgumentException("Password must be at least 8 characters and contain upper and lower letters.");
            }

            if (!await IsActivationCodeVaildAsync(DTO.Username, DTO.EnteredActivationCode))
            {
                throw new ArgumentException("Invalid activation code.");
            }

            string passwordHash = _passwordService.GetHash(DTO.Password);
            House house = await _houseService.SortAsync();

            Student student = new(DTO, passwordHash, house);
            student.DormitoryRoom = await _dormitoryService.GetRoomForNewStudentAsync(student);

            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SignUpProfessorAsync(ProfessorRegistrationDTO DTO)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            if (await IsUsernameTakenAsync(DTO.Username))
            {
                throw new UserExistsException(DTO.Username);
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
            await _dbContext.Professors.AddAsync(professor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SignUpAdminAsync(AdminRegistrationDTO DTO)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            if (await IsUsernameTakenAsync(DTO.Username))
            {
                throw new UserExistsException(DTO.Username);
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
            await _dbContext.Admins.AddAsync(admin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task LoginAsync(string username, string password)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            username = username.ToLower();

            string passwordHash = _passwordService.GetHash(password);

            Session? session = SessionManager.CurrentSession;
            if (session != null && !session.HasExpired)
            {
                throw new InvalidOperationException("There is an active session. Please logout first.");
            }

            User? student = await _dbContext.Students.SingleOrDefaultAsync(u => u.Username == username && u.PasswordHash == passwordHash);
            User? professor = await _dbContext.Professors.SingleOrDefaultAsync(u => u.Username == username && u.PasswordHash == passwordHash);
            User? admin = await _dbContext.Admins.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == passwordHash);

            User loggedInUser = student ?? professor ?? admin ?? throw new InvalidCredentialException("Wrong username or password!");


            SessionManager.CurrentSession = new Session(loggedInUser);
        }

        public async Task EnrollStudentAsync(string firstName, string lastName, string username, string emailAddress)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException("First name can not be null or empty.");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException("Last name can not be null or empty.");
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("User name can not be null or empty.");
            }

            if (string.IsNullOrEmpty(emailAddress) ||
                !StaticMailService.IsValidEmail(emailAddress))
            {
                throw new ArgumentNullException("Invalid email Address.");
            }

            if (username.Length < 6)
            {
                throw new ArgumentOutOfRangeException("Username must be at least 6 characters");
            }

            ActivationCode activationCode = new(username);

            await _dbContext.ActivationCodes.AddAsync(activationCode);
            await _dbContext.SaveChangesAsync();

            await _letterService.SendInvitationMailAsync(sender: SessionManager.CurrentSession.User, firstName, lastName,
                                                         emailAddress, activationCode);

        }

        public void Logout()
        {
            SessionManager.CurrentSession?.Revoke();
        }

    }
}
