using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73HomeTask.Domain.Entities;
using N73HomeTask.Domain.Enums;

namespace N73HomeTask.Persistense.EntityConfigurations;

public class NotificationHistoryConfiguration : IEntityTypeConfiguration<NotificationHistory>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.Property(x => x.Content).HasMaxLength(125_000);

        builder.ToTable("NotificationHistories")
            .HasDiscriminator(x => x.Type)
            .HasValue<SmsHistory>(NotificationType.Sms)
            .HasValue<EmailHistory>(NotificationType.Email);

        builder.HasOne<NotificationTemplate>(x => x.Template)
            .WithMany(a => a.Histories)
            .HasForeignKey(history => history.TemplateId);

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.SenderUserId);

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.ReceiverUserId);
    }
}