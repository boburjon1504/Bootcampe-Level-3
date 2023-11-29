using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71HomeTask.Domain.Entities;

namespace N71HomeTask.Persistense.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(user => user.Posts)
            .WithOne()
            .HasForeignKey(post => post.UserId);
    }
}