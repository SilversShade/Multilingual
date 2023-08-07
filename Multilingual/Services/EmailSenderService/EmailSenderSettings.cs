namespace Multilingual.Services.EmailSenderService;

public class EmailSenderSettings
{
    public string EmailAddress { get; set; } = null!;

    public string EmailPassword { get; set; } = null!;

    public string SmtpClientHost { get; set; } = null!;

    public int SmtpClientPort { get; set; }
}