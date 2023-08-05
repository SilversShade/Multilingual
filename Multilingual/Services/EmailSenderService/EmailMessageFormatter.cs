using System.Net.Mail;

namespace Multilingual.Services.EmailSenderService;

public class EmailMessageFormatter : IEmailMessageFormatter
{
    public MailMessage FormatMessage(string fromMail, string toMail, string subject, string messageBody, Action<MailMessage> config)
    {
        var message = new MailMessage();
        message.From = new MailAddress(fromMail!);
        message.Subject = subject;
        message.To.Add(new MailAddress(toMail));
        message.Body = messageBody;
        config(message);
        return message;
    }
}