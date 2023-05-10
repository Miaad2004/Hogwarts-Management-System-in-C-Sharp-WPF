using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement.Exceptions;
using System;
using System.Collections.Generic;

namespace Hogwarts.Core.Models.TrainManagement
{
    public class Train: Entity
    {
        // Set id to a unique hash code
        public readonly string origin;
        public readonly string destination;
        public readonly string platform;
        public readonly DateTime departureTime;
        public readonly int nCompartments;
        public readonly int nSeatsPerCompartment;
        private int NOccupiedSeats { get; set; }
        public int TotalCapacity
        {
            get { return nCompartments * nSeatsPerCompartment; }
        }

        public ICollection<TrainTicket> Tickets { get; private set; }

        public Train()
            : base()
        {

        }
        public Train(
            DateTime departureTime, string origin, string destination, string platform, int nCompartments,
            int nSeatsPerCompartment)
            : base()
        {
            // Properties are readonly, so we dont have to add validation checks in properties
            if (departureTime < DateTime.UtcNow)
                throw new ArgumentException("Departure time cannot be in the past.", nameof(departureTime));

            if (string.IsNullOrEmpty(origin))
                throw new ArgumentException("Origin cannot be null or empty.", nameof(origin));


            if (string.IsNullOrEmpty(platform))
                throw new ArgumentException("Platform cannot be null or empty.", nameof(platform));

            if (string.IsNullOrEmpty(destination))
                throw new ArgumentException("Destination cannot be null or empty.", nameof(destination));

            if (nCompartments <= 0)
                throw new ArgumentException("Number of compartments must be greater than 0.", nameof(nCompartments));

            if (nSeatsPerCompartment <= 0)
                throw new ArgumentException("Number of seats per compartment must be greater than 0.", nameof(nSeatsPerCompartment));

            this.origin = origin;
            this.destination = destination;
            this.platform = platform;
            this.departureTime = departureTime;
            this.nCompartments = nCompartments;
            this.nSeatsPerCompartment = nSeatsPerCompartment;
            NOccupiedSeats = 0;
        }

        public TrainTicket ReserveSeat(User owner)
        {
            if (TotalCapacity == NOccupiedSeats)
                throw new TrainFullException($"Train with ID {Id} is full. Create a new train and try again.");

            int compartmentNumber = NOccupiedSeats / nSeatsPerCompartment + 1;
            int seatNumber = NOccupiedSeats % nSeatsPerCompartment + 1;

            NOccupiedSeats += 1;

            var ticket = new TrainTicket(this, owner, departureTime, origin, destination, compartmentNumber, seatNumber);
            Tickets.Add(ticket);
            return ticket;
        }

        public TrainTicket ReserveSeat(ActivationCode activationCode)
        {
            if (TotalCapacity == NOccupiedSeats)
                throw new TrainFullException($"Train with ID {Id} is full. Create a new train and try again.");

            int compartmentNumber = NOccupiedSeats / nSeatsPerCompartment + 1;
            int seatNumber = NOccupiedSeats % nSeatsPerCompartment + 1;

            NOccupiedSeats += 1;

            var ticket = new TrainTicket(this, activationCode, departureTime, origin, destination, platform,
                                         compartmentNumber, seatNumber);
            Tickets.Add(ticket);
            return ticket;
        }

        public override string ToString()
        {
            return $"Train - Origin: {origin} - DepartureTime: {departureTime} - TotalCapacity: {TotalCapacity} - OccupiedSeats: {NOccupiedSeats}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(origin, departureTime, nCompartments, nSeatsPerCompartment, NOccupiedSeats,
                                    TotalCapacity);
        }
    }
}
