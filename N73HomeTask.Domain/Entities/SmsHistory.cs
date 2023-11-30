using System.ComponentModel.DataAnnotations.Schema;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Domain.Entities;

public class SmsHistory : NotificationHistory
{
    public SmsHistory()
    {
        Type = NotificationType.Sms;
    }

    public string SenderPhoneNumber { get; set; } = default!;
    public string ReceiverPhoneNumber { get; set; } = default!;

    [NotMapped]
    public SmsTemplate SmsTemplate
    {
        get => Template is not null ? Template as SmsTemplate : null;
        set => Template = value;
    }
}