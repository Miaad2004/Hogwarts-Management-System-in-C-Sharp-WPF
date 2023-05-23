using Hogwarts.Core.Models.StudentManagement;
using System.ComponentModel;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class Grade : Entity, INotifyPropertyChanged
    {
        private GradeType _gradeValue;
        public Student Student { get; private set; }
        public Guid StudentId { get; private set; }
        public Course Course { get; private set; }
        public Guid CourseId { get; private set; }
        public GradeType GradeValue
        {
            get => _gradeValue;
            set
            {
                _gradeValue = value;
                OnPropertyChanged(nameof(GradeValue));
            }
        }

        public Grade()
            : base()
        {

        }

        public Grade(Student student, Course course)
            : base()
        {
            Student = student;
            Course = course;
            StudentId = student.Id;
            CourseId = course.Id;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum GradeType
    {
        NotSpecified,
        A,
        B,
        C,
        D,
        E,
        F,
    }
}
