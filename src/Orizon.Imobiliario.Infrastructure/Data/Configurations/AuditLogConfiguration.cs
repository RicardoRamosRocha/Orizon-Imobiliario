using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orizon.Imobiliario.Domain.Entities;

namespace Orizon.Imobiliario.Infrastructure.Data.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Action)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.EntityName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.EntityId)
            .HasMaxLength(100);

        builder.Property(x => x.IpAddress)
            .HasMaxLength(64);

        builder.Property(x => x.UserAgent)
            .HasMaxLength(500);

        builder.Property(x => x.OldValues)
            .HasColumnType("jsonb");

        builder.Property(x => x.NewValues)
            .HasColumnType("jsonb");

        builder.HasIndex(x => x.TenantId);
        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.CreatedAt);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
