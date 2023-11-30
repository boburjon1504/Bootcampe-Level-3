using System.Linq.Expressions;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Persistense.Repostitories.Interfaces;

public interface IEmailHistoryRepository
{
    IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>>? predicate = default,
        bool asNoTracking = false
    );

    ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}