using CarRentalCompany.Application.Builders;
using CarRentalCompany.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalCompany.Application.Extensions
{
    public static class ApplicationStartup
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IReceiptFormBuilder, TypicalReceiptFormBuilder>();
            services.AddSingleton<IReceiptFormBuilder, PorscheReceiptFormBuilder>();
            services.AddSingleton<IReceiptFormBuilder, MercedesReceiptFormBuilder>();
            services.AddSingleton<IReceiptFormBuilder, VolvoReceiptFormBuilder>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IReceiptFormService, ReceiptFormService>();
        }
    }
}
