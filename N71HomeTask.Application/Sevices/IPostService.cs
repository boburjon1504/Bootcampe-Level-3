using N71HomeTask.Domain.Entities;

namespace N71HomeTask.Application.Sevices;

public interface IPostService
{
    IQueryable<Post> Get(Func<Post, bool> predicate, bool asNoTracking = false);
    ValueTask<Post?> GetById(Guid id, bool asNoTracking = false,
        CancellationToken cancellationToken = default);
    ValueTask<Post> CreateAsync(Post post, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Post> UpdateAsync(Post post, bool saveChanges = true,
        CancellationToken cancellationToken = default);
    ValueTask<Post> DeleteAsync(Post post, bool saveChanges = true,
        CancellationToken cancellationToken = default);
}