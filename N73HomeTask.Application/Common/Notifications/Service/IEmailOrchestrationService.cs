using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Domain.Common.Exceptions;

namespace N73HomeTask.Application.Common.Notifications.Service;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        EmailNotificationRequest request,
        CancellationToken cancellationToken = default
    );
}