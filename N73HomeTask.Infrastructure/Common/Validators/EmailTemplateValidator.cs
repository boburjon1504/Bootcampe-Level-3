using FluentValidation;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Infrastructure.Common.Validators;

public class EmailTemplateValidator : AbstractValidator<EmailTemplate>
{
    public EmailTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(256);

        RuleFor(template => template.Type)
            .Equal(NotificationType.Email);
    }
}