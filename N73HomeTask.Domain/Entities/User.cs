using N73HomeTask.Domain.Common.Entities;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public RoleType Role { get; set; }

    public UserSettings UserSettings { get; set; }
}