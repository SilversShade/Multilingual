using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Multilingual.Services.EmailSenderService;

public class EmailSender : IEmailSender
{
    private readonly IEmailMessageFormatter _emailMessageFormatter;

    private readonly ISmtpClientConfigurator _smtpClientConfigurator;
    public EmailSender(IEmailMessageFormatter emailMessageFormatter, ISmtpClientConfigurator smtpClientConfigurator)
    {
        _emailMessageFormatter = emailMessageFormatter;
        _smtpClientConfigurator = smtpClientConfigurator;
    }
    
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
        var fromMail = config.GetValue<string>("EmailSenderData:EmailAddress");

        var message = _emailMessageFormatter.FormatMessage(fromMail!, email, subject, htmlMessage, mailMessage =>
        {
            mailMessage.IsBodyHtml = true;
        });

        var smtpHost = config.GetValue<string>("EmailSenderData:SmtpClientHost");
        var smtpPort = config.GetValue<int>("EmailSenderData:SmtpClientPort");
        var password = config.GetValue<string>("EmailSenderData:ApplicationPassword");

        var smtpClient = _smtpClientConfigurator.ConfigureSmtpClient(smtpHost!, smtpPort,
            new NetworkCredential(fromMail, password),
            client =>
            {
                client.EnableSsl = true;
            });
        
        return smtpClient.SendMailAsync(message);
    }
}