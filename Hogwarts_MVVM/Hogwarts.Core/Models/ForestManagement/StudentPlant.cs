using Hogwarts.Core.Models.StudentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.ForestManagement
{
    public class StudentPlant: Entity
    {
        private int _quantity = 0;

        public Guid PlantId { get; private set; }
        public Guid StudentId { get; private set; }
        public Plant Plant { get; private set; }
        public Student Student { get; private set; }
        public int Quantity
        {
            get => _quantity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Plant quantity can not be negative");
                }
                _quantity = value;
            }
        }

        public StudentPlant() { }
        public StudentPlant(Plant plant, Student student)
        {
            Plant = plant;
            Student = student;
            PlantId = plant.Id;
            StudentId = plant.Id;
        }

        public void CollectPlant()
        {
            Plant.CollectPlant();
            Quantity += 1;
        }
    }
}
