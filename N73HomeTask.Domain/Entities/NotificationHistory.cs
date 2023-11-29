using N73HomeTask.Domain.Common.Entities;

namespace N73HomeTask.Domain.Entities;

public class NotificationHistory : IEntity
{
    public Guid Id { get; set; }
    public Guid TemplateId { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid ReceiverUserId { get; set; }
        
}