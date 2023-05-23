using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Core.Models.TrainManagement.Services
{
    public class TrainService : ITrainService
    {
        private readonly HogwartsDbContext _dbContext;

        public TrainService(HogwartsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Train> AddTrainAsync(
            DateTime departureTime, string title, string origin, string destination, string platform,
            int nCompartments, int nSeatsPerCompartment)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            Train train = new(departureTime, title, origin, destination, platform, nCompartments, nSeatsPerCompartment);
            await _dbContext.Trains.AddAsync(train);
            await _dbContext.SaveChangesAsync();
            return train;
        }

        public async Task<TrainTicket> GetTrainTicketAsync(Train train, User owner)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            if (train is null)
            {
                throw new ArgumentNullException(nameof(train));
            }

            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            TrainTicket ticket = train.ReserveSeat(owner);

            await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<TrainTicket> GetTrainTicketAsync(Guid trainId, User owner)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            if (owner is null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            TrainTicket ticket = (await _dbContext.Trains.Where(t => t.Id == trainId).FirstAsync()).ReserveSeat(owner);

            await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<TrainTicket> GetNearestTrainTicketAsync(DateTime depaurtureTime, User owner, string origin, string destination)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

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

            Train train = await _dbContext.Trains
                .Where(t => t.DepartureTime >= depaurtureTime &&
                            t.Origin.ToLower() == origin.ToLower() &&
                            t.Destination.ToLower() == destination.ToLower())
                .OrderBy(t => t.DepartureTime)
                .SingleOrDefaultAsync()
                ?? throw new NoTrainAvailableException(origin, destination, depaurtureTime);

            TrainTicket ticket = train.ReserveSeat(owner);
            await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();

            return ticket;
        }

        public async Task<TrainTicket> GetNearestTrainTicketAsync(DateTime depaurtureTime, ActivationCode activationCode, string origin, string destination)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            origin = origin.ToLower();
            destination = destination.ToLower();

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

            Train train = await _dbContext.Trains
                .Where(t => t.DepartureTime >= depaurtureTime &&
                            t.Origin.ToLower() == origin.ToLower() &&
                            t.Destination.ToLower() == destination.ToLower())
                .OrderBy(t => t.DepartureTime)
                .FirstOrDefaultAsync()
                ?? throw new NoTrainAvailableException(origin, destination, depaurtureTime);

            TrainTicket ticket = train.ReserveSeat(activationCode);
            await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();

            return ticket;
        }

        public async Task<TrainTicket> GetTicketForNewStudentAsync(ActivationCode activationCode)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            return await GetNearestTrainTicketAsync(DateTime.Now, activationCode, origin: "london", destination: "hogwarts");
        }
    }
}
