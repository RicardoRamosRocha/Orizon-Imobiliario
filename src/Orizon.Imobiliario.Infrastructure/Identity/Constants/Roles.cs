namespace Orizon.Imobiliario.Infrastructure.Identity.Constants;

public static class Roles
{
    public const string Administrador = "Administrador";
    public const string Corretor = "Corretor";
    public const string Advogado = "Advogado";
    public const string Cliente = "Cliente";

    public static readonly string[] All =
    [
        Administrador,
        Corretor,
        Advogado,
        Cliente
    ];
}
