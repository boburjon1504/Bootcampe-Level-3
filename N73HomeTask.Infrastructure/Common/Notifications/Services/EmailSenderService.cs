using FluentValidation;
using N73HomeTask.Application.Common.Notifications.Brokers;
using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Application.Common.Notifications.Service;
using N73HomeTask.Domain.Enums;
using N73HomeTask.Domain.Extensions;

namespace N73HomeTask.Infrastructure.Common.Notifications.Services;

public class EmailSenderService(IEnumerable<IEmailSenderBroker> emailSenderBrokers,
    IValidator<EmailMessage> emailMessageValidator) : IEmailSenderService
{
    public async ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        var validationResult = emailMessageValidator.Validate(emailMessage,
            options => options.IncludeRuleSets(NotificationEvent.OnSending.ToString()));
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        foreach (var smsSenderBroker in emailSenderBrokers)
        {
            var sendNotificationTask = () => smsSenderBroker.SendAsync(emailMessage, cancellationToken);
            var result = await sendNotificationTask.GetValuesAsync();

            emailMessage.IsSuccessful = result.IsSuccess;
            emailMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}