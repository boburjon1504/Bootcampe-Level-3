using System.Linq.Expressions;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Persistense.DataAccess;
using N73HomeTask.Persistense.Repostitories;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Persistense.Repostitories;

public class SmsTemplateRepository(NotificationDbContext context) : 
    EntityRepositoryBase<SmsTemplate,NotificationDbContext>(context),ISmsTemplateRepository
{
    public IQueryable<SmsTemplate> Get(
        Expression<Func<SmsTemplate, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        base.Get(predicate, asNoTracking);

    public ValueTask<SmsTemplate> CreateAsync(
        SmsTemplate smsTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    ) =>
        base.CreateAsync(smsTemplate, saveChanges, cancellationToken);
}