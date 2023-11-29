using N71HomeTask.Domain.Entities;

namespace N71HomeTask.Application.Sevices;

public interface ICommentService
{
    IQueryable<Comment> Get(Func<Comment, bool> predicate, bool asNoTracking = false);
    ValueTask<Comment?> GetById(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}