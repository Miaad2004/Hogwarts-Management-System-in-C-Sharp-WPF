using Hogwarts.Core.Data;
using Hogwarts.Core.Models.HouseManagement.Exceptions;
using Hogwarts.Core.Models.StudentManagement;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Core.Models.HouseManagement.Services
{
    public class HouseService: IHouseService
    {
        private readonly HogwartsDbContext _context;
        public HouseService(HogwartsDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddHouse(HouseType houseType, string? profileImagePath)
        {
            if (_context.Houses.SingleOrDefault(h => h.HouseType == houseType) != null)
            {
                throw new HouseAlreadyExistsException($"House with type {houseType} already exists.");
            }

            var house = new House(houseType, profileImagePath);

            _context.Houses.Add(house);
            _context.SaveChanges();
        }

        public House Sort()
        {
            Random random = new();
            HouseType houseType = (HouseType)random.Next(0, Enum.GetValues(typeof(HouseType)).Length);

            var house = _context.Houses.Include(h => h.Students).SingleOrDefault(h => h.HouseType == houseType) ?? throw new HouseException($"House with type {houseType} does not exist. Contact the adminstrator.");

            return house;
        }

        public void UpdatePoints(Guid houseId, int dPoint)
        {
            var house = _context.Houses.SingleOrDefault(h => h.Id == houseId) ?? throw new HouseException($"Invalid house ID.");
            house.UpdatePoints(dPoint);
            _context.SaveChanges();
        }

        public HouseType GetHouseType(Guid studentId)
        {
            Student? student = _context.Students.SingleOrDefault(s => s.Id == studentId) ?? throw new ArgumentException("Invalid student id");
            return student.HouseType;
        }

        public int GetHousePoints(Guid studentOrHouseId)
        {
            var house = _context.Houses.SingleOrDefault(h => h.Id == studentOrHouseId);
            var student = _context.Students.Include(s => s.House).SingleOrDefault(s => s.Id == studentOrHouseId);

            if (house == null && student == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return (house ?? student.House).Points;
        }

        public int GetAvgHousePoints()
        {
            return (int)_context.Houses.Average(h => h.Points);
        }

    }
}
