using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.TrainManagement.Exceptions
{
    public class NoTrainAvailableException : TrainException
    {
        public NoTrainAvailableException()
        {
        }

        public NoTrainAvailableException(string origin, string destination, DateTime depaurtureTime)
            : base($"No train avialable from {origin} to {destination} after {depaurtureTime}")
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
