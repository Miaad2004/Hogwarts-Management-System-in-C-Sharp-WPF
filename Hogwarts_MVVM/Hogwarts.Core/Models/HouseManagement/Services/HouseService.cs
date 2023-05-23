using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.HouseManagement.Exceptions;
using Hogwarts.Core.Models.StudentManagement;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Core.Models.HouseManagement.Services
{
    public class HouseService : IHouseService
    {
        private readonly HogwartsDbContext _dbContext;
        public HouseService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddHouseAsync(HouseType houseType, string? profileImagePath)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            if (await _dbContext.Houses.SingleOrDefaultAsync(h => h.HouseType == houseType) != null)
            {
                throw new HouseAlreadyExistsException($"House with type {houseType} already exists.");
            }

            var house = new House(houseType, profileImagePath);

            await _dbContext.Houses.AddAsync(house);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<House> SortAsync()
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Unauthorized);

            Random random = new();
            HouseType houseType = (HouseType)random.Next(0, Enum.GetValues(typeof(HouseType)).Length);

            var house = await _dbContext.Houses
                .Include(h => h.Students)
                .SingleOrDefaultAsync(h => h.HouseType == houseType)
                ?? throw new HouseException($"House with type {houseType} does not exist. Contact the adminstrator.");

            return house;
        }

        public async Task UpdatePointsAsync(Guid houseId, int dPoint)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            var house = await _dbContext.Houses
                .SingleOrDefaultAsync(h => h.Id == houseId)
                ?? throw new HouseException($"Invalid house ID.");

            house.UpdatePoints(dPoint);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<HouseType> GetHouseTypeAsync(Guid studentId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            Student? student = await _dbContext.Students
                .SingleOrDefaultAsync(s => s.Id == studentId)
                ?? throw new ArgumentException("Invalid student id");

            return student.HouseType;
        }

        public async Task<int> GetHousePointsAsync(Guid studentOrHouseId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            var house = await _dbContext.Houses.SingleOrDefaultAsync(h => h.Id == studentOrHouseId);
            var student = await _dbContext.Students
                .Include(s => s.House)
                .SingleOrDefaultAsync(s => s.Id == studentOrHouseId);

            if (house == null && student == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return (house ?? student.House).Points;
        }

        public async Task<int> GetAvgHousePointsAsync()
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            return !_dbContext.Houses.Any() ? 0 : (int)(await _dbContext.Houses.AverageAsync(h => h.Points));
        }

    }
}
