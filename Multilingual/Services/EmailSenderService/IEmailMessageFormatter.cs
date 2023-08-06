using System.Net.Mail;

namespace Multilingual.Services.EmailSenderService;

public interface IEmailMessageFormatter
{
    public MailMessage FormatMessage(string fromMail, string toMail, string subject, string messageBody, Action<MailMessage>? config = null);
}