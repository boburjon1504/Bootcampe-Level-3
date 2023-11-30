using N73HomeTask.Application.Common.Notifications.Models;

namespace N73HomeTask.Application.Common.Notifications.Brokers;

public interface ISmsSenderBroker
{
    ValueTask<bool> SendAsync(SmsMessage smsMessage,
        CancellationToken cancellationToken = default);
}