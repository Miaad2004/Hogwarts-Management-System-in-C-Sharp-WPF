using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly HogwartsDbContext _dbContext;

        public AssignmentService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAssignmentAsync(AssignmentDTO DTO, Guid courseId, Guid professorId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            Course course = await _dbContext.Courses.Include(c => c.Students).SingleOrDefaultAsync(c => c.Id == courseId) ?? throw new ArgumentException("Invalid course ID.");
            Professor professor = await _dbContext.Professors.SingleOrDefaultAsync(p => p.Id == professorId) ?? throw new ArgumentException("Invalid professor Id");

            Assignment assignment = new(DTO, professor, course);
            await _dbContext.Assignments.AddAsync(assignment);

            foreach (var student in course.Students)
            {
                var studentAssignment = new StudentAssignment(student, assignment);
                await _dbContext.StudentAssignments.AddAsync(studentAssignment);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<GradeType> GetAssignmentScoreAsync(Guid studentAssignmentId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            var StudentAssignment = await _dbContext.StudentAssignments.SingleOrDefaultAsync(sa => sa.Id == studentAssignmentId) ?? throw new ArgumentException("Invalid Assignment Id.");
            var score = StudentAssignment.Score;
            if (score == GradeType.NotSpecified)
            {
                throw new GradeNotRegisteredException("Your grade has not been registered yet.");
            }

            return score;
        }


        public async Task SetAssignmentScoreAsync(Guid studentAssignmentId, GradeType gradeType)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            var StudentAssignment = await _dbContext.StudentAssignments.SingleOrDefaultAsync(sa => sa.Id == studentAssignmentId) ?? throw new ArgumentException("Invalid Assignment Id.");
            StudentAssignment.Score = gradeType;
            await _dbContext.SaveChangesAsync();
        }

        public async Task SubmitAssignmentAnswerAsync(string answer, Guid studentAssignmentId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            var studentAssignment = await _dbContext.StudentAssignments.SingleOrDefaultAsync(sa => sa.Id == studentAssignmentId) ?? throw new ArgumentException("Invalid Assignment ID");
            studentAssignment.Answer = answer;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<int> GetActiveAssignmentCountAsync(Guid studentId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            Student? student = await _dbContext.Students
                .Include(s => s.StudentAssignments)
                .SingleOrDefaultAsync(s => s.Id == studentId)
                ?? throw new ArgumentException("Invalid student id");

            return student.StudentAssignments.Count();
        }
    }
}
