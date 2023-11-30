using System.Linq.Expressions;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Persistense.Repostitories.Interfaces;

public interface ISmsTemplateRepository
{
    IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}