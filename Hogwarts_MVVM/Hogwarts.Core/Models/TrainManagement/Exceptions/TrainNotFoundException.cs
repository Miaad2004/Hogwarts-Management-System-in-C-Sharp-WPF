using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.TrainManagement.Exceptions
{
    [Serializable]
    internal class TrainNotFoundException : TrainException
    {
        public TrainNotFoundException()
        {
        }

        public TrainNotFoundException(string? message) : base(message)
        {
        }

        public TrainNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TrainNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}