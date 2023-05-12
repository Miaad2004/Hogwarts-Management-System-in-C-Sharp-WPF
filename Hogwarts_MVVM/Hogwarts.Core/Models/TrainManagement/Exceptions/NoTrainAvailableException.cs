using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.TrainManagement.Exceptions
{
    public class NoTrainAvailableException : TrainException
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
