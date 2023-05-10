using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement.Exceptions;
using System;
using System.Linq;

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
            DateTime departureTime, string origin, string destination, string platform, int nCompartments,
            int nSeatsPerCompartment)
        {
            Train train = new(departureTime, origin, destination, platform, nCompartments, nSeatsPerCompartment);
            _dbContext.Trains.Add(train);
            _dbContext.SaveChanges();
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

            var ticket = train.ReserveSeat(owner);
            return ticket;
        }

        public TrainTicket GetNearestTrainTicket(DateTime dateTime, User owner, string origin, string destination)
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

            var train = _dbContext.Trains
                .Where(t => t.departureTime >= dateTime && t.origin == origin)
                .OrderBy(t => t.departureTime)
                .FirstOrDefault();

            if (train == null)
            {
                throw new TrainNotFoundException($"No train found departing from {origin} after {dateTime}.");
            }

            var ticket = train.ReserveSeat(owner);
            return ticket;
        }

        public TrainTicket GetNearestTrainTicket(DateTime dateTime, ActivationCode activationCode, string origin, string destination)
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

            var train = _dbContext.Trains
                .Where(t => t.departureTime >= dateTime && t.origin == origin)
                .OrderBy(t => t.departureTime)
                .FirstOrDefault();

            if (train == null)
            {
                throw new TrainNotFoundException($"No train found departing from {origin} after {dateTime}.");
            }

            var ticket = train.ReserveSeat(activationCode);
            return ticket;
        }

        public TrainTicket GetTicketForNewStudent(ActivationCode activationCode)
        {
            return GetNearestTrainTicket(new DateTime(DateTime.Now.Year, 9, 1), activationCode, origin: "London",
                                         destination: "Hogwarts");
        }
    }
}
