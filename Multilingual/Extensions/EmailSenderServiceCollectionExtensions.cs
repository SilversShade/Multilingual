using Microsoft.AspNetCore.Identity.UI.Services;
using Multilingual.Services;
using Multilingual.Services.EmailSenderService;

namespace Multilingual.Extensions;

public static class EmailSenderServiceCollectionExtensions
{
    public static IServiceCollection AddEmailSender(this IServiceCollection services)
    {
        services.AddSingleton<IEmailMessageFormatter, EmailMessageFormatter>();
        services.AddSingleton<ISmtpClientConfigurator, SmtpClientConfigurator>();
        services.AddSingleton<IEmailSender, EmailSender>();
        return services;
    }
}