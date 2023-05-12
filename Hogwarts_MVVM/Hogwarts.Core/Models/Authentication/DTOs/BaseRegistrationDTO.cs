using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.Authentication.DTOs
{
    public class BaseRegistrationDTO
    {
        public string? Username { get; set; } = null;
        public string? Password { get; set; } = null;
        public string? PasswordRepeat { get; set; } = null;
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Email { get; set; } = null;

        public DateOnly BirthDate { get; set; }
        public BloodType BloodType { get; set; }
        public AccessLevels AccessLevel { get; set; }
        public string? ProfileImagePath { get; set; }
    }
}
