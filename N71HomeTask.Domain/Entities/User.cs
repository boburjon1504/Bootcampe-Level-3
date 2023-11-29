using N71HomeTask.Domain.Common;

namespace N71HomeTask.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}