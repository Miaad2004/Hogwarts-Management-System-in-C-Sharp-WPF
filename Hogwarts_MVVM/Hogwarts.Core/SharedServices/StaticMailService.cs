using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.SharedServices.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Hogwarts.Core.SharedServices
{
    public static class StaticMailService
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        private static readonly string SmtpServer = configuration["appSettings:SmtpServer"] ?? throw new ConfigurationErrorsException("Invalid Configuration");
        private static readonly string SmtpUsername = configuration["appSettings:SmtpUsername"] ?? throw new ConfigurationErrorsException("Invalid Configuration");
        private static readonly int SmtpPort = int.Parse(configuration["appSettings:SmtpPort"] ?? "587");
#if DEBUG
        private static readonly string SmtpPassword = File.ReadAllText(@"D:\smtp_password.txt");
#else
            private static string SmtpPassword = configuration["appSettings:SmtpPassword"] ?? throw new ConfigurationErrorsException("Invalid Configuration");
#endif

        private static async Task<bool> IsConnectedToInternetAsync()
        {
            try
            {
                using HttpClient client = new()
                {
                    Timeout = TimeSpan.FromSeconds(5)
                };
                HttpResponseMessage response = await client.GetAsync("https://google.com");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static async Task SendEmailAsync(string recipient, string subject, string body)
        {
            SessionManager.AuthorizeMethodAccess(AccessLevels.Student);

            if (!await IsConnectedToInternetAsync())
            {
                throw new NetworkConnectionException("No internet connection available.");
            }

            using SmtpClient client = new(SmtpServer, SmtpPort);
            client.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
            client.EnableSsl = true;

            try
            {
                MailMessage mailMessage = new(SmtpUsername, recipient, subject, body)
                {
                    IsBodyHtml = true
                };
                await client.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                throw new EmailSendingException("Failed to send email.", ex);
            }
        }


    }
}
