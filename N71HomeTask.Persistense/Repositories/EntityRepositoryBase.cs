using Microsoft.EntityFrameworkCore;
using N71HomeTask.Domain.Common;

namespace N71HomeTask.Persistense.Repositories;


public abstract class EntityRepositoryBase<TEntity,TContext>(TContext context) 
    where TEntity: class,IEntity where TContext : DbContext
{
    protected TContext DbContext => context;

    protected IQueryable<TEntity> Get(Func<TEntity, bool>? predicate,bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>();

        if (asNoTracking)
            initialQuery.AsNoTracking();

        if (predicate is null)
            return initialQuery;

        return initialQuery.Where(predicate).AsQueryable();
    }

    protected async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>();

        if (asNoTracking)
            initialQuery.AsNoTracking();

        return await initialQuery.SingleOrDefaultAsync(enity => enity.Id == id, cancellationToken);
    }
    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddAsync(entity,cancellationToken);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Update(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
    protected async ValueTask<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}