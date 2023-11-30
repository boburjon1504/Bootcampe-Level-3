using N73HomeTask.Application.Common.Notifications.Models;

namespace N73HomeTask.Application.Common.Notifications.Service;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}