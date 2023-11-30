using FluentValidation;
using N73HomeTask.Application.Common.Identity.Services;
using N73HomeTask.Application.Common.Notifications.Models;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Infrastructure.Common.Validators;

public class NotificationRequestValidator : AbstractValidator<NotificationRequest>
{
    public NotificationRequestValidator(IUserService userService)
    {
        var templatesRequireSender = new List<NotificationTemplateType>
        {
            NotificationTemplateType.Welcoming,
            NotificationTemplateType.EmailAddressVerification,
            NotificationTemplateType.PhoneNumberVerification,
            NotificationTemplateType.Referral
        };

        RuleFor(request => request.SenderUserId)
            .NotEqual(Guid.Empty)
            .NotNull()
            .When(request => templatesRequireSender.Contains(request.TemplateType))
            .CustomAsync(async (senderUserId, context, cancellationToken) =>
            {
                var user = await userService.GetByIdAsync(senderUserId!.Value, true, cancellationToken);

                if (user is null)
                    context.AddFailure("Sender user not found");
            });

        RuleFor(request => request.ReceiverUserId)
            .NotEqual(Guid.Empty)
            .CustomAsync(async (senderUserId, context, cancellationToken) =>
            {
                var user = await userService.GetByIdAsync(senderUserId, true, cancellationToken);

                if (user is null)
                    context.AddFailure("Sender user not found");
            });
    }
}