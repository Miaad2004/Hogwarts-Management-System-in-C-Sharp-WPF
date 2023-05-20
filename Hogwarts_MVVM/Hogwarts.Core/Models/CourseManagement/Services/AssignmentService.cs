using Hogwarts.Core.Data;
using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.FacultyManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public class AssignmentService: IAssignmentService
    {
        private readonly HogwartsDbContext _dbContext;

        public AssignmentService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAssignment(AssignmentDTO DTO, Guid courseId, Guid professorId)
        {
            Course course = _dbContext.Courses.Include(c => c.Students).SingleOrDefault(c => c.Id == courseId) ?? throw new ArgumentException("Invalid course ID.");
            Professor professor = _dbContext.Professors.SingleOrDefault(p => p.Id == professorId) ?? throw new ArgumentException("Invalid professor Id");

            Assignment assignment = new(DTO, professor, course);
            _dbContext.Assignments.Add(assignment);

            foreach (var student in course.Students)
            {
                var studentAssignment = new StudentAssignment(student, assignment);
                _dbContext.StudentAssignments.Add(studentAssignment);
            }

            _dbContext.SaveChanges();
        }

        public GradeType GetStudentAssignmentScore(Guid StudentAssignmentId)
        {
            var StudentAssignment = _dbContext.StudentAssignments.SingleOrDefault(sa => sa.Id == StudentAssignmentId) ?? throw new ArgumentException("Invalid ID.");
            var score = StudentAssignment.Score ?? throw new GradeNotRegisteredException("Your grade has not been registered yet.");

            return score.Value;
        }

        public void UploadStudentAssignmentAnswer(string answer, Guid studentAssignmentId)
        {
            if (string.IsNullOrWhiteSpace(answer)) throw new ArgumentException($"{nameof(answer)} can't be null.");
            var studentAssignment = _dbContext.StudentAssignments.SingleOrDefault(sa =>sa.Id == studentAssignmentId) ?? throw new ArgumentException("Invalid ID");

            studentAssignment.Answer = answer;
            _dbContext.SaveChanges();
        }

        /*
        public void AddAssignmentToCourse(Guid courseId, Assignment assignment)
        {
            Course? course = _dbContext.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                throw new ArgumentException("Invalid course id");
            }

            course.Assignments.Add(assignment);
            _ = _dbContext.SaveChanges();
        }

        public List<Assignment> GetAllAssignmentsForCourse(Guid courseId)
        {
            Course? course = _dbContext.Courses.FirstOrDefault(c => c.Id == courseId);

            return course == null ? throw new ArgumentException("Invalid course id") : course.Assignments.ToList();
        }
        public void SubmitAssignment(Guid assignmentId, string answer)
        {
            Assignment? assignment = _dbContext.Assignments.FirstOrDefault(a => a.Id == assignmentId);

            if (assignment == null)
            {
                throw new ArgumentException("Invalid assignment id");
            }

            if (DateTime.Today > assignment.DueDate)
            {
                throw new ArgumentException("Assignment submission is past due");
            }

            assignment.Answer = answer;
            _ = _dbContext.SaveChanges();
        }

        public void CheckAssignment(Guid assignmentId, Grade grade)
        {
            Assignment? assignment = _dbContext.Assignments.FirstOrDefault(a => a.Id == assignmentId);

            if (assignment == null)
            {
                throw new ArgumentException("Invalid assignment id");
            }

            if (assignment.HasBeenCheckedByTeacher)
            {
                throw new ArgumentException("Assignment has already been checked");
            }

            if (!assignment.HasBeenAnswered)
            {
                throw new ArgumentException("Assignment has not been answered yet");
            }

            assignment.Grade = grade;
            _ = _dbContext.SaveChanges();
        }*/
    }
}
