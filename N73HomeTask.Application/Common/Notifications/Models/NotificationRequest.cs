﻿using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Application.Common.Notifications.Models;

public class NotificationRequest
{
    public Guid? SenderUserId { get; set; } = null;
 
    public Guid ReceiverUserId { get; set; }

    public NotificationTemplateType TemplateType { get; set; }

    public NotificationType? Type { get; set; } = null;

    public Dictionary<string, string>? Variables { get; set; }
}