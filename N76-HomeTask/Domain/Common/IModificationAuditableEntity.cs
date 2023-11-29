namespace N76_HomeTask.Domain.Common;

public interface IModificationAuditableEntity
{
    Guid ModifiedBy { get; set; }
}