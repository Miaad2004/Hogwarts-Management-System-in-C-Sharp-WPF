using Hogwarts.Core.Models.Authentication;

namespace Hogwarts.Core.Models.TrainManagement.Services
{
    public interface ITrainService
    {
        Train AddTrain(DateTime departureTime, string title, string origin, string destination, string platform, int nCompartments, int nSeatsPerCompartment);
        TrainTicket GetTrainTicket(Train train, User owner);
        TrainTicket GetTrainTicket(Guid trainId, User owner);
        TrainTicket GetNearestTrainTicket(DateTime dateTime, User owner, string origin, string destination);
        TrainTicket GetNearestTrainTicket(DateTime dateTime, ActivationCode activationCode, string origin, string destination);
        TrainTicket GetTicketForNewStudent(ActivationCode activationCode);
    }
}
