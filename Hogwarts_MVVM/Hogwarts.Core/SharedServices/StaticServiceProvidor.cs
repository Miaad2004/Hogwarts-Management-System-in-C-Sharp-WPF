using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.Models.DormitoryManagement.Services;
using Hogwarts.Core.Models.FacultyManagement.Services;
using Hogwarts.Core.Models.Forest.Services;
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
        public static readonly IForestService forestService;
        public static readonly IDormitoryService dormitoryService;
        static StaticServiceProvidor()
        {
            DbContext = new HogwartsDbContext();
            passwordService = new PasswordService();
            trainService = new TrainService(DbContext);
            letterService = new LetterService(trainService);
            dormitoryService = new DormitoryService(DbContext);
            authenticationService = new AuthenticationService(DbContext, passwordService, letterService, dormitoryService);
            facultyService = new FacultyService(DbContext);
            forestService = new ForestService(DbContext);
        }
    }

}
