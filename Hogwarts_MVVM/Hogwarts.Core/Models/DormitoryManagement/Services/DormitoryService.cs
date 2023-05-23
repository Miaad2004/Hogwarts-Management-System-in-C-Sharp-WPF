using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.DormitoryManagement.Exceptions;
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.StudentManagement;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Core.Models.DormitoryManagement.Services
{
    public class DormitoryService : IDormitoryService
    {
        private readonly HogwartsDbContext _dbContext;
        public DormitoryService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dormitory> AddDormitoryAsync(string title, HouseType house, int floorsCount, int roomsPerFloor, int bedsPerRoom)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            Dormitory dorm = new(title, house, floorsCount, roomsPerFloor, bedsPerRoom);
            await _dbContext.Dormitories.AddAsync(dorm);
            await _dbContext.SaveChangesAsync();

            return dorm;
        }

        public async Task<DormitoryRoom> ReserveRoomAsync(Dormitory dormitory, Student owner)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            var room = dormitory.ReserveRoom(owner);
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();

            return room;
        }

        public async Task<DormitoryRoom> ReserveRoomAsync(Guid dormitoryId, Student owner)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            var dorm = await _dbContext.Dormitories.FirstAsync(d => d.Id == dormitoryId);

            var room = dorm.ReserveRoom(owner);
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();

            return room;
        }

        public async Task<DormitoryRoom> GetRoomForNewStudentAsync(Student owner)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            var dorm = await _dbContext.Dormitories.
                Where(d => d.House == owner.HouseType).
                OrderByDescending(d => d.OccupiedBedsCount).
                FirstOrDefaultAsync()
                ?? throw new NoDormitoryFoundException(owner.HouseType);

            var room = dorm.ReserveRoom(owner);
            await _dbContext.Rooms.AddAsync(room);
            await _dbContext.SaveChangesAsync();

            return room;
        }
    }
}
