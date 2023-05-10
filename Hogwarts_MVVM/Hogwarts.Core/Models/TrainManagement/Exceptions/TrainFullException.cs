using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.TrainManagement.Exceptions
{
    public class TrainFullException : Exception
    {
        public TrainFullException()
        {
        }

        public TrainFullException(string? message) : base(message)
        {
        }

        public TrainFullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TrainFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
