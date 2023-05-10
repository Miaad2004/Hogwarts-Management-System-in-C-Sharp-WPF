using System;
using System.Collections.Generic;
using System.Linq;
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

            var existingPlant = _context.Plants.FirstOrDefault(p => p.Name == plant.Name);
            if (existingPlant != null)
            {
                existingPlant.Quantity += addQuantity;
            }
            else
            {
                plant.Quantity = addQuantity;
                _context.Plants.Add(plant);
            }

            _context.SaveChanges();
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

            var existingPlant = _context.Plants.FirstOrDefault(p => p.Name == plant.Name);
            if (existingPlant == null)
            {
                throw new KeyNotFoundException($"The plant {plant.Name} is not in the forest.");
            }

            existingPlant.Quantity = newQuantity;

            _context.SaveChanges();
        }

        public void RemovePlant(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }

            var existingPlant = _context.Plants.FirstOrDefault(p => p.Name == plant.Name);
            if (existingPlant == null)
            {
                throw new KeyNotFoundException($"The plant {plant.Name} is not in the forest.");
            }

            _context.Plants.Remove(existingPlant);

            _context.SaveChanges();
        }

        public int GetPlantQuantity(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentNullException(nameof(plant));
            }

            var existingPlant = _context.Plants.FirstOrDefault(p => p.Name == plant.Name);
            if (existingPlant == null)
            {
                throw new KeyNotFoundException($"The plant {plant.Name} is not in the forest.");
            }

            return existingPlant.Quantity;
        }

        public List<Plant> GetAllPlants()
        {
            return _context.Plants.ToList();
        }
    }
}
