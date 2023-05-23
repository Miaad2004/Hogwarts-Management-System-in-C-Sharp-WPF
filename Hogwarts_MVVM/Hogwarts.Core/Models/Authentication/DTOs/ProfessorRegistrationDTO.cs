using Hogwarts.Core.Models.FacultyManagement;

namespace Hogwarts.Core.Models.Authentication.DTOs
{
    public class ProfessorRegistrationDTO : BaseRegistrationDTO
    {
        public ProfessorMajors Major { get; set; }
        public bool HasTimeTurner { get; set; }
    }
}
