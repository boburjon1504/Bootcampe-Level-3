using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Application.Common.Notifications.Models;

public class SmsNotificationRequest : NotificationRequest
{
    public SmsNotificationRequest()
    {
        Type = NotificationType.Sms;
    }
}