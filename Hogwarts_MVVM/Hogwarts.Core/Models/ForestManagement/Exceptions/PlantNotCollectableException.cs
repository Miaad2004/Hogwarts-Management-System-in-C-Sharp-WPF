using System.Runtime.Serialization;

namespace Hogwarts.Core.Models.ForestManagement.Exceptions
{
    public class PlantNotCollectableException : PlantException
    {
        public PlantNotCollectableException()
        {
        }

        public PlantNotCollectableException(DateTime harvestTime) : base($"Plant will be collectable in {(harvestTime - DateTime.Now).TotalMinutes:F3} minute(s)")
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
