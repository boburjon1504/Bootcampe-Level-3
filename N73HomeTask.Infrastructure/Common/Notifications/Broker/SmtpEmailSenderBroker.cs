using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using N73HomeTask.Application.Common.Notifications.Brokers;
using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Infrastructure.Common.Settings;

namespace N73HomeTask.Infrastructure.Common.Notifications.Broker;

public class SmtpEmailSenderBroker(IOptions<SmtpEmailSenderSettings> setting) : IEmailSenderBroker
{
    private SmtpEmailSenderSettings _smtpEmailSenderSettings = setting.Value;
    
    public ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        emailMessage.SendEmailAddress ??= _smtpEmailSenderSettings.CredentialAddress;

        var mail = new MailMessage(emailMessage.SendEmailAddress, emailMessage.ReceiverEmailAddress);
        mail.Subject = emailMessage.Subject;
        mail.Body = emailMessage.Body;
        mail.IsBodyHtml = true;

        var smtpClient = new SmtpClient(_smtpEmailSenderSettings.Host, _smtpEmailSenderSettings.Port);
        smtpClient.Credentials =
            new NetworkCredential(_smtpEmailSenderSettings.CredentialAddress, _smtpEmailSenderSettings.Password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);

        return new ValueTask<bool>(true);
    }
}