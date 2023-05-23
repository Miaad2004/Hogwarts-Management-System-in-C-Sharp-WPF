using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.ForestManagement
{
    public class StudentPlant : Entity
    {
        private int _numOwnedPlants = 0;

        public Plant Plant { get; private set; }
        public Guid PlantId { get; private set; }
        public Student Student { get; private set; }
        public Guid StudentId { get; private set; }

        public int NumOwnedPlants
        {
            get => _numOwnedPlants;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Plant quantity can not be negative");
                }
                _numOwnedPlants = value;
            }
        }

        public StudentPlant()
            : base()
        {

        }

        public StudentPlant(Plant plant, Student student)
            : base()
        {
            Plant = plant;
            Student = student;
            PlantId = plant.Id;
            StudentId = plant.Id;
        }

        public void CollectPlant()
        {
            Plant.CollectPlant();
            NumOwnedPlants += 1;
        }
    }
}
