using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Multilingual.Services;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        
        var fromMail = config.GetValue<string>("EmailSenderData:EmailAddress");
        var fromPassword = config.GetValue<string>("EmailSenderData:ApplicationPassword");

        var message = new MailMessage();
        message.From = new MailAddress(fromMail!);
        message.Subject = subject;
        message.To.Add(new MailAddress(email));
        message.Body = htmlMessage;
        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient(config.GetValue<string>("EmailSenderData:SmtpClientHost"));
        smtpClient.Port = config.GetValue<int>("EmailSenderData:SmtpClientPort");
        smtpClient.Credentials = new NetworkCredential(fromMail, fromPassword);
        smtpClient.EnableSsl = true;
        return smtpClient.SendMailAsync(message);
    }
}