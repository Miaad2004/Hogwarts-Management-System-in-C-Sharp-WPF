using System;
using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.DormitoryManagement.Exceptions
{
    public class DormitoryFullException : Exception
    {
        public DormitoryFullException()
        {
        }

        public DormitoryFullException(string? message) : base(message)
        {
        }

        public DormitoryFullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DormitoryFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
