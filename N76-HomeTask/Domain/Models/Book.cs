using N76_HomeTask.Domain.Common;

namespace N76_HomeTask.Domain.Models;

public class Book : SoftDeleted,ICreationAuditableEntity,
    IModificationAuditableEntity,IDeletionAuditableEntity
{
    public Guid UserId { get; set; }
    public int PageSize { get; set; }
    public string Description { get; set; } = default!;
    public Guid CreatedBy { get; set; }
    public Guid ModifiedBy { get; set; }
    public Guid DeletedBy { get; set; }
}