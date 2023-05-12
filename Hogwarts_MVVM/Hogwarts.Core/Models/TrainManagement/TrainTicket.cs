using Hogwarts.Core.Models.Authentication;

namespace Hogwarts.Core.Models.TrainManagement
{
    public class TrainTicket : Entity
    {
        public readonly Guid trainId;
        public readonly Guid ownerId;
        public readonly DateTime departureTime;
        public readonly string origin;
        public readonly string destination;
        public readonly string platform;
        public readonly int compartmentNumber;
        public readonly int seatNumber;

        public TrainTicket()
            : base()
        {

        }
        public TrainTicket(Train train, User owner, DateTime departureTime, string origin, string destination,
                           int compartmentnumber, int seatNumber)
            : base()
        {
            if (train is null)
            {
                throw new ArgumentNullException(nameof(train));
            }

            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (string.IsNullOrEmpty(origin))
            {
                throw new ArgumentException($"'{nameof(origin)}' cannot be null or empty.", nameof(origin));
            }

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentException($"'{nameof(destination)}' cannot be null or empty.", nameof(destination));
            }

            trainId = train.Id;
            ownerId = owner.Id;
            this.departureTime = departureTime;
            this.origin = origin;
            this.destination = destination;
            compartmentNumber = compartmentnumber;
            this.seatNumber = seatNumber;
        }

        public TrainTicket(Train train, ActivationCode activationCode, DateTime departureTime, string origin, string destination,
                   string platform, int compartmentnumber, int seatNumber)
            : base()
        {
            if (train is null)
            {
                throw new ArgumentNullException(nameof(train));
            }

            if (activationCode is null)
            {
                throw new ArgumentNullException(nameof(activationCode));
            }

            if (string.IsNullOrEmpty(origin))
            {
                throw new ArgumentException($"'{nameof(origin)}' cannot be null or empty.", nameof(origin));
            }

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentException($"'{nameof(destination)}' cannot be null or empty.", nameof(destination));
            }

            if (string.IsNullOrEmpty(platform))
            {
                throw new ArgumentException($"'{nameof(platform)}' cannot be null or empty.", nameof(platform));
            }

            trainId = train.Id;
            ownerId = activationCode.Id;
            this.departureTime = departureTime;
            this.origin = origin;
            this.destination = destination;
            this.platform = platform;
            compartmentNumber = compartmentnumber;
            this.seatNumber = seatNumber;
        }
        public bool HasExpired()
        {
            return DateTime.Now > departureTime;
        }

        public override string ToString()
        {
            return $"TrainTicket - DepartureTime: {departureTime} - Origin: {origin} - Destination: {destination} - Comparment Number: {compartmentNumber} - Seat Number: {seatNumber}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(trainId, ownerId, departureTime, origin, destination, compartmentNumber, seatNumber);
        }
    }
}
