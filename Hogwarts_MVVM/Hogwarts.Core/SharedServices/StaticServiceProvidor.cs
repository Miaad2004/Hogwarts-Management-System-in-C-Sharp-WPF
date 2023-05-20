using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts.Core.Models.DormitoryManagement.Services;
using Hogwarts.Core.Models.FacultyManagement.Services;
using Hogwarts.Core.Models.ForestManagement.Services;
using Hogwarts.Core.Models.HouseManagement.Services;
using Hogwarts.Core.Models.TrainManagement.Services;

namespace Hogwarts.Core.SharedServices
{
    public static class StaticServiceProvidor
    {
        public static readonly HogwartsDbContext dbContext;
        public static readonly IPasswordService passwordService;
        public static readonly ITrainService trainService;
        public static readonly ILetterService letterService;
        public static readonly IHouseService houseService;
        public static readonly IAuthenticationService authenticationService;
        public static readonly IFacultyService facultyService;
        public static readonly IForestService forestService;
        public static readonly IDormitoryService dormitoryService;
        public static readonly ICourseService courseService;
        public static readonly IAssignmentService assignmentService;

        static StaticServiceProvidor()
        {
            dbContext = new HogwartsDbContext();
            passwordService = new PasswordService();
            trainService = new TrainService(dbContext);
            letterService = new LetterService(trainService);
            dormitoryService = new DormitoryService(dbContext);
            houseService = new HouseService(dbContext);
            authenticationService = new AuthenticationService(dbContext, passwordService, letterService,
                                                              dormitoryService, houseService);
            facultyService = new FacultyService(dbContext);
            forestService = new ForestService(dbContext);
            courseService = new CourseService(dbContext);
            assignmentService = new AssignmentService(dbContext);
        }
    }

}
