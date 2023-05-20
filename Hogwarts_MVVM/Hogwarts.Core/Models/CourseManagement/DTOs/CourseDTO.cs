using Hogwarts.Core.Models.FacultyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.CourseManagement.DTOs
{
    public class CourseDTO
    {
        public string Title { get; set; }
        public DateOnly EndDate { get; set; }
        public DayOfWeek Schedule { get; set; }
        public TimeOnly ClassStartTime { get; set; }
        public TimeOnly ClassEndTime { get; set; }
        public string Capacity { get; set; }
        public string Classroom { get; set; }
    }
}
