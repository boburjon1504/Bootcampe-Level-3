using N71HomeTask.Application.Sevices;
using N71HomeTask.Domain.Entities;
using N71HomeTask.Persistense.Repositories.CommentRepositores;

namespace N71HomeTask.Infrastructure.Services;

public class CommentService(ICommentRepository commentRepository) : ICommentService
{
    public IQueryable<Comment> Get(Func<Comment, bool> predicate, bool asNoTracking = false)
    {
        return commentRepository.Get(comment => true,asNoTracking);
    }

    public ValueTask<Comment?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return commentRepository.GetById(id, asNoTracking, cancellationToken);
    }

    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return commentRepository.CreateAsync(comment, saveChanges, cancellationToken);
    }

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return commentRepository.UpdateAsync(comment, saveChanges, cancellationToken);
    }

    public ValueTask<Comment> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return commentRepository.DeleteAsync(comment, saveChanges, cancellationToken);
    }
}