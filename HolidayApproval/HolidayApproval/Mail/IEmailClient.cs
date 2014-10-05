namespace HolidayApproval.Mail
{
    public interface IEmailClient
    {
        void Send(string sender, string recipient, string subject, string body);
    }
}
