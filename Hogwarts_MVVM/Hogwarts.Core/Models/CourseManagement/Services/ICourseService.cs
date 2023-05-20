using Hogwarts.Core.Models.CourseManagement.DTOs;

namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public interface ICourseService
    {
        Course GetCourseById(Guid courseId);
        void AddCourse(CourseDTO DTO);
        public GradeType GetStudentGrade(Guid studentId, Guid courseId);
        void EnrollStudentInCourse(Guid studentId, Guid courseId);
        void AddGradeToStudentInCourse(Guid studentId, Guid courseId, Grade grade);
        int GetActiveCourseCount(Guid studentId);


    }
}
