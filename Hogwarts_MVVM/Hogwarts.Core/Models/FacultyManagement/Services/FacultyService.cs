using Hogwarts.Core.Data;
using System.Collections.ObjectModel;

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
