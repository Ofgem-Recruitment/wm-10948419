using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ofgem.API.EnergyScheme.DataAccess;

public static class ServiceExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EnergySchemeDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("EnergySchemeDatabase"));
        });

        return services;
    }
}
