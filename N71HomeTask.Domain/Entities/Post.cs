using N71HomeTask.Domain.Common;

namespace N71HomeTask.Domain.Entities;

public class Post : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public ICollection<Comment> Comments = new List<Comment>();
}