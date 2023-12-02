namespace WebApplication1;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}