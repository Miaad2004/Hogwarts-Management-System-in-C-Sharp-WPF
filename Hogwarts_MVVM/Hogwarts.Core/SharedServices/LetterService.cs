﻿using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.Models.TrainManagement.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;

namespace Hogwarts.Core.SharedServices
{
    public class LetterService : ILetterService
    {
        private static readonly string HOGWARTS_API_DOMAIN = GetAPIDomain();
        private readonly ITrainService _trainService;

        public LetterService(ITrainService trainService)
        {
            _trainService = trainService;
        }

        private static string GetAPIDomain()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration["appSettings:LetterServiceDomain"] ?? throw new ConfigurationErrorsException("Invalid Configuration");
        }

        public string GenerateTrainTicketLink(string firstName, string lastName, TrainTicket trainTicket)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            var ticketInfo = new
            {
                FirstName = firstName,
                LastName = lastName,
                Platform = trainTicket.Platform,
                Departure = trainTicket.Origin,
                Date = trainTicket.DepartureTime.ToShortDateString(),
                Time = trainTicket.DepartureTime.ToShortTimeString(),
                Seat = trainTicket.SeatNumber,
                Compartment = trainTicket.CompartmentNumber
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
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            var letterInfo = new
            {
                FirstName = firstName,
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

        public async Task SendInvitationMailAsync(User sender, string firstName, string lastName, string emailAddress,
                                       ActivationCode activationCode)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Admin);

            firstName = char.ToUpper(firstName[0]) + firstName[1..];
            lastName = char.ToUpper(lastName[0]) + lastName[1..];

            string acceptLetterLink = GenerateAcceptLetterLink(firstName, lastName, sender.FullName, activationCode);
            TrainTicket trainTicket = await _trainService.GetTicketForNewStudentAsync(activationCode);
            string trainTicketLink = GenerateTrainTicketLink(firstName, lastName, trainTicket);

            string emailSubject = $"Hogwarts Acceptance Letter for {firstName} {lastName}";
            string emailBody = "Dear " + firstName + ",<br><br>" +
                    "We are pleased to inform you that you have been accepted into Hogwarts School of Witchcraft and Wizardry! " +
                    "You have demonstrated exceptional magical ability and we are excited to welcome you as a new student.<br><br>" +
                    "We look forward to meeting you and helping you develop your magical talents. " +
                    "If you have any questions or concerns, please do not hesitate to contact us.<br><br>";

            string emailFooter = "Congratulations once again on your acceptance to Hogwarts!<br><br>" +
                    "Sincerely,<br><br>" +
                     sender.FullName + "<br>" +
                    "Headmaster/Headmistress";

            string fullEmail =
                "<html><body>" +
                emailBody + "<br>" +
                acceptLetterLink +
                trainTicketLink +
                emailFooter +

                "</body></html>";


            await StaticMailService.SendEmailAsync(recipient: emailAddress, subject: emailSubject, body: fullEmail);
        }

        public async Task SendTrainTicketAsync(TrainTicket trainTicket, User owner)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            string emailSubject = $"Hogwarts Express Ticket for {owner.FirstName} {owner.LastName}";
            string emailBody = GenerateTrainTicketLink(owner.FirstName, owner.LastName, trainTicket);

            await StaticMailService.SendEmailAsync(recipient: owner.Email, subject: emailSubject, body: emailBody);
        }
    }
}
