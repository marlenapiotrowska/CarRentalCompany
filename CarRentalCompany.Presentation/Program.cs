using CarRentalCompany.Application;
using CarRentalCompany.Application.Builders;
using CarRentalCompany.Strategies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalCompany.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddApplication();
                services.AddTransient<ReceiptFormStrategy>();
            });

            var app = host.Build();

            var builders = app.Services.GetServices<IReceiptFormBuilder>();
            var strategy = new ReceiptFormStrategy(builders);
            var builder = strategy.ResolveReceiptForm("Porsche");
            builder.CreateEmpty();
            builder.GetResult();
        }
    }
}
