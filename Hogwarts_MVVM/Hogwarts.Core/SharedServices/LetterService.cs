using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.FacultyManagement;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.Models.TrainManagement.Services;
using Hogwarts.Core.SharedServices.Exceptions;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Text;

namespace Hogwarts.Core.SharedServices
{
    public class LetterService: ILetterService
    {
        static readonly string HOGWARTS_API_DOMAIN = ConfigurationManager.AppSettings["LetterServiceDomain"] ?? throw new ConfigurationErrorsException("Invalid Configuration");
        private readonly TrainService _trainService;

        public LetterService(TrainService trainService)
        {
            _trainService = trainService;
        }
        public string GenerateTrainTicketLink(string firstName, string lastName, TrainTicket trainTicket)
        {
            var ticketInfo = new
            {
                FirstName = firstName,
                LastName = lastName,
                Platform = trainTicket.platform,
                Departure = trainTicket.origin,
                Date = trainTicket.departureTime.ToShortDateString(),
                Time = trainTicket.departureTime.ToShortTimeString(),
                Seat = trainTicket.seatNumber,
                Compartment = trainTicket.compartmentNumber
            };

            string json = JsonConvert.SerializeObject(ticketInfo);
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            string link = $"{HOGWARTS_API_DOMAIN}/hogwarts-express-ticket/{base64}";

            string html = $"<p> Your HogwartsExpress ticket is available at this <a href='{link}'>link</a></p>";
            return html;
        }

        public string GenerateAcceptLetterLink(string firstName, string lastName, string headmasterName,
                                               ActivationCode activationCode)
        {
            var letterInfo = new
            {
                Name = firstName,
                LastName = lastName,
                ActivationCode = activationCode.Code,
                HeadmasterName = headmasterName
            };

            string json = JsonConvert.SerializeObject(letterInfo);
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            string link = $"{HOGWARTS_API_DOMAIN}/hogwarts-letter/{base64}";

            string html = $"<p> Your acceptance letter is available at this <a href='{link}'>link</a></p>";
            return html;
        }

        public void SendInvitationMail(Admin sender, string firstName, string lastName, string emailAddress,
            ActivationCode activationCode)
        {
            string acceptLetterLink = GenerateAcceptLetterLink(firstName, lastName, sender.FullName, activationCode);
            TrainTicket trainTicket = _trainService.GetTicketForNewStudent(activationCode);
            string trainTicketLink = GenerateTrainTicketLink(firstName, lastName, trainTicket);  

            string emailSubject = $"Hogwarts Acceptance Letter for Mr/Miss {firstName} {lastName}";
            string emailBody = "Dear " + firstName + ",\n\n" +
                    "We are pleased to inform you that you have been accepted into Hogwarts School of Witchcraft and Wizardry! " +
                    "You have demonstrated exceptional magical ability and we are excited to welcome you as a new student.\n\n" +
                    "We look forward to meeting you and helping you develop your magical talents. " +
                    "If you have any questions or concerns, please do not hesitate to contact us.\n\n";
            
            string emailFooter = "Congratulations once again on your acceptance to Hogwarts!\n\n" +
                    "Sincerely,\n\n" +
                     sender.FullName + "\n" +
                    "Headmaster/Headmistress";

            string email =
                "<html><body>" +
                emailBody + "\n" +
                acceptLetterLink +
                trainTicketLink +
                emailFooter +

                "</body></html>";

            try
            {
                StaticMailService.SendEmail(recipient: email, subject: emailSubject, body: emailBody);
            }
            catch (NetworkConnectionException ex)
            {
                throw ex;
            }

        }
    }
}
