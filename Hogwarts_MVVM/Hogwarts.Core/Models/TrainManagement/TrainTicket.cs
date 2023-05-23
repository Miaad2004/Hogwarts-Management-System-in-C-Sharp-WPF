using Hogwarts.Core.Models.Authentication;

namespace Hogwarts.Core.Models.TrainManagement
{
    public class TrainTicket : Entity
    {
        private DateTime _depaurtureTime;

        public Train Train { get; set; }
        public Guid TrainId { get; private set; }
        public Guid OwnerId { get; private set; }
        public DateTime DepartureTime
        {
            get => _depaurtureTime;
            private set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Depaurture time can't be in the past.");
                }
                _depaurtureTime = value;
            }
        }
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public string Platform { get; private set; }
        public int CompartmentNumber { get; private set; }
        public int SeatNumber { get; private set; }

        public TrainTicket()
            : base()
        {

        }
        public TrainTicket(Train train, User owner, DateTime departureTime, string origin, string destination,
                           string platform, int compartmentnumber, int seatNumber)
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

            this.Train = train;
            this.TrainId = train.Id;
            this.OwnerId = owner.Id;
            this.DepartureTime = departureTime;
            this.Origin = origin;
            this.Destination = destination;
            this.Platform = platform;
            this.CompartmentNumber = compartmentnumber;
            this.SeatNumber = seatNumber;
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

            this.Train = train;
            this.TrainId = train.Id;
            this.OwnerId = activationCode.Id;
            this.DepartureTime = departureTime;
            this.Origin = origin;
            this.Destination = destination;
            this.Platform = platform;
            this.CompartmentNumber = compartmentnumber;
            this.SeatNumber = seatNumber;
        }
        public bool HasExpired()
        {
            return DateTime.Now > DepartureTime;
        }

        public override string ToString()
        {
            return $"TrainTicket - DepartureTime: {DepartureTime} - Origin: {Origin} - Destination: {Destination} - Comparment Number: {CompartmentNumber} - Seat Number: {SeatNumber}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TrainId, OwnerId, DepartureTime, Origin, Destination, CompartmentNumber, SeatNumber);
        }
    }
}
