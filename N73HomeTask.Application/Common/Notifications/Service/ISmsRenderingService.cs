using N73HomeTask.Application.Common.Notifications.Models;

namespace N73HomeTask.Application.Common.Notifications.Service;

public interface ISmsRenderingService
{
    ValueTask<string> RenderAsync(
        SmsMessage smsMessage,
        CancellationToken cancellationToken = default
    );
}