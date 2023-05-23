using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.CourseManagement.Exceptions
{
    public class GradeNotRegisteredException : CourseException
    {
        public GradeNotRegisteredException()
        {
        }

        public GradeNotRegisteredException(string? message) : base(message)
        {
        }

        public GradeNotRegisteredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GradeNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
