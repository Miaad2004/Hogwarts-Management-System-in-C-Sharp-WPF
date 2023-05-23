using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement;

namespace Hogwarts.Core.SharedServices
{
    public interface ILetterService
    {
        string GenerateTrainTicketLink(string firstName, string lastName, TrainTicket trainTicket);
        string GenerateAcceptLetterLink(string firstName, string lastName, string headmasterName,
                                        ActivationCode activationCode);
        Task SendInvitationMailAsync(User sender, string firstName, string lastName, string emailAddress,
                                     ActivationCode activationCode);
        Task SendTrainTicketAsync(TrainTicket trainTicket, User owner);
    }
}
