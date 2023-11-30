using System.Linq.Expressions;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Persistense.Repostitories.Interfaces;

public interface ISmsHistoryRepository
{
    IQueryable<SmsHistory> Get(
        Expression<Func<SmsHistory, bool>>? predicate = default,
        bool asNoTracking = false
    );

    ValueTask<SmsHistory> CreateAsync(
        SmsHistory smsHistory,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}