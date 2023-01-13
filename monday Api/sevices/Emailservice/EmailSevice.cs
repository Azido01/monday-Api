using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace monday_Api.sevices.Emailservice
{
    public class EmailSevice : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailSevice(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Credentials:EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("Credentials:EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("Credentials:EmailUsername").Value, _config.GetSection("Credentials:EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
