using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        Type = NotificationType.Email;
    }
    public string Subject { get; set; } = default!;
}