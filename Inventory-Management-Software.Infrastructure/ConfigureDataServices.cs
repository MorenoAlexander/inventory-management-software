using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

namespace Inventory_Management_Software.Infrastructure;

public static class ConfigureDataServices
{
    public static void AddDataServices(this IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddDbContext<GenericIMSContext>(options =>
        {

            options.UseOracle(config.GetConnectionString("Default"));
                OracleConfiguration.TnsAdmin = config.GetSection("OracleConfiguration")["TnsAdmin"];
            OracleConfiguration.WalletLocation = config.GetSection("OracleConfiguration")["WalletLocation"];
            
        });
    }
}