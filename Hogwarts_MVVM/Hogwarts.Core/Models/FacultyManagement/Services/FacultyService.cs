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

        public ObservableCollection<T> GetList<T>(Func<T, object> orderBy)
            where T : class
        {
            var list = _dbContext.Set<T>().OrderBy(orderBy).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var prop = item.GetType().GetProperty("SequentialIndex");
                prop?.SetValue(item, i + 1);
            }

            return new ObservableCollection<T>(list);
        }


    }
}
