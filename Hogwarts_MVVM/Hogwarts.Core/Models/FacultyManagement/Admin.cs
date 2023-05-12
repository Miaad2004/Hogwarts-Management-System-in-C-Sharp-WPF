using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.FacultyManagement
{
    public sealed class Admin : User
    {
        public Admin()
            : base()
        {

        }
        public Admin(string username, string firstName, string lastName, string email, DateOnly birthDay,
                     BloodType bloodType, AccessLevels accessLeve, string passwordHash, string profileImagePath)
            : base(username, firstName, lastName, email, birthDay, bloodType, accessLeve, passwordHash, profileImagePath)
        {
        }
        public Admin(AdminRegistrationDTO DTO, string passwordHash)
            : base(DTO, passwordHash)
        {
        }

    }
}
