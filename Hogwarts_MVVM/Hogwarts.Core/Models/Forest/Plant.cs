using System.ComponentModel.DataAnnotations;

namespace Hogwarts.Core.Models.Forest
{
    public class Plant
    {
        [Key]
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime PlantingTime { get; private set; }
        public TimeSpan GrowthTimeSpan { get; private set; }
        public DateTime HarvestTime => PlantingTime + GrowthTimeSpan;
        public bool IsCollectable => HarvestTime > DateTime.Now;

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Quantity must be positive", nameof(value));
                }
                _quantity = value;
            }
        }

        public Plant(string name, DateTime plantingTime, TimeSpan growthTimeSpan, string? description = null)
            : base()
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name of the plant cannot be empty.", nameof(name));
            }
            if (PlantingTime > DateTime.Now)
            {
                throw new ArgumentException("PlantingTime is not valid.");
            }

            Name = name;
            Description = description;
            PlantingTime = plantingTime;
            GrowthTimeSpan = growthTimeSpan;
        }
    }
}
