using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class Course : Entity
    {
        // to do: Add Year
        public string Name { get; private set; }

        private DateTime startDate;

        private TimeSpan duration;
        public Professor Owner { get; private set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public int Capacity { get; private set; }
        public Classroom Classroom { get; set; }
        public bool HasFinished { get; private set; }

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (value < DateTime.Today)
                {
                    throw new ArgumentException("Start date must be on or after today");
                }

                startDate = value;
            }
        }

        public TimeSpan Duration
        {
            get => duration;
            set
            {
                if (value <= TimeSpan.Zero)
                {
                    throw new ArgumentException("Duration must be a positive timespan");
                }

                duration = value;
            }
        }

        public DateTime EndDate => StartDate + Duration;

        public Course()
            : base()
        {

        }

        public Course(string name, DateTime startDate, TimeSpan duration, Professor owner, int capacity, Classroom classroom)
            : base()
        {
            Name = name;
            StartDate = startDate;
            Duration = duration;
            Owner = owner;
            Capacity = capacity;
            Grades = new List<Grade>();
            Students = new List<Student>();
            Assignments = new List<Assignment>();
            HasFinished = false;
            Classroom = classroom;
        }
    }


}
