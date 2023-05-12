namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public interface ICourseManagementService
    {
        Course GetCourseById(Guid courseId);
        List<Course> GetAllCourses();
        void AddCourse(Course course);
        void RemoveCourse(Course course);
        void EnrollStudentInCourse(Guid studentId, Guid courseId);
        void AddGradeToStudentInCourse(Guid studentId, Guid courseId, Grade grade);
    }
}
