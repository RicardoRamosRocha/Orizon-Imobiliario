using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orizon.Imobiliario.Domain.Entities;
using Orizon.Imobiliario.Infrastructure.Data;
using Orizon.Imobiliario.Infrastructure.Identity.Constants;

namespace Orizon.Imobiliario.Infrastructure.Identity;

public static class IdentitySeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var context =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var roleManager =
            scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        var userManager =
            scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // =========================================================
        // ROLES
        // =========================================================

        foreach (var roleName in Roles.All)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new ApplicationRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpperInvariant()
                });
            }
        }

        // =========================================================
        // TENANT PILOTO
        // =========================================================

        var tenant = await context.Tenants.FirstOrDefaultAsync();

        if (tenant is null)
        {
            tenant = new Tenant
            {
                Name = "Augusto César Direitos e Negócios Imobiliários",
                Slug = "augusto-cesar",
                Email = "contato@augustocesar.com.br",
                IsActive = true
            };

            context.Tenants.Add(tenant);

            context.Companies.Add(new Company
            {
                Tenant = tenant,
                LegalName = "Augusto César Direitos e Negócios Imobiliários",
                TradeName = "Augusto César Imobiliário",
                Email = "contato@augustocesar.com.br",
                IsActive = true
            });

            await context.SaveChangesAsync();
        }

        // =========================================================
        // ADMINISTRADOR
        // =========================================================

        const string adminEmail = "admin@orizonimobiliario.com.br";
        const string adminPassword = "Admin123";

        var adminUser = await userManager.Users
            .FirstOrDefaultAsync(user => user.Email == adminEmail);

        if (adminUser is null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FullName = "Administrador Orizon",
                EmailConfirmed = true,
                IsActive = true,
                TenantId = tenant.Id
            };

            var result = await userManager.CreateAsync(
                adminUser,
                adminPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(
                    "; ",
                    result.Errors.Select(error => error.Description));

                throw new InvalidOperationException(
                    $"Não foi possível criar o usuário administrador: {errors}");
            }
        }

        // =========================================================
        // PAPEL DO ADMINISTRADOR
        // =========================================================

        if (!await userManager.IsInRoleAsync(adminUser, Roles.Administrador))
        {
            await userManager.AddToRoleAsync(
                adminUser,
                Roles.Administrador);
        }
    }
}