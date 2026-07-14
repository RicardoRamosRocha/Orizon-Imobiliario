using Orizon.Imobiliario.Domain.Common;

namespace Orizon.Imobiliario.Domain.Entities;

public class Tenant : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;

    public string? Document { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Company> Companies { get; set; } = [];
}
