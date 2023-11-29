using N70HomeTask.Domain.Common;

namespace N70HomeTask.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = new Role();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}