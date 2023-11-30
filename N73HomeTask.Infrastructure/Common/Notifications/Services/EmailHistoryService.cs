using FluentValidation;
using Microsoft.EntityFrameworkCore;
using N73HomeTask.Application.Common.Models.Querying;
using N73HomeTask.Application.Common.Notifications.Service;
using N73HomeTask.Application.Common.Query.Extensions;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Enums;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Infrastructure.Common.Notifications.Services;

public class EmailHistoryService(IEmailHistoryRepository emailHistoryRepository
    ,IValidator<EmailHistory> validator) : IEmailHistoryService
{
    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(FilterPagination paginationOptions, 
        bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return await emailHistoryRepository.Get().ApplyPagination(paginationOptions).ToListAsync();
    }

    public async ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validation = await validator.ValidateAsync(emailHistory, options =>
            options.IncludeRuleSets(EntityEvent.OnCreating.ToString()),cancellationToken);

        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        return await emailHistoryRepository.CreateAsync(emailHistory, saveChanges, cancellationToken);
    }
}