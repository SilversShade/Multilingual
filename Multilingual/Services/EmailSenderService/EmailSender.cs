using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Multilingual.Services.EmailSenderService;

public class EmailSender : IEmailSender
{
    private readonly IEmailMessageFormatter _emailMessageFormatter;

    private readonly ISmtpClientConfigurator _smtpClientConfigurator;

    private readonly IConfiguration _configuration;
    public EmailSender(
        IEmailMessageFormatter emailMessageFormatter,
        ISmtpClientConfigurator smtpClientConfigurator,
        IConfiguration configuration)
    {
        _emailMessageFormatter = emailMessageFormatter;
        _smtpClientConfigurator = smtpClientConfigurator;
        _configuration = configuration;
    }
    
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var emailConfig = _configuration.GetSection("EmailSenderData").Get<EmailSenderSettings>();

        var message = _emailMessageFormatter.FormatMessage(emailConfig!.EmailAddress, email, subject, htmlMessage, mailMessage =>
        {
            mailMessage.IsBodyHtml = true;
        });
        
        var smtpClient = _smtpClientConfigurator.ConfigureSmtpClient(emailConfig.SmtpClientHost,
            emailConfig.SmtpClientPort,
            new NetworkCredential(emailConfig.EmailAddress, emailConfig.EmailPassword),
            client =>
            {
                client.EnableSsl = true;
            });
        
        return smtpClient.SendMailAsync(message);
    }
}