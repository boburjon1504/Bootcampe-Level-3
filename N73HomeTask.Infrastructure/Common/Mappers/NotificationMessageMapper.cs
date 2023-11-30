using AutoMapper;
using N73HomeTask.Application.Common.Notifications.Models;

namespace N73HomeTask.Infrastructure.Common.Mappers;

public class NotificationMessageMapper : Profile
{
    public NotificationMessageMapper()
    {
        CreateMap<EmailNotificationRequest, EmailMessage>();
        CreateMap<EmailNotificationRequest, SmsMessage>();
    }
}