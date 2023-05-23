using Hogwarts.Core.Models.ForestManagement.DTOs;
using Hogwarts.Core.Models.ForestManagement.Exceptions;

namespace Hogwarts.Core.Models.ForestManagement
{
    public class Plant : Entity
    {
        private string _name;
        private string _description;
        private TimeSpan _groethTimeSpan;
        private int _quantity;

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name));
                }
                _name = value;
            }
        }

        public string Description
        {
            get => _description;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Description));
                }
                _description = value;
            }
        }

        public DateTime PlantingTime { get; private set; }

        public TimeSpan GrowthTimeSpan
        {
            get => _groethTimeSpan;
            private set
            {
                if (value.TotalSeconds <= 0)
                {
                    throw new ArgumentException($"{nameof(GrowthTimeSpan)} must be positive.");
                }
                _groethTimeSpan = value;
            }
        }

        public int Quantity
        {
            get => _quantity;
            private set
            {
                if (value < 0)
                {
                    throw new PlantException("Plant quantity is zero :(");
                }
                _quantity = value;
            }
        }

        public ICollection<StudentPlant> StudentPlants { get; private set; } = new List<StudentPlant>();
        public DateTime HarvestTime => PlantingTime + GrowthTimeSpan;
        public bool IsCollectable => DateTime.Now >= HarvestTime;
        public string FullProfileImagePath { get; private set; }


        public Plant()
            : base()
        {

        }

        public Plant(string name, TimeSpan growthTimeSpan, string quantity, string imagePath, string description = "")
            : base()
        {
            if (!int.TryParse(quantity, out _quantity))
            {
                throw new ArgumentException("Quantity must ne an integer.");
            }

            Name = name;
            GrowthTimeSpan = growthTimeSpan;
            Quantity = int.Parse(quantity);
            Description = description;
            PlantingTime = DateTime.Now;

            SetImagePath(imagePath);
        }

        public Plant(PlantDTO DTO)
            : base()
        {
            if (!int.TryParse(DTO.Quantity, out _quantity))
            {
                throw new ArgumentException("Quantity must ne an integer.");
            }

            Name = DTO.Name;
            GrowthTimeSpan = DTO.GrowthTimeSpan;
            Quantity = int.Parse(DTO.Quantity);
            Description = DTO.Description;
            PlantingTime = DateTime.Now;

            SetImagePath(DTO.ImagePath);
        }

        private void SetImagePath(string? imagePath)
        {
            if (imagePath is null || !File.Exists(imagePath))
            {
                throw new ArgumentException("Invalid profile image path.");
            }

            string subfolderName = "Hogwarts-Management-System";
            string subfolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                                                subfolderName, "PlantImages");

            if (!Directory.Exists(subfolderPath))
            {
                Directory.CreateDirectory(subfolderPath);
            }

            string fullImagePath = Path.Combine(subfolderPath, this.Id.ToString() + Path.GetExtension(imagePath));

            File.Copy(imagePath, fullImagePath, overwrite: true);
            File.SetAttributes(fullImagePath, FileAttributes.ReadOnly);
            this.FullProfileImagePath = fullImagePath;
        }

        public void CollectPlant()
        {
            if (!IsCollectable)
            {
                throw new PlantNotCollectableException(HarvestTime);
            }

            Quantity -= 1;
        }
    }
}
