using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.HouseManagement
{
    public class House : Entity
    {
        public House HouseType { get; private set; }

        private int _score;

        public int Score
        {
            get => _score;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score must be a non-negative integer.");
                }
                _score = value;
            }
        }


        public IEnumerable<Student> Students { get; private set; }

        public Professor Head { get; private set; }

        public House(House houseType, Professor head)
            : base()
        {
            HouseType = houseType;
            Score = _score;
            Head = head;
            Students = new List<Student>();
        }
    }
}
