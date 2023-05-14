using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.DormitoryManagement.Services
{
    public interface IDormitoryService
    {
        Dormitory AddDormitory(string title, HouseType house, int floorsCount, int roomsPerFloor, int bedsPerRoom);
        DormitoryRoom GetRoom(Dormitory dormitory, Student owner);
        DormitoryRoom GetRoom(Guid dormitoryId, Student owner);
        DormitoryRoom GetRoomForNewStudent(Student owner);
    }
}
