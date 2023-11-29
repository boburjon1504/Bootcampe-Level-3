using N70HomeTask.Domain.Common;
using N70HomeTask.Domain.Enums;

namespace N70HomeTask.Domain.Entities;

public class Role : IEntity
{
    public Guid Id { get; set; }
    public UserRole RoleType { get; set; }
}