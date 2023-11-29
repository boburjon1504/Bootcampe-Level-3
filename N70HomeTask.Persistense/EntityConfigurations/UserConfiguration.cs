using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N70HomeTask.Domain.Entities;

namespace N70HomeTask.Persistense.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(user=>user.Role).WithMany().HasForeignKey(user=>user.RoleId);
    }
}