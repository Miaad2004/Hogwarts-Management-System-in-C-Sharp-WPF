using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.FacultyManagement
{
    public sealed class Professor : User
    {
        public ProfessorMajors Major { get; set; }
        public bool HasTimeTurner { get; set; }

        public Professor()
            : base()
        {

        }

        public Professor(string username, string firstName, string lastName, string email, DateOnly birthDay,
                     BloodType bloodType, AccessLevels accessLeve, string passwordHash, string profileImagePath,
                     ProfessorMajors major, bool hasTimeTurner)
            : base(username, firstName, lastName, email, birthDay,
                  bloodType, accessLeve, passwordHash, profileImagePath)
        {
            Major = major;
            HasTimeTurner = hasTimeTurner;
        }

        public Professor(ProfessorRegistrationDTO DTO, string passwordHash)
                    : base(DTO, passwordHash)
        {
            Major = DTO.Major;
            HasTimeTurner = DTO.HasTimeTurner;
        }
    }
}
