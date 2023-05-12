using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Forest.DTOs;

namespace Hogwarts.Core.Models.Forest.Services
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

        public void UpdatePlantQuantity(Guid plantId, int newQuantity)
        {
            Plant? existingPlant = _context.Plants.FirstOrDefault(p => p.Id == plantId);
            if (existingPlant == null)
            {
                throw new ArgumentException($"The plant with ID {plantId} is not in the forest.");
            }

            existingPlant.Quantity = newQuantity;
            _context.SaveChanges();
        }
    }
}
