using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.ForestManagement.Exceptions
{
    public class PlantNotCollectableException : PlantException
    {
        public PlantNotCollectableException()
        {
        }

        public PlantNotCollectableException(string? message) : base(message)
        {
        }

        public PlantNotCollectableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PlantNotCollectableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
