using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.TrainManagement.Exceptions
{
    public class TrainFullException : TrainException
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
