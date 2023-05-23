using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.CourseManagement.Exceptions
{
    public class DeadlineExceededException : AssignmentException
    {
        public DeadlineExceededException()
        {
        }

        public DeadlineExceededException(string assignmentTitle, DateTime dueDate)
            : base($"Assignment \"{assignmentTitle}\" ended on {dueDate}.")
        {
        }

        public DeadlineExceededException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DeadlineExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
