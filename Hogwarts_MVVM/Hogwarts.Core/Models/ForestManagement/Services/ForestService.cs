using Hogwarts.Core.Data;
using Hogwarts.Core.Models.ForestManagement.DTOs;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.ForestManagement.Services
{
    public class ForestService: IForestService
    {
        private readonly HogwartsDbContext _context;

        public ForestService(HogwartsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddPlant(PlantDTO DTO)
        {
            if (DTO == null)
            {
                throw new ArgumentNullException(nameof(DTO));
            }

            Plant plant = new(DTO);

            _context.Plants.Add(plant);
            _context.SaveChanges();
        }

        public void CollectPlant(Guid plantId, Guid studentId)
        {
            Plant? plant = _context.Plants.SingleOrDefault(p => p.Id == plantId) ?? throw new ArgumentException($"The plant with ID {plantId} is not in the forest.");
            Student? student = _context.Students.SingleOrDefault(p => p.Id == studentId) ?? throw new ArgumentException("Invalid student Id");

            StudentPlant? studentPlant = _context.StudentPlants.SingleOrDefault(p => p.PlantId == plantId && p.StudentId == studentId);

            if (studentPlant == null)
            {
                var newStudentPlant = new StudentPlant(plant, student);
                newStudentPlant.CollectPlant();

                _context.StudentPlants.Add(newStudentPlant);
            }
            else
            {
                studentPlant.CollectPlant();
            }

            _context.SaveChanges();
        }

        public int GetStudentPlantQuantity(Guid plantId, Guid studentId)
        {
            StudentPlant? studentPlant = _context.StudentPlants.SingleOrDefault(p => p.PlantId == plantId && p.StudentId == studentId);
            if (studentPlant == null)
            {
                return 0;
            }

            return studentPlant.Quantity;
        }

        public int GetCollectablePlantCount()
        {
            return _context.Plants.ToList().Where(p => p.IsCollectable).Count();
        }
    }
}
