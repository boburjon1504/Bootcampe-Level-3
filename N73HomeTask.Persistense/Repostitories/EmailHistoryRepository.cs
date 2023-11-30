using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Persistense.DataAccess;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Persistense.Repostitories;

public class EmailHistoryRepository(NotificationDbContext context) : 
    EntityRepositoryBase<EmailHistory,NotificationDbContext>(context),IEmailHistoryRepository
{
    public IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        base.Get(predicate, asNoTracking);

    public async ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        if (emailHistory.EmailTemplate is not null)
            DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Unchanged;

        var createdHistory = await base.CreateAsync(emailHistory, saveChanges, cancellationToken);

        if (emailHistory.EmailTemplate is not null)
            DbContext.Entry(emailHistory.EmailTemplate).State = EntityState.Detached;

        return createdHistory;
    }
}