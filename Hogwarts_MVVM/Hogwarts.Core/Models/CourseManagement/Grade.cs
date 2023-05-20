using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class Grade : Entity
    {
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public GradeType Value { get; private set; }
        public Student Student { get; private set; }
        public Course Course { get; private set; }
        public Grade()
        {

        }
        public Grade(GradeType value, Student student, Course course)
        {
            Value = value;
            Student = student;
            Course = course;
            StudentId = student.Id;
            CourseId = course.Id;
        }
    }

    public enum GradeType
    {
        A,
        B,
        C,
        D,
        E,
        F
    }
}
