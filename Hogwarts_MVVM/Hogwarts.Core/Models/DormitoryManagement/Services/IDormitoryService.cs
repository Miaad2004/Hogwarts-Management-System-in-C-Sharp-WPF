using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.DormitoryManagement.Services
{
    public interface IDormitoryService
    {
        Task<Dormitory> AddDormitoryAsync(string title, HouseType house, int floorsCount, int roomsPerFloor, int bedsPerRoom);
        Task<DormitoryRoom> ReserveRoomAsync(Dormitory dormitory, Student owner);
        Task<DormitoryRoom> ReserveRoomAsync(Guid dormitoryId, Student owner);
        Task<DormitoryRoom> GetRoomForNewStudentAsync(Student owner);
    }
}
