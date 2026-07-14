using Orizon.Imobiliario.Domain.Common;

namespace Orizon.Imobiliario.Domain.Entities;

public class AuditLog : TenantEntity
{
    public Guid? UserId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public string? EntityId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }
}
