using Hogwarts.Core.Models.StudentManagement;
using System;

namespace Hogwarts.Core.Models.Authentication.DTOs
{
    public class BaseRegistrationDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateOnly BirthDate { get; set; }
        public BloodType BloodType { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
