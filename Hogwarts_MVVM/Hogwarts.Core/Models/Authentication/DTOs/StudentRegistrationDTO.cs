using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.Authentication.DTOs
{
    public class StudentRegistrationDTO: BaseRegistrationDTO
    {
        public bool HasLuggage { get; set; }
        public Pet Pet { get; set; }
        public string EnteredActivationCode { get; set; }
    }
}
