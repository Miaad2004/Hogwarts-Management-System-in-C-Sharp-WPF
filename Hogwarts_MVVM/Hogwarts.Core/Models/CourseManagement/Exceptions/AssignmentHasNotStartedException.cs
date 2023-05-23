using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.CourseManagement.Exceptions
{
    public class AssignmentHasNotStartedException : AssignmentException
    {
        public AssignmentHasNotStartedException()
        {
        }

        public AssignmentHasNotStartedException(string assignmentTitle, string professorName, DateTime startDate)
            : base($"Assignment \"{assignmentTitle} - {professorName}\" will start on {startDate}.")
        {
        }

        public AssignmentHasNotStartedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AssignmentHasNotStartedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
