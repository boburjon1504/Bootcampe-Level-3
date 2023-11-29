namespace N76_HomeTask.Domain.Common;

public interface ICreationAuditableEntity
{
    Guid CreatedBy { get; set; }
}