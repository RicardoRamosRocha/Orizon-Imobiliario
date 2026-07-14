using Orizon.Imobiliario.Domain.Common;

namespace Orizon.Imobiliario.Domain.Entities;

public class Company : TenantEntity
{
    public string LegalName { get; set; } = string.Empty;

    public string TradeName { get; set; } = string.Empty;

    public string? Document { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public bool IsActive { get; set; } = true;

    public Tenant Tenant { get; set; } = null!;
}
