using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71HomeTask.Domain.Entities;

namespace N71HomeTask.Persistense.EntityConfigurations;

public class PostConfiguratoin : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasMany(post => post.Comments)
            .WithOne()
            .HasForeignKey(comment => comment.PostId);
    }
}