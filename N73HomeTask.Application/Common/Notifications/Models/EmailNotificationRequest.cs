using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Application.Common.Notifications.Models;

public class EmailNotificationRequest : NotificationRequest
{
    public EmailNotificationRequest()
    {
        Type = NotificationType.Email;
    }
}