namespace HolidayApproval.Mail
{
    public class EmailClientMock : IEmailClient
    {
        public Email SentEmail;

        public void Send(string sender, string recipient, string subject, string body)
        {
            SentEmail = new Email
            {
                Sender = sender,
                Recipient = recipient,
                Subject = subject,
                Body = body
            };
        }
    }
}
