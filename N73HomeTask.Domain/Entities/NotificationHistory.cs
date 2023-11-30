using N73HomeTask.Domain.Common.Entities;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Domain.Entities;

public class NotificationHistory : IEntity
{
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid ReceiverUserId { get; set; }
    public NotificationType Type { get; set; }
    public string Content { get; set; } = default!;
    public bool IsSuccessFull { get; set; }
    public string? ErrorMessage { get; set; }
    public NotificationTemplate Template { get; set; }

}