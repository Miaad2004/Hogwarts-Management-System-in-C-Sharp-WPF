using System.Collections.ObjectModel;

namespace Hogwarts.Core.Models.FacultyManagement.Services
{
    public interface IFacultyService
    {
        ObservableCollection<T> GetList<T>(Func<T, object> orderBy)
            where T : class;
    }
}
