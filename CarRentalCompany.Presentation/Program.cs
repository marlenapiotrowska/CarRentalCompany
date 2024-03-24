using CarRentalCompany.Application.Builders;
using CarRentalCompany.Infrastructure;
using CarRentalCompany.Presentation.Services;
using CarRentalCompany.Strategies;
using CarRentalCompany.Strategies.CarBrands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalCompany.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
            {
                services.AddDbContext<CarRentalCompanyDbContext>(options
                   => options.UseSqlServer("Server=.\\sqlexpress;Database=CarRentalCompany;Trusted_Connection=Yes;MultipleActiveResultSets=True;TrustServerCertificate=true"));
                services.AddSingleton<IReceiptFormBuilder, TypicalReceiptFormBuilder>();
                services.AddSingleton<IReceiptFormBuilder, PorscheReceiptFormBuilder>();
                services.AddSingleton<IReceiptFormBuilder, MercedesReceiptFormBuilder>();
                services.AddSingleton<IReceiptFormBuilder, VolvoReceiptFormBuilder>();
                services.AddSingleton<ICarReceiptForm, CarReceiptForm>();
                services.AddSingleton<ICarReceiptForm, MercedesReceiptForm>();
                services.AddSingleton<ICarReceiptForm, PorscheReceiptForm>();
                services.AddSingleton<ICarReceiptForm, VolvoReceiptForm>();
                services.AddTransient<IReceiptFormStrategy, ReceiptFormStrategy>();
            });

            var app = host.Build();

            var strategy = app.Services.GetService<IReceiptFormStrategy>();
            var careReceiptForms = app.Services.GetServices<ICarReceiptForm>();
            var menu = new MenuService(careReceiptForms, strategy);

            menu.Render();
        }
    }
}
