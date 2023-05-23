using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public class CourseService : ICourseService
    {
        private readonly HogwartsDbContext _dbContext;

        public CourseService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddCourseAsync(CourseDTO courseDTO)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            if (courseDTO == null)
            {
                throw new ArgumentNullException(nameof(courseDTO));
            }

            Professor currentUser = SessionManager.CurrentSession?.User as Professor ?? throw new Exception("Current session user is not a Professor.");
            Course course = new(courseDTO, professor: currentUser);

            if ((await _dbContext.Courses.ToListAsync()).Any(c => c.ConflictsWith(course)))
            {
                throw new CourseConflictException("Course conflicts with another course.");
            }

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
        }

        public async Task EnrollStudentInCourseAsync(Guid studentId, Guid courseId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            Student? student = await _dbContext.Students
                .Include(s => s.Courses)
                .SingleOrDefaultAsync(s => s.Id == studentId)
                ?? throw new ArgumentException("Invalid student id");

            Course? course = await _dbContext.Courses
                .Include(c => c.Students)
                .Include(c => c.Grades)
                .SingleOrDefaultAsync(c => c.Id == courseId)
                ?? throw new ArgumentException("Invalid course Id");

            if (course.Students.Contains(student))
            {
                throw new ArgumentException("Student is already enrolled in the course");
            }

            if (course.Capacity == course.Students.Count())
            {
                throw new ArgumentException("Course is already full");
            }

            var studentCourses = (await _dbContext.Courses
                 .Where(c => c.Students.Contains(student))
                 .ToListAsync())
                 .Where(c => !c.HasFinished);

            if (studentCourses.Count() >= student.MaxAllowedCourses)
            {
                throw new ArgumentException("Student has already enrolled in the maximum number of courses");
            }

            foreach (Course? enrolledCourse in studentCourses)
            {
                if (enrolledCourse.Schedule == course.Schedule &&
                    enrolledCourse.ClassStartTime <= course.ClassEndTime &&
                    enrolledCourse.ClassEndTime >= course.ClassStartTime)
                {
                    throw new CourseConflictException($"Course schedule conflicts with {enrolledCourse.Title} course");
                }
            }

            var grade = new Grade(student, course);

            course.OnSeatReserved();
            course.Students.Add(student);
            await _dbContext.Grades.AddAsync(grade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GradeType> GetStudentGradeAsync(Guid studentId, Guid courseId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            Grade grade = await _dbContext.Grades.Where(g => g.CourseId == courseId && g.StudentId == studentId).SingleOrDefaultAsync() ?? throw new ArgumentException("Invalid ID");
            if (grade == null || grade.GradeValue == GradeType.NotSpecified)
            {
                throw new GradeNotRegisteredException("Your grade has not been registered yet.");
            }

            return grade.GradeValue;
        }

        public async Task SetStudentGradeAsync(Guid studentId, Guid courseId, GradeType gradeValue)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Professor);

            Student? student = await _dbContext.Students
                .Include(s => s.Courses)
                .Include(s => s.Grades)
                .SingleOrDefaultAsync(s => s.Id == studentId)
                ?? throw new ArgumentException("Invalid student id");

            Course? course = student.Courses.FirstOrDefault(c => c.Id == courseId) ?? throw new ArgumentException("Course ID is invalid or the student is not enrolled in the course");
            Grade grade = course.Grades.Where(g => g.StudentId == studentId).FirstOrDefault() ?? throw new ArgumentException();

            grade.GradeValue = gradeValue;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetActiveCourseCountAsync(Guid studentId)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            Student? student = await _dbContext.Students
                .Include(s => s.Courses)
                .Include(s => s.Grades)
                .SingleOrDefaultAsync(s => s.Id == studentId)
                ?? throw new ArgumentException("Invalid student id");

            return student.Courses.Count();
        }
    }
}
