using Hogwarts.Core.Models.FacultyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.CourseManagement.DTOs
{
    public class AssignmentDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool RequireForestAccess { get; set; }
    }
}
