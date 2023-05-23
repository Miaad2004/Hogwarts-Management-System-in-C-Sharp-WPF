using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.CourseManagement.Exceptions
{
    public class CourseException : Exception
    {
        public CourseException()
        {
        }

        public CourseException(string? message) : base(message)
        {
        }

        public CourseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CourseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
