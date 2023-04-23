using System.Configuration;
using System.Net;
using System.Net.Mail;

public static class EmailSender
{
    public static void SendEmail(string recipient, string subject, string body)
    {
        string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
        int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
        string smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
        string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];

        using (var client = new SmtpClient(smtpServer, smtpPort))
        {
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            client.EnableSsl = true;

            var message = new MailMessage();
            message.To.Add(new MailAddress(recipient));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            client.Send(message);
        }
    }
}
