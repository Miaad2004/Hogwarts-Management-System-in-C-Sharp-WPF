using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
