using Hogwarts.Core.Models.Authentication.DTOs;

namespace Hogwarts.Core.Models.Authentication.Services
{
    public interface IAuthenticationService
    {
        void SignUpStudent(StudentRegistrationDTO DTO);
        void SignUpProfessor(ProfessorRegistrationDTO DTO);
        void SignUpAdmin(AdminRegistrationDTO DTO);
        void Login(string username, string password);
        void Logout();
        void EnrollStudent(string firstName, string lastName, string username, string emailAddress);

    }
}
