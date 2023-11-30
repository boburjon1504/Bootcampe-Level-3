using AutoMapper;
using N73HomeTask.Application.Common.Notifications.Models;

namespace N73HomeTask.Infrastructure.Common.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<NotificationRequest, EmailMessage>();
        CreateMap<NotificationRequest, SmsMessage>();
    }
}