namespace N76_HomeTask.Domain.Common;

public class Auditable : Entity,IAuditable
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}