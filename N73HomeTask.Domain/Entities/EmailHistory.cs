﻿using System.ComponentModel.DataAnnotations.Schema;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Domain.Entities;

public class EmailHistory : NotificationHistory
{ 
    public EmailHistory()
    {
        Type = NotificationType.Email;
    }

    public string SenderEmailAddress { get; set; } = default!;
    public string ReceiverEmailAddress { get; set; } = default!;
    public string Subject { get; set; } = default!;

    [NotMapped]
    public EmailTemplate EmailTemplate
    {
        get => Template is not null ? Template as EmailTemplate : null;
        set => Template = value;
    }
}