namespace WebApplication1;

public class Book : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; } = default!;
}