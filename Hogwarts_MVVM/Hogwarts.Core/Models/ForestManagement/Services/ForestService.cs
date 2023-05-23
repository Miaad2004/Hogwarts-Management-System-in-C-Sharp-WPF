using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.ForestManagement.DTOs;
using Hogwarts.Core.Models.StudentManagement;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Core.Models.ForestManagement.Services
{
    public class ForestService : IForestService
    {
        private readonly HogwartsDbContext _dbContext;

        public ForestService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddPlantAsync(PlantDTO DTO)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            if (DTO == null)
            {
                throw new ArgumentNullException(nameof(DTO));
            }

            Plant plant = new(DTO);

            await _dbContext.Plants.AddAsync(plant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CollectPlantAsync(Guid plantId, Guid studentId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            Plant? plant = await _dbContext.Plants.SingleOrDefaultAsync(p => p.Id == plantId) ?? throw new ArgumentException($"The plant with ID {plantId} is not in the forest.");
            Student? student = await _dbContext.Students.SingleOrDefaultAsync(p => p.Id == studentId) ?? throw new ArgumentException("Invalid student Id");

            StudentPlant? studentPlant = await _dbContext.StudentPlants.SingleOrDefaultAsync(p => p.PlantId == plantId && p.StudentId == studentId);

            if (studentPlant == null)
            {
                var newStudentPlant = new StudentPlant(plant, student);
                newStudentPlant.CollectPlant();

                await _dbContext.StudentPlants.AddAsync(newStudentPlant);
            }
            else
            {
                studentPlant.CollectPlant();
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetStudentPlantQuantityAsync(Guid plantId, Guid studentId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            StudentPlant? studentPlant = await _dbContext.StudentPlants.SingleOrDefaultAsync(p => p.PlantId == plantId && p.StudentId == studentId);
            if (studentPlant == null)
            {
                return 0;
            }

            return studentPlant.NumOwnedPlants;
        }

        public async Task<int> GetCollectablePlantCountAsync()
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            return (await _dbContext.Plants.ToListAsync()).Where(p => p.IsCollectable).Count();
        }
    }
}
