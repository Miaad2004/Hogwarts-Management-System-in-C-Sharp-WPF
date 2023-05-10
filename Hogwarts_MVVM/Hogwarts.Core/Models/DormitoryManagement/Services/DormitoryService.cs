using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.DormitoryManagement.Exceptions;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.DormitoryManagement.Services
{
    public class DormitoryService : IDormitoryService
    {
        private readonly HogwartsDbContext _context;
        public DormitoryService(HogwartsDbContext context)
        {
            _context = context;
        }

        public Room ReserveRoom(Dormitory dorm, User owner)
        {
            if (dorm.NOccupiedBeds == dorm.TotalCapacity)
                throw new DormitoryFullException($"[{dorm.House}] dormitory is full.");

            int floorNumber = dorm.NOccupiedBeds / dorm.FloorCapacity + 1;
            int nStudentsInFloor = dorm.NOccupiedBeds % dorm.FloorCapacity;
            int roomNumber = nStudentsInFloor / dorm.NBedsPerRoom + 1;
            int bedNumber = nStudentsInFloor % dorm.NBedsPerRoom + 1;

            dorm.NOccupiedBeds += 1;

            var room = new Room(owner, dorm.House, floorNumber, roomNumber, bedNumber);
            dorm.Rooms.Add(room);
            _context.SaveChanges();

            return room;
        }

        public Dormitory CreateDormitory(HouseType house, int nFloors, int nRoomsPerFloor, int nBedsPerRoom)
        {
            var dorm = new Dormitory(house, nFloors, nRoomsPerFloor, nBedsPerRoom);
            _context.Dormitories.Add(dorm);
            _context.SaveChanges();

            return dorm;
        }
    }
}
