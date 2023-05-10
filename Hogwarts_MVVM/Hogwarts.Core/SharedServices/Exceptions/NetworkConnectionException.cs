using System;
using System.Runtime.Serialization;

namespace Hogwarts.Core.SharedServices.Exceptions
{
    public class NetworkConnectionException : Exception
    {
        public NetworkConnectionException()
        {
        }

        public NetworkConnectionException(string? message) : base(message)
        {
        }

        public NetworkConnectionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NetworkConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
