using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory_Management_Software.Infrastructure;

public static class ConfigureDataServices
{
    public static void AddDataServices(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<GenericIMSContext>(options =>
        {

            options.UseOracle(connectionString);
        });
    }
}