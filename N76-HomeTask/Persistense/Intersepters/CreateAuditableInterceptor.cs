using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using N76_HomeTask.Domain.Common;

namespace N76_HomeTask.Persistense.Intersepters;

public class CreateAuditableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var creatingEntities = eventData.Context.ChangeTracker.Entries<IAuditable>().ToList();
        var deletingEntities = eventData.Context.ChangeTracker.Entries<ISoftDeleted>().ToList();


        creatingEntities.ForEach(entity =>
        {
            if (entity.State == EntityState.Added)
                entity.Property(nameof(IAuditable.CreatedDate)).CurrentValue = DateTime.UtcNow;
            if (entity.State == EntityState.Modified)
                entity.Property(nameof(IAuditable.UpdatedDate)).CurrentValue = DateTime.UtcNow;
        });

        deletingEntities.ForEach(entity =>
        {
            if (entity.State == EntityState.Deleted)
            {
                entity.Property(nameof(ISoftDeleted.DeletedDate)).CurrentValue = DateTime.UtcNow;
                entity.Property(nameof(ISoftDeleted.IsDeleted)).CurrentValue = true;
                entity.State = EntityState.Modified;
            }
        });
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}