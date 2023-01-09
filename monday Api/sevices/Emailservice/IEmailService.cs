using monday_Api.Models;

namespace monday_Api.sevices.Emailservice
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
