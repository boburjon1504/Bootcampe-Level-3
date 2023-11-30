using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Application.Common.Models.Querying;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}