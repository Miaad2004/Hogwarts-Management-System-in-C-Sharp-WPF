using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.HouseManagement.Exceptions
{
    public class HouseAlreadyExistsException : HouseException
    {
        public HouseAlreadyExistsException()
        {
        }

        public HouseAlreadyExistsException(string? message) : base(message)
        {
        }

        public HouseAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HouseAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
