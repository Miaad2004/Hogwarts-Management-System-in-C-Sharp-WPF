using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.DormitoryManagement.Exceptions
{
    public class DormitoryFullException : DormitoryException
    {
        public DormitoryFullException()
        {
        }

        public DormitoryFullException(string dormTitle) : base($"{dormTitle} dormitory is full.")
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
