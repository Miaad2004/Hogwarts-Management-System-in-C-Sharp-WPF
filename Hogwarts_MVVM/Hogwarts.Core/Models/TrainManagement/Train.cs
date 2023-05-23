using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement.Exceptions;

namespace Hogwarts.Core.Models.TrainManagement
{
    public class Train : Entity
    {
        private string _title;
        private string _origin;
        private string _destination;
        private string _platform;
        private int _nCompartments;
        private int _nSeatsPerCompartment;
        private DateTime _departureTime;
        private int _nOccupiedSeats = 0;

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Title)} cannot be null or empty.");
                }

                _title = value;
            }
        }

        public string Origin
        {
            get => _origin;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Origin)} cannot be null or empty.");
                }

                _origin = char.ToUpper(value[0]) + value[1..];
            }
        }

        public string Destination
        {
            get => _destination;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Destination)} cannot be null or empty.");
                }

                _destination = char.ToUpper(value[0]) + value[1..];
            }
        }

        public string Platform
        {
            get => _platform;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Platform)} cannot be null or empty.");
                }

                _platform = value.ToLower();
            }
        }

        public int NCompartments
        {
            get => _nCompartments;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of compartments must be greater than 0.");
                }

                _nCompartments = value;
            }
        }

        public int NSeatsPerCompartment
        {
            get => _nSeatsPerCompartment;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of seats per compartment must be greater than 0.");
                }

                _nSeatsPerCompartment = value;
            }
        }

        public DateTime DepartureTime
        {
            get => _departureTime;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Departure time cannot be in the past.");
                }

                _departureTime = value;
            }
        }

        public int NOccupiedSeats
        {
            get => _nOccupiedSeats;
            private set
            {
                if (value < 0 || value > TotalCapacity)
                {
                    throw new TrainFullException($"Number of occupied seats must be between 0 and {TotalCapacity}.");
                }

                _nOccupiedSeats = value;
            }
        }

        public int TotalCapacity => NCompartments * NSeatsPerCompartment;

        public ICollection<TrainTicket> Tickets { get; private set; } = new List<TrainTicket>();
        public Train() : base()
        {

        }

        public Train(DateTime departureTime,
                     string title,
                     string origin,
                     string destination,
                     string platform,
                     int nCompartments,
                     int nSeatsPerCompartment) : base()
        {
            DepartureTime = departureTime;
            Title = title;
            Origin = origin.ToLower();
            Destination = destination.ToLower();
            Platform = platform.ToLower();
            NCompartments = nCompartments;
            NSeatsPerCompartment = nSeatsPerCompartment;
        }

        public TrainTicket ReserveSeat(User owner)
        {
            if (TotalCapacity == NOccupiedSeats)
            {
                throw new TrainFullException(this.Title);
            }

            int compartmentNumber = (NOccupiedSeats / NSeatsPerCompartment) + 1;
            int seatNumber = (NOccupiedSeats % NSeatsPerCompartment) + 1;

            NOccupiedSeats += 1;

            TrainTicket ticket = new(train: this, owner, DepartureTime, Origin, Destination, Platform, compartmentNumber,
                                     seatNumber);
            return ticket;
        }

        public TrainTicket ReserveSeat(ActivationCode activationCode)
        {
            if (TotalCapacity == NOccupiedSeats)
            {
                throw new TrainFullException(this.Title);
            }

            int compartmentNumber = (NOccupiedSeats / NSeatsPerCompartment) + 1;
            int seatNumber = (NOccupiedSeats % NSeatsPerCompartment) + 1;

            NOccupiedSeats += 1;

            TrainTicket ticket = new(this, activationCode, DepartureTime, Origin, Destination, Platform,
                                         compartmentNumber, seatNumber);

            return ticket;
        }

        public override string ToString()
        {
            return $"Train - Origin: {Origin} - DepartureTime: {DepartureTime} - TotalCapacity: {TotalCapacity} - OccupiedSeats: {NOccupiedSeats}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Origin, DepartureTime, NCompartments, NSeatsPerCompartment, NOccupiedSeats,
                                    TotalCapacity);
        }
    }
}
