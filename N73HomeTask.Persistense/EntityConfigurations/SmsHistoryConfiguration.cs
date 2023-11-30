using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Persistense.EntityConfigurations;

public class SmsHistoryConfiguration : IEntityTypeConfiguration<SmsHistory>
{
    public void Configure(EntityTypeBuilder<SmsHistory> builder)
    {
        builder
            .Property(history => history.SenderPhoneNumber)
            .IsRequired()
            .HasMaxLength(32);

        builder
            .Property(x => x.ReceiverPhoneNumber)
            .IsRequired()
            .HasMaxLength(32);
    }
}