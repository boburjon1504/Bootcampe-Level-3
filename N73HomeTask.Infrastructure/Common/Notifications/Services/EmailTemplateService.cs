using System.Linq.Expressions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using N73HomeTask.Application.Common.Models.Querying;
using N73HomeTask.Application.Common.Notifications.Service;
using N73HomeTask.Application.Common.Query.Extensions;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Enums;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Infrastructure.Common.Notifications.Services;

public class EmailTemplateService(IEmailTemplateRepository emailTemplateRepository,
    IValidator<EmailTemplate> emailTemplateValidator) : IEmailTemplateService
{
    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        emailTemplateRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await Get(asNoTracking: asNoTracking)
            .ApplyPagination(paginationOptions)
            .ToListAsync(cancellationToken: cancellationToken);

    public async ValueTask<EmailTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await emailTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
            .SingleOrDefaultAsync(cancellationToken);

    public ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = emailTemplateValidator.Validate(emailTemplate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return emailTemplateRepository.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }
}