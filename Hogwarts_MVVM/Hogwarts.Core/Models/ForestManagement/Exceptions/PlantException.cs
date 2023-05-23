using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.ForestManagement.Exceptions
{
    public class PlantException : Exception
    {
        public PlantException()
        {
        }

        public PlantException(string? message) : base(message)
        {
        }

        public PlantException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PlantException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
