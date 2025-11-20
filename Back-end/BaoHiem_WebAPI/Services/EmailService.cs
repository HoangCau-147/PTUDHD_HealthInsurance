using Entity.Email;
using MimeKit;
using MailKit.Net.Smtp;
using Service.Contracts;

namespace Services
{
    public class EmailService : IEmailService
    {
        private EmailConfiguration _configuration;
        public EmailService(EmailConfiguration configuration) => _configuration = configuration;
        public void SendEmail(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration.DisplayName, _configuration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }
        private void Send(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.SmtpServer, _configuration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    client.Authenticate(_configuration.Username, _configuration.Password);
                    client.Send(message);
                }
                catch {
                    throw;
                }
                finally
                {
                    client.Dispose();
                }
            }
        }
    }
}
