using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Domain.Entities;

public class SmsTemplate : NotificationTemplate
{
    public SmsTemplate()
    {
        Type = NotificationType.Sms;
    }
}