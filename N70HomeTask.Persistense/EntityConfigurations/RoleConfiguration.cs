using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N70HomeTask.Domain.Entities;
using N70HomeTask.Domain.Enums;

namespace N70HomeTask.Persistense.EntityConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = Guid.Parse("ee10b208-e37e-4708-a26c-5a8a13af950e"),
                RoleType = UserRole.User
            },
            new Role
            {
                Id = Guid.Parse("dee9b6ee-5877-4e52-a26c-a4f6af988668")
            });
    }
}