using System.Net.Mail;

namespace HolidayApproval.Mail
{
    public class EmailClient : IEmailClient
    {
        private readonly SmtpClient smtpClient;

        public EmailClient(SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
        }

        public void Send(string from, string recipient, string subject, string body)
        {
            smtpClient.Send(from, recipient, subject, body);
        }
    }
}
