using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.FacultyManagement
{
    public sealed class Professor : User
    {
        public Major Major { get; set; }
        public bool HasTimeTurner { get; set; }

        public Professor()
        {

        }
        public Professor(string username, string firstName, string lastName, string email, DateOnly birthDay,
                     BloodType bloodType, AccessLevels accessLeve, string passwordHash, string profileImagePath,
                     Major major, bool hasTimeTurner)
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
