using CarRentalCompany.Application.Repositories;
using CarRentalCompany.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalCompany.Application.Extensions
{
    public static class InfrastructureStartup
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IReceiptFormRepository, ReceiptFormRepository>();
        }
    }
}
