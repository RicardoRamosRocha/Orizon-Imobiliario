using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orizon.Imobiliario.Domain.Entities;

namespace Orizon.Imobiliario.Infrastructure.Data.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.LegalName)
            .HasMaxLength(180)
            .IsRequired();

        builder.Property(x => x.TradeName)
            .HasMaxLength(180)
            .IsRequired();

        builder.Property(x => x.Document)
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .HasMaxLength(150);

        builder.Property(x => x.Phone)
            .HasMaxLength(30);

        builder.Property(x => x.Website)
            .HasMaxLength(200);

        builder.HasIndex(x => x.TenantId);

        builder.HasOne(x => x.Tenant)
            .WithMany(x => x.Companies)
            .HasForeignKey(x => x.TenantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
