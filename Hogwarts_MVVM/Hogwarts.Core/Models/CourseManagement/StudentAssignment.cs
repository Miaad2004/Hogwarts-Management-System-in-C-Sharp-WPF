using Hogwarts.Core.Models.StudentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class StudentAssignment: Entity
    {
        private string _answer;
        public string? Answer
        {
            get => _answer;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"{nameof(Answer)} can't be empty.");
                }
                _answer = value;
            }
        }

        public Grade? Score { get; set; } = null;
        public Student Student { get; private set; }
        public Guid StudentId { get; private set; }
        public Assignment Assignment { get; private set; }
        public Guid AssignmentId { get; private set; }
        public bool HasBeenAnswered => Answer != null;
        public bool HasBeenCheckedByTeacher => Score != null;

        public StudentAssignment() { }
        public StudentAssignment(Student student, Assignment assignment)
        {
            Student = student;
            StudentId = student.Id;
            Assignment = assignment;
            AssignmentId = assignment.Id;
        }
    }
}
