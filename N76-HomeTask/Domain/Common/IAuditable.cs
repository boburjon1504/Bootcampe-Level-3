namespace N76_HomeTask.Domain.Common;

public interface IAuditable
{
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
}