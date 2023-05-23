using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.CourseManagement.Exceptions
{
    public class AssignmentException : Exception
    {
        public AssignmentException()
        {
        }

        public AssignmentException(string? message) : base(message)
        {
        }

        public AssignmentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AssignmentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
