using System.Net;
using System.Net.Mail;

namespace Multilingual.Services.EmailSenderService;

public interface ISmtpClientConfigurator
{
    public SmtpClient ConfigureSmtpClient(string host, int port, NetworkCredential credential, Action<SmtpClient>? config = null);
}