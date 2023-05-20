using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
