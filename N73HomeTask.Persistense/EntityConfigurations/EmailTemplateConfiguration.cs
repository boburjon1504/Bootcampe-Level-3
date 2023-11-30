using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Persistense.EntityConfigurations;

public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
{
    public void Configure(EntityTypeBuilder<EmailTemplate> builder)
    {
        builder
            .Property(temp => temp.Subject)
            .IsRequired()
            .HasMaxLength(256);
    }
}