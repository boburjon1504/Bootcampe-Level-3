using N73HomeTask.Application.Common.Models.Querying;
using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Domain.Common.Exceptions;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Application.Common.Notifications.Service;

public interface ISmsHistoryService
{
    ValueTask<FuncResult<bool>> SendAsync(
        NotificationRequest notificationRequest,
        CancellationToken cancellationToken = default
    );

    ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default
    );
}