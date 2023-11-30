using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Persistense.EntityConfigurations;

public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
{
    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder
            .HasOne<User>()
            .WithOne(user => user.UserSettings)
            .HasForeignKey<UserSettings>(setting => setting.Id);
    }
}