using ErietaHairSalon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErietaHairSalon.Infrastructure.Persistence.Configurations;

public class TransformationConfiguration : IEntityTypeConfiguration<Transformation>
{
    public void Configure(EntityTypeBuilder<Transformation> builder)
    {
        builder.Property(t => t.Title)
            .HasColumnType("jsonb");

        builder.Property(t => t.Description)
            .HasColumnType("jsonb");

        builder.Property(t => t.BeforeImageUrl)
            .HasMaxLength(500);

        builder.Property(t => t.AfterImageUrl)
            .HasMaxLength(500);

        builder.Property(t => t.ServiceTag)
            .HasMaxLength(80);

        builder.HasIndex(t => new { t.IsActive, t.DisplayOrder });
    }
}