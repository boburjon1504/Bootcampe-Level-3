using N73HomeTask.Application.Common.Notifications.Models;

namespace N73HomeTask.Application.Common.Notifications.Service;

public interface IEmailRenderingService
{
    ValueTask<string> RenderAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken = default
    );
}