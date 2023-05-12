using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement.Exceptions;

namespace Hogwarts.Core.Models.TrainManagement.Services
{
    public class TrainService : ITrainService
    {
        private readonly HogwartsDbContext _dbContext;

        public TrainService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Train AddTrain(
            DateTime departureTime, string title, string origin, string destination, string platform,
            int nCompartments, int nSeatsPerCompartment)
        {
            Train train = new(departureTime, title, origin, destination, platform, nCompartments, nSeatsPerCompartment);
            _ = _dbContext.Trains.Add(train);
            _ = _dbContext.SaveChanges();
            return train;
        }

        public TrainTicket GetTrainTicket(Train train, User owner)
        {
            if (train is null)
            {
                throw new ArgumentNullException(nameof(train));
            }

            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            TrainTicket ticket = train.ReserveSeat(owner);
            return ticket;
        }

        public TrainTicket GetNearestTrainTicket(DateTime depaurtureTime, User owner, string origin, string destination)
        {
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

            Train? train = _dbContext.Trains
                .Where(t => t.DepartureTime >= depaurtureTime &&
                            t.Origin == origin.ToLower() &&
                            t.Destination == destination.ToLower())
                .OrderBy(t => t.DepartureTime)
                .FirstOrDefault();

            if (train == null)
            {
                throw new TrainNotFoundException($"No train found departing from {origin} after {depaurtureTime}.");
            }

            TrainTicket ticket = train.ReserveSeat(owner);
            return ticket;
        }

        public TrainTicket GetNearestTrainTicket(DateTime depaurtureTime, ActivationCode activationCode, string origin, string destination)
        {
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

            Train? train = _dbContext.Trains
                .Where(t => t.DepartureTime >= depaurtureTime &&
                            t.Origin == origin.ToLower() &&
                            t.Destination == destination.ToLower())
                .OrderBy(t => t.DepartureTime)
                .FirstOrDefault();

            if (train == null)
            {
                throw new TrainNotFoundException($"No train found departing from {origin} to {destination} after {depaurtureTime}.");
            }

            TrainTicket ticket = train.ReserveSeat(activationCode);
            return ticket;
        }

        public TrainTicket GetTicketForNewStudent(ActivationCode activationCode)
        {
            return GetNearestTrainTicket(DateTime.Now, activationCode, origin: "London",
                                         destination: "Hogwarts");
        }
    }
}
