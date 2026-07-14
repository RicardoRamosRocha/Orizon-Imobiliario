using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orizon.Imobiliario.Domain.Entities;

namespace Orizon.Imobiliario.Infrastructure.Data.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Slug)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.Slug)
            .IsUnique();

        builder.Property(x => x.Document)
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .HasMaxLength(150);

        builder.Property(x => x.Phone)
            .HasMaxLength(30);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
