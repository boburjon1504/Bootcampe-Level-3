using AutoMapper;
using Microsoft.Extensions.Options;
using N73HomeTask.Application.Common.Identity.Services;
using N73HomeTask.Application.Common.Models.Querying;
using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Application.Common.Notifications.Service;
using N73HomeTask.Domain.Common.Exceptions;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Enums;
using N73HomeTask.Domain.Extensions;
using N73HomeTask.Infrastructure.Common.Settings;

namespace N73HomeTask.Infrastructure.Common.Notifications.Services;

public class NotificationAggregationService(IMapper mapper,
    IOptions<NotificationSettings> notificationSettings,
    //ISmsTemplateService smsTemplateService,
    IEmailTemplateService emailTemplateService,
    //ISmsOrchestrationService smsOrchestrationService,
    IEmailOrchestrationService emailOrchestrationService,
    IUserSettingsService userSettingsService,
    IUserService userService) : INotificationAggregationService
{
    public async ValueTask<FuncResult<bool>> SendAsync(
    NotificationRequest notificationRequest,
    CancellationToken cancellationToken = default
)
{
    var sendNotificationTask = async () =>
    {
        var senderUser = notificationRequest.SenderUserId.HasValue
            ? await userService.GetByIdAsync(notificationRequest.SenderUserId.Value,
                cancellationToken: cancellationToken)
            : await userService.GetSystemUserAsync(true, cancellationToken);

        notificationRequest.SenderUserId = senderUser!.Id;

        var receiverUser = await userService.GetByIdAsync(notificationRequest.ReceiverUserId,
            cancellationToken: cancellationToken);

        if (!notificationRequest.Type.HasValue && receiverUser!.UserSettings.PreferredNotificationType.HasValue)
            notificationRequest.Type = receiverUser!.UserSettings.PreferredNotificationType!.Value;

        if (!notificationRequest.Type.HasValue)
            notificationRequest.Type = notificationSettings.Value.DefaultNotificationType;

        var sendNotificationTask = notificationRequest.Type switch
        {
            // NotificationType.Sms => smsOrchestrationService.SendAsync(
            //     mapper.Map<SmsNotificationRequest>(notificationRequest),
            //     cancellationToken),
            NotificationType.Email => emailOrchestrationService.SendAsync(
                mapper.Map<EmailNotificationRequest>(notificationRequest),
                cancellationToken),
            _ => throw new NotImplementedException("This type of notification is not supported yet.")
        };

        var sendNotificationResult = await sendNotificationTask;
        return sendNotificationResult.Data;
    };

    return await sendNotificationTask.GetValuesAsync();
}

public async ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
    NotificationTemplateFilter filter,
    CancellationToken cancellationToken = default
)
{
    var templates = new List<NotificationTemplate>();

    // if (filter.TemplateType.Contains(NotificationType.Sms))
    //     templates.AddRange(
    //         await smsTemplateService.GetByFilterAsync(filter, cancellationToken: cancellationToken));

    if (filter.TemplateType.Contains(NotificationType.Email))
        templates.AddRange(
            await emailTemplateService.GetByFilterAsync(filter, cancellationToken: cancellationToken));

    return templates;
}
}