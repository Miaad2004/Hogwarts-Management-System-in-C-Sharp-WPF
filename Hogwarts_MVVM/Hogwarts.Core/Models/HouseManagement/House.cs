using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.HouseManagement
{
    public enum HouseType
    {
        Ravenclaw,
        Slytherin,
        Hufflepuff,
        Gryffindor
    }

    public class House : Entity
    {
        public HouseType HouseType { get; private set; }

        private int _points = 0;

        public int Points
        {
            get => _points;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("No points left :(");
                }
                _points = value;
            }
        }

        public int StudentsCount => Students.Count;

        public string FullProfileImagePath { get; private set; }
        public ICollection<Student> Students { get; private set; } = new List<Student>();

        public House(): base() { }

        public House(HouseType houseType, string? profileImagePath)
            : base()
        {
            if (profileImagePath is null || !File.Exists(profileImagePath))
            {
                throw new ArgumentException("Invalid profile image path.");
            }

            HouseType = houseType;
            SetImagePath(profileImagePath);
        }

        public void UpdatePoints(int dPoint = 5)
        {
            Points += dPoint;
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
    }
}
