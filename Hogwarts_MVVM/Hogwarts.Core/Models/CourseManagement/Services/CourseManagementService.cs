using Hogwarts.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hogwarts.Core.Models.CourseManagement.Services
{
    public class CourseManagementService : ICourseManagementService
    {
        private readonly HogwartsDbContext _dbContext;

        public CourseManagementService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Course GetCourseById(Guid courseId)
        {
            return _dbContext.Courses.FirstOrDefault(c => c.Id == courseId);
        }

        public List<Course> GetAllCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public void AddCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
        }

        public void RemoveCourse(Course course)
        {
            _dbContext.Courses.Remove(course);
            _dbContext.SaveChanges();
        }

        public void EnrollStudentInCourse(Guid studentId, Guid courseId)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.Id == studentId);
            var course = _dbContext.Courses.FirstOrDefault(c => c.Id == courseId);

            if (student == null || course == null)
            {
                throw new ArgumentException("Invalid student or course id");
            }

            if (course.Students.Contains(student))
            {
                throw new ArgumentException("Student is already enrolled in the course");
            }

            if (course.Capacity == course.Students.Count)
            {
                throw new ArgumentException("Course is already full");
            }

            var studentCourses = _dbContext.Courses.Where(c => c.Students.Contains(student)).ToList();
            if (studentCourses.Count >= student.MaxAllowedCourses)
            {
                throw new ArgumentException("Student has already enrolled in the maximum number of courses");
            }

            foreach (var enrolledCourse in studentCourses)
            {
                if (enrolledCourse.StartDate <= course.EndDate && course.StartDate <= enrolledCourse.EndDate)
                {
                    throw new ArgumentException("Course schedule conflicts with another course");
                }
            }

            course.Students.Add(student);
            _dbContext.SaveChanges();
        }


        public void AddGradeToStudentInCourse(Guid studentId, Guid courseId, Grade grade)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                throw new ArgumentException("Invalid course id");
            }

            var gradeEntry = course.Grades.FirstOrDefault(g => g.Id == studentId);

            if (gradeEntry == null)
            {
                throw new ArgumentException("Student is not enrolled in the course");
            }

            //course.Grades[gradeEntry.Item1] = (int)grade;
            _dbContext.SaveChanges();
        }
        public void AddAssignmentToCourse(Guid courseId, Assignment assignment)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                throw new ArgumentException("Invalid course id");
            }

            course.Assignments.Add(assignment);
            _dbContext.SaveChanges();
        }

        public List<Assignment> GetAllAssignmentsForCourse(Guid courseId)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                throw new ArgumentException("Invalid course id");
            }

            return course.Assignments.ToList();
        }
        public void SubmitAssignment(Guid assignmentId, string answer)
        {
            var assignment = _dbContext.Assignments.FirstOrDefault(a => a.Id == assignmentId);

            if (assignment == null)
            {
                throw new ArgumentException("Invalid assignment id");
            }

            if (DateTime.Today > assignment.EndDate)
            {
                throw new ArgumentException("Assignment submission is past due");
            }

            assignment.Answer = answer;
            _dbContext.SaveChanges();
        }

        public void CheckAssignment(Guid assignmentId, Grade grade)
        {
            var assignment = _dbContext.Assignments.FirstOrDefault(a => a.Id == assignmentId);

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
            _dbContext.SaveChanges();
        }
    }
}
