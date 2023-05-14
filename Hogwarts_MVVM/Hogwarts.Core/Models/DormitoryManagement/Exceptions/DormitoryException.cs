using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.DormitoryManagement.Exceptions
{
    public class DormitoryException : Exception
    {
        public DormitoryException()
        {
        }

        public DormitoryException(string? message) : base(message)
        {
        }

        public DormitoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DormitoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
