using CarRentalCompany.Application.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalCompany.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IReceiptFormBuilder, TypicalReceiptFormBuilder>();
            services.AddSingleton<IReceiptFormBuilder, PorscheReceiptFormBuilder>();
            services.AddSingleton<IReceiptFormBuilder, MercedesReceiptFormBuilder>();
            services.AddSingleton<IReceiptFormBuilder, VolvoReceiptFormBuilder>();

            return services;
        }
    }
}
