using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class Grade : Entity
    {
        public GradeType Value { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public Grade()
        {

        }
        public Grade(GradeType value, Student student, Course course)
        {
            Value = value;
            Student = student;
            Course = course;
        }
    }

    public enum GradeType
    {
        A,
        B,
        C,
        D,
        F
    }
}
