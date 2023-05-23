namespace Hogwarts.Core.Models.CourseManagement.DTOs
{
    public class AssignmentDTO
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool RequireForestAccess { get; set; }
    }
}
