using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.FacultyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.Authentication
{
    public interface IAuthenticationService
    {
        bool IsUsernameTaken(string username);
        bool IsActivationCodeVaild(string username, string enteredCode);
        void SignUpStudent(StudentRegistrationDTO DTO);
        void SignUpProfessor(ProfessorRegistrationDTO DTO);
        void SignUpAdmin(AdminRegistrationDTO DTO);
        void Login(string username, string password);
        void Logout();

    }
}
