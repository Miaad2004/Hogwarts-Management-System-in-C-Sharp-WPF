using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class Course : Entity
    {
        private string _title;
        private int _capacity;
        private string _classroom;
        private int _occupiedSeats = 0;
        private DateOnly _endDate;

        public string Title
        {
            get => _title;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title can't be empty.");
                }
                _title = value;
            }
        }

        public DateOnly EndDate
        {
            get => _endDate;
            private set
            {
                if (value <= DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new ArgumentException("End date can not be in the past.");
                }
                _endDate = value;
            }
        }

        public DayOfWeek Schedule { get; private set; }
        public TimeOnly ClassStartTime { get; private set; }
        public TimeOnly ClassEndTime { get; private set; }
        public Professor Professor { get; private set; }
        public int Capacity
        {
            get => _capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Course capacity should be positive.");
                }
                _capacity = value;
            }
        }

        public string Classroom
        {
            get => _classroom;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Classroom can't be empty.");
                }
                _classroom = value;
            }
        }

        public int OccuipiedSeats
        {
            get => _occupiedSeats;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(OccuipiedSeats));
                }
                _occupiedSeats = value;
            }
        }

        public ICollection<Grade> Grades { get; private set; } = new List<Grade>();
        public ICollection<Student> Students { get; private set; } = new List<Student>();
        public ICollection<Assignment> Assignments { get; private set; } = new List<Assignment>();
        public bool HasFinished => DateOnly.FromDateTime(DateTime.Now) > EndDate;
        public int SeatsLeft => Capacity - OccuipiedSeats;
        public int ActiveAssignmentsCount => Assignments.Where(a => !a.HasEnded).ToList().Count();

        public Course()
            : base()
        {
        }

        public Course(string title, DateOnly endDate, DayOfWeek schedule, TimeOnly classStartTime, TimeOnly classEndTime,
                      Professor professor, string capacity, string classroom)
            : base()
        {
            if (!int.TryParse(capacity, out var _))
            {
                throw new ArgumentException("Course capacity should be an integer.");
            }
            if (classStartTime >= classEndTime)
            {
                throw new ArgumentException("Class start time must be before its end time.");
            }

            Title = title;
            EndDate = endDate;
            Schedule = schedule;
            ClassStartTime = classStartTime;
            ClassEndTime = classEndTime;
            Professor = professor;
            Capacity = int.Parse(capacity);
            Classroom = classroom;
        }

        public Course(CourseDTO DTO, Professor professor)
            : base()
        {
            if (!int.TryParse(DTO.Capacity, out var _))
            {
                throw new ArgumentException("Course capacity should be an integer.");
            }
            if (DTO.ClassStartTime >= DTO.ClassEndTime)
            {
                throw new ArgumentException("Class start time must be before its end time.");
            }

            Title = DTO.Title;
            EndDate = DTO.EndDate;
            Schedule = DTO.Schedule;
            ClassStartTime = DTO.ClassStartTime;
            ClassEndTime = DTO.ClassEndTime;
            Professor = professor;
            Capacity = int.Parse(DTO.Capacity);
            Classroom = DTO.Classroom;
        }

        public bool ConflictsWith(Course otherCourse)
        {
            if (otherCourse.Schedule != this.Schedule)
            {
                return false;
            }

            if ((ClassEndTime > otherCourse.ClassStartTime && ClassStartTime < otherCourse.ClassEndTime) ||
                (ClassStartTime < otherCourse.ClassStartTime && ClassEndTime > otherCourse.ClassStartTime))
            {
                if (Classroom == otherCourse.Classroom)
                {
                    return true;
                }

                if (Professor.Id == otherCourse.Professor.Id && !Professor.HasTimeTurner)
                {
                    return true;
                }
            }

            return false;
        }

        public void OnSeatReserved()
        {
            OccuipiedSeats++;
        }
    }


}
