using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N76_HomeTask.Domain.Models;

namespace N76_HomeTask.Persistense.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany<Book>().WithOne().HasForeignKey(book => book.UserId);
    }
}