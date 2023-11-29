using N71HomeTask.Domain.Entities;
using N71HomeTask.Persistense.DataAccess;

namespace N71HomeTask.Persistense.Repositories.CommentRepositores;

public class CommentRepository(AppDbContext context) : EntityRepositoryBase<Comment,AppDbContext>(context),
    ICommentRepository
{
    public IQueryable<Comment> Get(Func<Comment, bool> predicate, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<Comment?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(comment, saveChanges, cancellationToken);
    }

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(comment, saveChanges, cancellationToken);
    }

    public ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(comment, saveChanges, cancellationToken);
    }
}