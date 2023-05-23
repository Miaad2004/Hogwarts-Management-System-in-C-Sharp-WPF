using Hogwarts.Core.Models.CourseManagement.DTOs;

namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public interface ICourseService
    {
        Task AddCourseAsync(CourseDTO DTO);
        public Task<GradeType> GetStudentGradeAsync(Guid studentId, Guid courseId);
        Task EnrollStudentInCourseAsync(Guid studentId, Guid courseId);
        Task SetStudentGradeAsync(Guid studentId, Guid courseId, GradeType gradeType);
        Task<int> GetActiveCourseCountAsync(Guid studentId);


    }
}
