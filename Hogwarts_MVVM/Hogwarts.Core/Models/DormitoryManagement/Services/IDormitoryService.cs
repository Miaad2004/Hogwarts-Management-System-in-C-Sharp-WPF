using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.DormitoryManagement.Services
{
    public interface IDormitoryService
    {
        Room ReserveRoom(Dormitory dorm, User owner);
        Dormitory CreateDormitory(HouseType house, int nFloors, int nRoomsPerFloor, int nBedsPerRoom);
    }
}
