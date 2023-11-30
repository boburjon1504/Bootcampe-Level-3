using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Domain.Common.Exceptions;

namespace N73HomeTask.Application.Common.Notifications.Service;

public interface ISmsOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        SmsNotificationRequest request,
        CancellationToken cancellationToken = default
    );
}