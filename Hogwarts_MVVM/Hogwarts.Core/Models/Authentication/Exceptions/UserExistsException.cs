using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.Authentication.Exceptions
{
    public class UserExistsException : ArgumentException
    {
        public UserExistsException()
        {
        }

        public UserExistsException(string? message) : base(message)
        {
        }

        public UserExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public UserExistsException(string? message, string? paramName) : base(message, paramName)
        {
        }

        public UserExistsException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException)
        {
        }

        protected UserExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
