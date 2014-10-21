using System.Net.Mail;

public class Email
{
    private string from;
    private string to;
    private string subject;
    private string message;

    public Email(string from, string to, string subject, string message)
    {
        this.from = from;
        this.to = to;
        this.subject = subject;
        this.message = message;
    }

    public void Send()
    {
        var client = new SmtpClient();

        client.Send(from, to, subject, message);
    }
}