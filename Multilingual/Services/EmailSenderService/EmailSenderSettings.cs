namespace Multilingual.Services.EmailSenderService;

public class EmailSenderSettings
{
    public string EmailAddress { get; set; }

    public string EmailPassword { get; set; }
    
    public string SmtpClientHost { get; set; }

    public int SmtpClientPort { get; set; }
}