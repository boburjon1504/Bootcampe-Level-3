using AutoMapper;
using N73HomeTask.Application.Common.Identity.Services;
using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Application.Common.Notifications.Service;
using N73HomeTask.Domain.Common.Exceptions;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Extensions;

namespace N73HomeTask.Infrastructure.Common.Notifications.Services;

public class EmailOrchestrationService(IMapper mapper,
    IEmailTemplateService emailTemplateService,
    IEmailRenderingService emailRenderingService,
    IEmailSenderService emailSenderService,
    IEmailHistoryService emailHistoryService,
    IUserService userService) : IEmailOrchestrationService
{
    public async ValueTask<FuncResult<bool>> SendAsync(EmailNotificationRequest request, 
        CancellationToken cancellationToken = default)
    {
        var sendNotificationRequest = async () =>
        {
            var message = mapper.Map<EmailMessage>(request);

            var senderUser = await userService
                .GetByIdAsync(message.SenderUserId, cancellationToken: cancellationToken);

            var receiverUser = await userService
                .GetByIdAsync(message.ReceiverUserId, cancellationToken: cancellationToken);

            message.SendEmailAddress = senderUser.EmailAddress;
            message.ReceiverEmailAddress = receiverUser.EmailAddress;

            message.Template =
                await emailTemplateService
                    .GetByTypeAsync(request.TemplateType, true, cancellationToken) ??
                throw new InvalidOperationException(
                    $"Invalid template for sending {request.TemplateType} notification");

            await emailRenderingService.RenderAsync(message, cancellationToken);

            await emailSenderService.SendAsync(message, cancellationToken);

            var history = mapper.Map<EmailHistory>(message);

            await emailHistoryService.CreateAsync(history, true, cancellationToken);

            return history.IsSuccessFull;

        };
        return await sendNotificationRequest.GetValuesAsync();
    }
}