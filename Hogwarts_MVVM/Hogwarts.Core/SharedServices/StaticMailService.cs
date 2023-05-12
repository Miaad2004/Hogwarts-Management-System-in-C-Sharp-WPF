using Hogwarts.Core.SharedServices.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Hogwarts.Core.SharedServices
{
    public static class StaticMailService
    {
        private static bool IsConnectedToInternet()
        {
            try
            {
                using WebClient client = new();
                using Stream stream = client.OpenRead("http://google.com/generate_204");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SendEmail(string recipient, string subject, string body)
        {
            if (!IsConnectedToInternet())
            {
                throw new NetworkConnectionException("No internet connection available.");
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string smtpServer = configuration["appSettings:SmtpServer"] ?? throw new ConfigurationErrorsException("Invalid Configuration");
            string smtpUsername = configuration["appSettings:SmtpUsername"] ?? throw new ConfigurationErrorsException("Invalid Configuration");
            int smtpPort = int.Parse(configuration["appSettings:SmtpPort"] ?? "587");
            string smtpPassword;
#if DEBUG
            smtpPassword = File.ReadAllText(@"D:\smtp_password.txt");
#else
            smtpPassword = configuration["appSettings:SmtpPassword"] ?? throw new ConfigurationErrorsException("Invalid Configuration");
#endif

            using SmtpClient client = new(smtpServer, smtpPort);
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            client.EnableSsl = true;

            MailMessage message = new()
            {
                From = new MailAddress(smtpUsername),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress(recipient));

            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                throw new Exception("Failed to send email. " + ex.Message);
            }
        }
    }
}
