using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.StudentManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hogwarts.Core.Models.CourseManagement
{
    public class Assignment: Entity
    {
        public DateTime SartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Description { get; private set; }
        public string? Answer { get; set; }
        public Grade? Grade { get; set; }
        public bool HasBeenAnswered => Answer != null;
        public bool HasBeenCheckedByTeacher => Grade != null;
        public Professor Owner { get; private set; }
        public ICollection<Student> TargetStudents { get; private set; }

        public Assignment()
            : base()
        {

        }
        public Assignment(Professor owner, IEnumerable<Student> targetStudents, DateTime startDate, DateTime endDate, string description)
            : base()
        {
            Owner = owner;
            TargetStudents = targetStudents.ToList();
            SartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

    }

}
