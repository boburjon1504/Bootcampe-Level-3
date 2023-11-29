using Microsoft.EntityFrameworkCore;

namespace N70HomeTask.Persistense.DataAccess;

public class Identity : DbContext
{
    public Identity(DbContextOptions<Identity> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Identity).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}