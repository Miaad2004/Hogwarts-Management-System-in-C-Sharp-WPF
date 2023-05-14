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

        public Dormitory AddDormitory(string title, HouseType house, int floorsCount, int roomsPerFloor, int bedsPerRoom)
        {
            Dormitory dorm = new(title, house, floorsCount, roomsPerFloor, bedsPerRoom);
            _context.Dormitories.Add(dorm);
            _context.SaveChanges();

            return dorm;
        }

        public DormitoryRoom GetRoom(Dormitory dormitory, Student owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            var room = dormitory.ReserveRoom(owner);
            _context.Rooms.Add(room);
            _context.SaveChanges();

            return room;
        }

        public DormitoryRoom GetRoom(Guid dormitoryId, Student owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            var dorm = _context.Dormitories.First(d => d.Id == dormitoryId);
            var room = dorm.ReserveRoom(owner);

            _context.Rooms.Add(room);
            _context.SaveChanges();

            return room;
        }

        public DormitoryRoom GetRoomForNewStudent(Student owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            var dorm = _context.Dormitories.Where(d => d.House == owner.HouseType).OrderBy(d => d.OccupiedBedsCount).FirstOrDefault();
            if (dorm is null)
            {
                throw new NoDormitoryFoundException($"No dormitories were found for hous {owner.HouseType}");
            }

            var room = dorm.ReserveRoom(owner);
            _context.Rooms.Add(room);
            _context.SaveChanges();

            return room;
        }
    }
}
