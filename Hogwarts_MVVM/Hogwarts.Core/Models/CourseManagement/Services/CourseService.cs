using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.CourseManagement.DTOs;
using Hogwarts.Core.Models.CourseManagement.Exceptions;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.HouseManagement;
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

        public Course GetCourseById(Guid courseId)
        {
            return _dbContext.Courses.SingleOrDefault(c => c.Id == courseId);
        }
        public void AddCourse(CourseDTO DTO)
        {
            if (DTO == null)
            {
                throw new ArgumentNullException(nameof(DTO));
            }

            Professor currentUser = (Professor)SessionManager.CurrentSession.User;
            Course course = new(DTO, professor: currentUser);
            if(_dbContext.Courses.ToList().Any(c => c.ConflictsWith(course)))
            {
                throw new CourseConflictException("Course conflicts with another course.");
            }

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
        }

        public void EnrollStudentInCourse(Guid studentId, Guid courseId)
        {
            
            Student? student = _dbContext.Students.Include(s => s.Courses).SingleOrDefault(s => s.Id == studentId) ?? throw new ArgumentException("Invalid student id");
            Course? course = _dbContext.Courses.Include(c => c.Students).SingleOrDefault(c => c.Id == courseId) ?? throw new ArgumentException("Invalid course Id");

            if (course.Students.Contains(student))
            {
                throw new ArgumentException("Student is already enrolled in the course");
            }

            if (course.Capacity == course.Students.Count)
            {
                throw new ArgumentException("Course is already full");
            }

            List<Course> studentCourses = _dbContext.Courses.Where(c => c.Students.Contains(student)).ToList().Where(c => !c.HasFinished).ToList();
            if (studentCourses.Count >= student.MaxAllowedCourses)
            {
                throw new ArgumentException("Student has already enrolled in the maximum number of courses");
            }

            foreach (Course? enrolledCourse in studentCourses)
            {
                if (enrolledCourse.Schedule == course.Schedule &&
                    enrolledCourse.ClassStartTime <= course.ClassEndTime &&
                    enrolledCourse.ClassEndTime >= course.ClassStartTime)
                {
                    throw new CourseConflictException("Course schedule conflicts with another course");
                }
            }

            course.OnSeatReserved();
            course.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public GradeType GetStudentGrade(Guid studentId, Guid courseId)
        {
            Student? student = _dbContext.Students.Include(s => s.Courses).Include(s => s.Grades).SingleOrDefault(s => s.Id == studentId) ?? throw new ArgumentException("Invalid student id");
            if (student.Courses.SingleOrDefault(c => c.Id == courseId) == null)
            {
                throw new ArgumentException("Course ID is invalid or the student is not enrolled in the course");
            }

            Grade? Grade = student.Grades.SingleOrDefault(g => g.CourseId == courseId && g.StudentId == studentId) ?? throw new GradeNotRegisteredException("Your grade has not been registered yet.");

            return Grade.Value;
        }

        public int GetActiveCourseCount(Guid studentId)
        {
            Student? student = _dbContext.Students.Include(s => s.Courses).Include(s => s.Grades).SingleOrDefault(s => s.Id == studentId) ?? throw new ArgumentException("Invalid student id");
            return student.Courses.Count;
        }
        public void AddGradeToStudentInCourse(Guid studentId, Guid courseId, Grade grade)
        {
            Course? course = _dbContext.Courses.SingleOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                throw new ArgumentException("Invalid course id");
            }

            Grade? gradeEntry = course.Grades.SingleOrDefault(g => g.Id == studentId);

            if (gradeEntry == null)
            {
                throw new ArgumentException("Student is not enrolled in the course");
            }

            //course.Grades[gradeEntry.Item1] = (int)grade;
            _ = _dbContext.SaveChanges();
        }
       
    }
}
