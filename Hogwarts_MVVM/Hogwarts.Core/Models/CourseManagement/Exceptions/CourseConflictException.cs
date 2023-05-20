using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.CourseManagement.Exceptions
{
    public class CourseConflictException : CourseException
    {
        public CourseConflictException()
        {
        }

        public CourseConflictException(string? message) : base(message)
        {
        }

        public CourseConflictException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CourseConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
