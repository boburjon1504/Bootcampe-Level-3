﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N73HomeTask.Domain.Entities;

namespace N73HomeTask.Persistense.EntityConfigurations;

public class EmailHistoryConfiguration : IEntityTypeConfiguration<EmailHistory>
{
    public void Configure(EntityTypeBuilder<EmailHistory> builder)
    {
        builder
            .Property(temp => temp.SenderEmailAddress)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(temp => temp.ReceiverEmailAddress)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(temp => temp.Subject)
            .IsRequired()
            .HasMaxLength(256);
    }
}