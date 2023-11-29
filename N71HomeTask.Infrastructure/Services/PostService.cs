using N71HomeTask.Application.Sevices;
using N71HomeTask.Domain.Entities;
using N71HomeTask.Persistense.Repositories.PostRepositories;

namespace N71HomeTask.Infrastructure.Services;

public class PostService(IPostRepository postRepository) : IPostService
{
    public IQueryable<Post> Get(Func<Post, bool> predicate, bool asNoTracking = false)
    {
        return postRepository.Get(post => true,asNoTracking);
    }

    public ValueTask<Post?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return postRepository.GetById(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Post> CreateAsync(Post post, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return postRepository.CreateAsync(post, saveChanges, cancellationToken);
    }

    public ValueTask<Post> UpdateAsync(Post post, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return postRepository.UpdateAsync(post, saveChanges, cancellationToken);
    }

    public ValueTask<Post> DeleteAsync(Post post, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return postRepository.DeleteAsync(post, saveChanges, cancellationToken);
    }
}