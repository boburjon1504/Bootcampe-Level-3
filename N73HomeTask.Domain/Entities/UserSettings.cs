using N73HomeTask.Domain.Common.Entities;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Domain.Entities;

public class UserSettings : IEntity
{
    /// <summary>
    /// Gets or sets the user Id
    /// </summary>
    public Guid Id { get; set; }

    public NotificationType? PreferredNotificationType { get; set; }
}