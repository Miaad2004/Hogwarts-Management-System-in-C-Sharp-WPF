using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.TrainManagement.Exceptions
{
    public class NoTrainAvailableException : Exception
    {
        public NoTrainAvailableException()
        {
        }

        public NoTrainAvailableException(string? message) : base(message)
        {
        }

        public NoTrainAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoTrainAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
