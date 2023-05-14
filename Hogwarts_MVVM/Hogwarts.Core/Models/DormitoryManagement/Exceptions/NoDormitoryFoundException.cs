using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.DormitoryManagement.Exceptions
{
    public class NoDormitoryFoundException : DormitoryException
    {
        public NoDormitoryFoundException()
        {
        }

        public NoDormitoryFoundException(string? message) : base(message)
        {
        }

        public NoDormitoryFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoDormitoryFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
