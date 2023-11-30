using AutoMapper;
using FluentValidation;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Infrastructure.Common.Validators;

public class SmsHistoryValidator : AbstractValidator<SmsHistory>
{
    public SmsHistoryValidator()
    {
        RuleSet(EntityEvent.OnCreating.ToString(),
            () =>
            {
                RuleFor(history => history.TemplateId).NotEqual(Guid.Empty);

                RuleFor(history => history.SenderUserId).NotEqual(Guid.Empty);

                RuleFor(history => history.ReceiverUserId).NotEqual(Guid.Empty);

                RuleFor(history => history.Content).NotEmpty().MaximumLength(129_536);

                RuleFor(history => history.ErrorMessage).NotNull().NotEmpty()
                    .When(history => !history.IsSuccessFull);

                RuleFor(history => history.SenderPhoneNumber).NotEmpty().MaximumLength(64);

                RuleFor(history => history.ReceiverPhoneNumber).NotEmpty().MaximumLength(64);
            });
    }
}