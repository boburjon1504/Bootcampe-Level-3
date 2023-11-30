using N73HomeTask.Application.Common.Notifications.Models;

namespace N73HomeTask.Application.Common.Notifications.Service;

public interface ISmsSenderService
{
    ValueTask<bool> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default);
}