namespace N76_HomeTask.Domain.Common;

public class SoftDeleted : Auditable,ISoftDeleted
{
    public bool IsDeleted { get; set; }
    public DateTime DeletedDate { get; set; }
}