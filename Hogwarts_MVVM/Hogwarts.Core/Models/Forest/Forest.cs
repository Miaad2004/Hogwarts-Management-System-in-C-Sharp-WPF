using Hogwarts.Core.Data;

namespace Hogwarts.Core.Models.Forest
{
    public class Forest
    {
        private readonly HogwartsDbContext _context;

        public Forest(HogwartsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddPlant(Plant plant, int addQuantity)
        {
            if (plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }
            if (addQuantity <= 0)
            {
                throw new ArgumentException("Quantity must be a positive integer greater than zero.", nameof(addQuantity));
            }

            Plant? existingPlant = _context.Plants.FirstOrDefault(p => p.Name == plant.Name);
            if (existingPlant != null)
            {
                existingPlant.Quantity += addQuantity;
            }
            else
            {
                plant.Quantity = addQuantity;
                _ = _context.Plants.Add(plant);
            }

            _ = _context.SaveChanges();
        }

        public void UpdatePlant(Plant plant, int newQuantity)
        {
            if (plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }
            if (newQuantity <= 0)
            {
                throw new ArgumentException("Quantity must be a positive integer greater than zero.", nameof(newQuantity));
            }

            Plant? existingPlant = _context.Plants.FirstOrDefault(p => p.Name == plant.Name);
            if (existingPlant == null)
            {
                throw new KeyNotFoundException($"The plant {plant.Name} is not in the forest.");
            }

            existingPlant.Quantity = newQuantity;

            _ = _context.SaveChanges();
        }

        public void RemovePlant(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }

            Plant? existingPlant = _context.Plants.FirstOrDefault(p => p.Name == plant.Name);
            if (existingPlant == null)
            {
                throw new KeyNotFoundException($"The plant {plant.Name} is not in the forest.");
            }

            _ = _context.Plants.Remove(existingPlant);

            _ = _context.SaveChanges();
        }

        public int GetPlantQuantity(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }

            Plant? existingPlant = _context.Plants.FirstOrDefault(p => p.Name == plant.Name);
            return existingPlant == null
                ? throw new KeyNotFoundException($"The plant {plant.Name} is not in the forest.")
                : existingPlant.Quantity;
        }

        public List<Plant> GetAllPlants()
        {
            return _context.Plants.ToList();
        }
    }
}
