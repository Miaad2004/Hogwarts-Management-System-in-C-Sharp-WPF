using Hogwarts.Core.Models.CourseManagement.DTOs;

namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public interface IAssignmentService
    {
        Task AddAssignmentAsync(AssignmentDTO DTO, Guid courseId, Guid professorId);
        Task<GradeType> GetAssignmentScoreAsync(Guid StudentAssignmentId);
        Task SetAssignmentScoreAsync(Guid studentAssignmentId, GradeType gradeType);
        Task SubmitAssignmentAnswerAsync(string answer, Guid studentAssignmentId);
        Task<int> GetActiveAssignmentCountAsync(Guid studentId);
    }
}
