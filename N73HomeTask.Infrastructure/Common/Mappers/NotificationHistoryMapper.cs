using AutoMapper;
using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Infrastructure.Common.Mappers;

public class NotificationHistoryMapper : Profile
{
    public NotificationHistoryMapper()
    {
        CreateMap<EmailMessage, EmailHistory>()
            .ForMember(dest => dest.TemplateId,
                opt =>
                    opt.MapFrom(src => src.Template.Id))
            .ForMember(dest=>dest.Content,
                opt=>
                    opt.MapFrom(src=>src.Body));

        CreateMap<SmsMessage, SmsHistory>()
            .ForMember(dest => dest.TemplateId,
                opt =>
                    opt.MapFrom(src => src.Template.Id))
            .ForMember(dest => dest.Content,
                opt =>
                    opt.MapFrom(src => src.Message));

    }
}