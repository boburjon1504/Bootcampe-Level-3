using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Persistense.EntityConfigurations;

public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder
            .Property(temp => temp.Content)
            .HasMaxLength(125_000);

        builder
            .HasIndex(temp => new
            {
                temp.Type,
                temp.TemplateType
            }).IsUnique();

        builder.ToTable("NotificationTemplates")
            .HasDiscriminator(temp => temp.Type)
            .HasValue<SmsTemplate>(NotificationType.Sms)
            .HasValue<EmailTemplate>(NotificationType.Email);

    }
}