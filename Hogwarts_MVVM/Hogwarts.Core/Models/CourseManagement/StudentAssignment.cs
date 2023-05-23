using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.StudentManagement;
using System.ComponentModel;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class StudentAssignment : Entity, INotifyPropertyChanged
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

                if (!this.Assignment.HasStarted)
                {
                    throw new AssignmentHasNotStartedException(Assignment.Title, Assignment.Professor.FullName,
                                                               Assignment.StartDate);
                }

                else if (this.Assignment.HasEnded)
                {
                    throw new DeadlineExceededException(Assignment.Title, Assignment.DueDate);
                }
                _answer = value;
            }
        }

        private GradeType _score;
        public GradeType Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }
        public Student Student { get; private set; }
        public Guid StudentId { get; private set; }
        public Assignment Assignment { get; private set; }
        public Guid AssignmentId { get; private set; }
        public bool HasBeenAnswered => Answer != null;
        public bool HasBeenCheckedByTeacher => Score != GradeType.NotSpecified;
        public bool CanStudentAnswer => !HasBeenCheckedByTeacher && Assignment.HasStarted;

        public StudentAssignment()
        {

        }

        public StudentAssignment(Student student, Assignment assignment)
        {
            Student = student;
            StudentId = student.Id;
            Assignment = assignment;
            AssignmentId = assignment.Id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
