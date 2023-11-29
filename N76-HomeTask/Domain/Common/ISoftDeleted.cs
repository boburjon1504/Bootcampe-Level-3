namespace N76_HomeTask.Domain.Common;

public interface ISoftDeleted
{
    bool IsDeleted { get; set; }
    DateTime DeletedDate { get; set; }
}