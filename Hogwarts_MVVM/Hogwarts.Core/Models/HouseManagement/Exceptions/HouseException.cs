using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.HouseManagement.Exceptions
{
    public class HouseException : Exception
    {
        public HouseException()
        {
        }

        public HouseException(string? message) : base(message)
        {
        }

        public HouseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HouseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
