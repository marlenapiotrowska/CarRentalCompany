using CarRentalCompany.Frontend.DataAccess;
using CarRentalCompany.Frontend.Domain.Interfaces;
using CarRentalCompany.Frontend.Presentation.Views;
using CarRentalCompany.Frontend.Presentation.Views.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddTransient<ICarReceiptFormRepository, CarRentalClient>();
    services.AddTransient<IClientRepository, CarRentalClient>();
    services.AddTransient<MenuView>();
    services.AddTransient<CarReceiptFormCreationView>();
});

var app = host.Build();
var menu = ActivatorUtilities.CreateInstance<MenuView>(app.Services);
await menu.RenderAsync();