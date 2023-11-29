using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N71HomeTask.Domain.Entities;

namespace N71HomeTask.Persistense.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(comment => comment.UserId);

        builder
            .HasOne<Comment>()
            .WithMany(comment => comment.Comments)
            .HasForeignKey(comment => comment.ParentId);
    }
}