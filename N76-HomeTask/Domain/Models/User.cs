using N76_HomeTask.Domain.Common;

namespace N76_HomeTask.Domain.Models;

public class User : SoftDeleted
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}