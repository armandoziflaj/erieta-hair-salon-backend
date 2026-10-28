using ErietaHairSalon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErietaHairSalon.Infrastructure.Persistence.Configurations;

public class InquiryConfiguration : IEntityTypeConfiguration<Inquiry>
{
    public void Configure(EntityTypeBuilder<Inquiry> builder)
    {
        builder.Property(i => i.SenderName).HasMaxLength(120);
        builder.Property(i => i.SenderEmail).HasMaxLength(200);
        builder.Property(i => i.SenderPhone).HasMaxLength(30);
        builder.Property(i => i.Subject).HasMaxLength(200);
        builder.Property(i => i.Message).HasMaxLength(2000);
    }
}