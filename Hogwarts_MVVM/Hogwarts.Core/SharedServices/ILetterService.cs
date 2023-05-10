using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.TrainManagement;

namespace Hogwarts.Core.SharedServices
{
    public interface ILetterService
    {
        string GenerateTrainTicketLink(string firstName, string lastName, TrainTicket trainTicket);
        string GenerateAcceptLetterLink(string firstName, string lastName, string headmasterName,
            ActivationCode activationCode);

        void SendInvitationMail(Admin sender, string firstName, string lastName, string emailAddress,
            ActivationCode activationCode);
    }
}
