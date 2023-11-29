using Microsoft.EntityFrameworkCore;
using N71HomeTask.Domain.Entities;
using N71HomeTask.Persistense.DataAccess;

namespace N71HomeTask.Persistense.Repositories.PostRepositories;



public class PostRepository(AppDbContext context) : EntityRepositoryBase<Post,AppDbContext>(context),
    IPostRepository
{
    public IQueryable<Post> Get(Func<Post, bool> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<Post?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Post> CreateAsync(Post post, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(post, saveChanges, cancellationToken);
    }

    public ValueTask<Post> UpdateAsync(Post post, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(post, saveChanges, cancellationToken);
    }

    public ValueTask<Post> DeleteAsync(Post post, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(post, saveChanges, cancellationToken);
    }
}