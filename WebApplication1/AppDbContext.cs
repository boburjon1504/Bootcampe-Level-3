using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany<Book>(user => user.Books)
            .WithOne()
            .HasForeignKey(book => book.UserId);
        
        
        base.OnModelCreating(modelBuilder);
    }
}