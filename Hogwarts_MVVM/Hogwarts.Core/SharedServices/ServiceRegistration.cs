using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication.Services;
using Hogwarts.Core.Models.CourseManagement.Services;
using Hogwarts.Core.Models.DormitoryManagement.Services;
using Hogwarts.Core.Models.FacultyManagement.Services;
using Hogwarts.Core.Models.ForestManagement.Services;
using Hogwarts.Core.Models.HouseManagement.Services;
using Hogwarts.Core.Models.TrainManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hogwarts.Core.SharedServices
{
    public static class ServiceRegistration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<HogwartsDbContext>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<ITrainService, TrainService>();
            services.AddScoped<ILetterService, LetterService>();
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IForestService, ForestService>();
            services.AddScoped<IDormitoryService, DormitoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
        }
    }
}
