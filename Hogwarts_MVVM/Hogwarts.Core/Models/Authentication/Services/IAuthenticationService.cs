using Hogwarts.Core.Models.Authentication.DTOs;

namespace Hogwarts.Core.Models.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task SignUpStudentAsync(StudentRegistrationDTO DTO);
        Task SignUpProfessorAsync(ProfessorRegistrationDTO DTO);
        Task SignUpAdminAsync(AdminRegistrationDTO DTO);
        Task LoginAsync(string username, string password);
        void Logout();
        Task EnrollStudentAsync(string firstName, string lastName, string username, string emailAddress);

    }
}
