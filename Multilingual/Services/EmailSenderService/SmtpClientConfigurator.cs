using System.Net;
using System.Net.Mail;

namespace Multilingual.Services.EmailSenderService;

public class SmtpClientConfigurator : ISmtpClientConfigurator
{
    public SmtpClient ConfigureSmtpClient(string host, int port, NetworkCredential credential, Action<SmtpClient> config)
    {
        var smtpClient = new SmtpClient(host);
        smtpClient.Port = port;
        smtpClient.Credentials = credential;
        config(smtpClient);
        return smtpClient;
    }
}