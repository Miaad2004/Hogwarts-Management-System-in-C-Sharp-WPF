using Hogwarts.Core.Models.Forest.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Hogwarts.Core.Models.Forest
{
    public class Plant: Entity
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
                    throw new ArgumentNullException($"{nameof(Name)} Can not be null.");
                }
                _name = value;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(Description)} Can not be null.");
                }
                _description = value;
            }
        }

        public DateTime PlantingTime { get; private set; }

        public TimeSpan GrowthTimeSpan
        {
            get => _groethTimeSpan;
            set
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
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Quantity must be positive", nameof(value));
                }
                _quantity = value;
            }
        }

        public DateTime HarvestTime => PlantingTime + GrowthTimeSpan;
        public bool IsCollectable => HarvestTime > DateTime.Now;
        public string FullImagePath { get; private set; }

        public Plant(string name, TimeSpan growthTimeSpan, int quantity, string imagePath, string description = "")
            : base()
        {
            Name = name;
            GrowthTimeSpan = growthTimeSpan;
            Quantity = quantity;
            Description = description;
            PlantingTime = DateTime.Now;

            SetImagePath(imagePath);
        }

        public Plant(PlantDTO DTO)
            : base()
        {
            Name = DTO.Name;
            GrowthTimeSpan = DTO.GrowthTimeSpan;
            Quantity = DTO.Quantity;
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
            this.FullImagePath = fullImagePath;
        }
    }
}
