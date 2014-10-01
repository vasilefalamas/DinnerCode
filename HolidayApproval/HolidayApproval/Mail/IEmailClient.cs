namespace HolidayApproval.Mail
{
    public interface IEmailClient
    {
        /// <summary>
        /// Sends an email.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="recipient">The recipient.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        void Send(string sender, string recipient, string subject, string body);
    }
}
