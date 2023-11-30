using System.Linq.Expressions;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Persistense.DataAccess;
using N73HomeTask.Persistense.Repostitories.Interfaces;

namespace N73HomeTask.Persistense.Repostitories;

public class EmailTemplateRepository(NotificationDbContext context) : 
    EntityRepositoryBase<EmailTemplate,NotificationDbContext>(context),IEmailTemplateRepository
{
    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false
    ) =>
        base.Get(predicate, asNoTracking);

    public ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    ) =>
        base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
}