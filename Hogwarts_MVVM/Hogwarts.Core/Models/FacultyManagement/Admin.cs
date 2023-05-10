using Hogwarts.Core.Data;
using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.StudentManagement;
using Hogwarts.Core.Models.TrainManagement;
using Hogwarts.Core.Models.TrainManagement.Services;
using Hogwarts.Core.SharedServices;
using System;
using System.Text.RegularExpressions;

namespace Hogwarts.Core.Models.FacultyManagement
{
    public sealed class Admin : User
    {
        public Admin()
            : base()
        {

        }
        public Admin(string username, string firstName, string lastName, string email, DateOnly birthDay,
                     BloodType bloodType, AccessLevel accessLeve, string passwordHash)
            : base(username, firstName, lastName, email, birthDay, bloodType, accessLeve, passwordHash)
        {
        }
        public Admin(AdminRegistrationDTO DTO, string passwordHash)
            : base(DTO, passwordHash)
        {
        }
        /*
        public static void EnrollStudent(string firstName, string lastName, string username, string email)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("Invalid input!");

            if (username.Length < 6)
                throw new ArgumentOutOfRangeException("Username must be at least 6 characters");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))      // <username>@<HOGWARTS_API_DOMAIN>.<tld>
            {
                throw new ArgumentException("Invalid Email");
            }

            ActivationCode activationCode = new(username);
            using (HogwartsDbContext dbContext = new())
            {
                dbContext.ActivationCodes.Add(activationCode);
                dbContext.SaveChanges();

                dbContext.Trains.Add(new Train(new DateTime(DateTime.Now.Year, 9, 1), "London", "Hogwarts", 10, 10));
                dbContext.SaveChanges();
                dynamic trainSeat = TrainService.GetNearestTrainTicket()

                //string acceptLetter = LetterService.GenerateAcceptLetter(firstName, lastName, headmasterName: _dbContext.LoggedInUser.FullName, activationCode);
                string acceptLetter = LetterService.GenerateAcceptLetter(firstName, lastName, headmasterName: "Albus, Dumbeldore", activationCode);
                string trainTicket = LetterService.GenerateTrainTicket(firstName, lastName, trainSeat);


                string emailSubject = $"Hogwarts Acceptance Letter for Mr/Miss {firstName} {lastName}";
                string emailBody =
                    "<html><body>" +
                    acceptLetter +
                    trainTicket +
                    "</body></html>";

                try
                {
                    MailService.SendEmail(recipient: email, subject: emailSubject, body: emailBody);
                }
                catch (NetworkConnectionException ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }*/
    }
}
