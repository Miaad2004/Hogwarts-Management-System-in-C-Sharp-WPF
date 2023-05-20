using Hogwarts.Core.Models.CourseManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public interface IAssignmentService
    {
        void AddAssignment(AssignmentDTO DTO, Guid courseId, Guid professorId);
        GradeType GetStudentAssignmentScore(Guid StudentAssignmentId);
        void UploadStudentAssignmentAnswer(string answer, Guid studentAssignmentId);
    }
}
