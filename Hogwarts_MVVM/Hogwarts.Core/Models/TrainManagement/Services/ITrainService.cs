using Hogwarts.Core.Models.Authentication;

namespace Hogwarts.Core.Models.TrainManagement.Services
{
    public interface ITrainService
    {
        Task<Train> AddTrainAsync(DateTime departureTime, string title, string origin, string destination, string platform, int nCompartments, int nSeatsPerCompartment);
        Task<TrainTicket> GetTrainTicketAsync(Train train, User owner);
        Task<TrainTicket> GetTrainTicketAsync(Guid trainId, User owner);
        Task<TrainTicket> GetNearestTrainTicketAsync(DateTime dateTime, User owner, string origin, string destination);
        Task<TrainTicket> GetNearestTrainTicketAsync(DateTime dateTime, ActivationCode activationCode, string origin, string destination);
        Task<TrainTicket> GetTicketForNewStudentAsync(ActivationCode activationCode);
    }
}
