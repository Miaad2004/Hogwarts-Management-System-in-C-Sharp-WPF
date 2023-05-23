using Hogwarts.Core.Data;

namespace Hogwarts.Core.Models.FacultyManagement.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly HogwartsDbContext _dbContext;
        public FacultyService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
