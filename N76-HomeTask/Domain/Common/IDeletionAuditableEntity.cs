namespace N76_HomeTask.Domain.Common;

public interface IDeletionAuditableEntity
{
    Guid DeletedBy { get; set; }
}