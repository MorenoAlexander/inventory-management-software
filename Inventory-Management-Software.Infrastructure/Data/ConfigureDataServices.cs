using Inventory_Management_Software.Core.Interfaces;
using Inventory_Management_Software.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

namespace Inventory_Management_Software.Infrastructure.Data;

public static class ConfigureDataServices
{
    public static void AddDataServices(this IServiceCollection serviceCollection, IConfiguration config)
    {
        OracleConfiguration.TnsAdmin = config.GetSection("OracleConfiguration")["TnsAdmin"];
        OracleConfiguration.WalletLocation = config.GetSection("OracleConfiguration")["WalletLocation"];
        serviceCollection.AddDbContextPool<GenericIMSContext>(options =>
        {
            options.UseOracle(config.GetConnectionString("Default"));
        }, 10);

        serviceCollection.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
        serviceCollection.AddScoped(typeof(IEfReadOnlyRepository<>), typeof(EfReadOnlyRepository<>));
    }
}