using Hogwarts.Core.Models.HouseManagement;
using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.DormitoryManagement.Exceptions
{
    public class NoDormitoryFoundException : DormitoryException
    {
        public NoDormitoryFoundException()
        {
        }

        public NoDormitoryFoundException(HouseType houseType) : base($"No dormitories were found for the house {houseType}")
        {
        }

        public NoDormitoryFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoDormitoryFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
