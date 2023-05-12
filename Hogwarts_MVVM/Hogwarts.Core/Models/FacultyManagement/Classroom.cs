namespace Hogwarts.Core.Models.FacultyManagement
{
    public class Classroom : Entity
    {
        private int _floorNumber;
        private int _classNumber;
        private int _capacity;

        public int FloorNumber
        {
            get => _floorNumber;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Floor number must be a positive integer");
                }

                _floorNumber = value;
            }
        }

        public int ClassNumber
        {
            get => _classNumber;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Class number must be a positive integer");
                }

                _classNumber = value;
            }
        }

        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity must be a positive integer");
                }

                _capacity = value;
            }
        }

        public Classroom(int floorNumber, int classNumber, int capacity)
            : base()
        {
            FloorNumber = floorNumber;
            ClassNumber = classNumber;
            Capacity = capacity;
        }
    }

}
