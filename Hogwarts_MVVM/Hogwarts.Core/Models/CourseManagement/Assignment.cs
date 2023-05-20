using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class Assignment : Entity
    {
        private string _title;
        private string _description;
        private DateTime _startDate;
        private DateTime _dueDate;
        
        public string Title
        {
            get => _title;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(Title)} can't be empty.");
                }
                _title = value;
            }
        }
        public string Description
        {
            get => _description;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(Description)} can't be empty.");
                }
                _description = value;
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            private set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException($"{nameof(StartDate)} can't be in the past.");
                }
                _startDate = value;
            }
        }
        public DateTime DueDate
        {
            get => _dueDate;
            private set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException($"{nameof(DueDate)} can't be in the past.");
                }
                _dueDate = value;
            }
        }
        public bool RequireForestAccess { get; private set; }
        public Professor Professor { get; private set; }
        public Guid ProfessorId { get; private set; }
        public Course Course { get; private set; }
        public Guid CourseId { get; private set; }
        public ICollection<StudentAssignment> StudentAssignments { get; private set; } = new List<StudentAssignment>(); 
        public bool HasEnded => DueDate > DateTime.Now;

        public Assignment()
            : base()
        {

        }

        public Assignment(AssignmentDTO DTO, Professor professor, Course course)
            : base()
        {
            if (DTO.StartDate >= DTO.DueDate)
            {
                throw new ArgumentException($"Assingment's {nameof(StartDate)} should be before its {nameof(DueDate)}");
            }

            Title = DTO.Title;
            Description = DTO.Description;
            StartDate = DTO.StartDate;
            DueDate = DTO.DueDate;
            RequireForestAccess = DTO.RequireForestAccess;
            Professor = professor;
            ProfessorId = professor.Id;
            Course = course;
            CourseId = course.Id;
        }


    }

}
