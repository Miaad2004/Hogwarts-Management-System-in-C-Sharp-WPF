using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.TrainManagement.Exceptions
{
    public class TrainException : Exception
    {
        public TrainException()
        {
        }

        public TrainException(string? message) : base(message)
        {
        }

        public TrainException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TrainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
