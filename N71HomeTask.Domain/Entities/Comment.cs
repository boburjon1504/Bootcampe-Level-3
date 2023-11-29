using N71HomeTask.Domain.Common;

namespace N71HomeTask.Domain.Entities;

public class Comment : IEntity
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public Guid ParentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}