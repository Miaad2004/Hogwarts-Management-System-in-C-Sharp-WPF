using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.Models.FacultyManagement.Services;
using Hogwarts.Core.Models.TrainManagement.Services;

namespace Hogwarts.Core.SharedServices
{
    public static class StaticServiceProvidor
    {
        public static readonly HogwartsDbContext DbContext;
        public static readonly IPasswordService passwordService;
        public static readonly ITrainService trainService;
        public static readonly ILetterService letterService;
        public static readonly IAuthenticationService authenticationService;
        public static readonly IFacultyService facultyService;
        static StaticServiceProvidor()
        {
            DbContext = new HogwartsDbContext();
            passwordService = new PasswordService();
            trainService = new TrainService(DbContext);
            letterService = new LetterService(trainService);
            authenticationService = new AuthenticationService(DbContext, passwordService, letterService);
            facultyService = new FacultyService(DbContext);
        }
    }

}
