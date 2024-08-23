using Autofac;
using Autofac.Extensions.DependencyInjection;
using CarRentalCompany.API.Factories;
using CarRentalCompany.API.Factories.Interfaces;
using CarRentalCompany.Application;
using CarRentalCompany.Infrastructure;
using CarRentalCompany.Integration.Factories;
using CarRentalCompany.Integration.Mercedes.Factories;
using CarRentalCompany.Integration.Porsche.Factories;
using CarRentalCompany.Integration.Volvo.Factories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DBConnection");
builder.Services
    .AddDbContext<CarRentalCompanyDbContext>(opt => opt.UseSqlServer(connection));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterApplication();
        builder.RegisterInfrastructure();
        builder.RegisterType<CarReceiptFormDtoFactory>().As<ICarReceiptFormDtoFactory>().InstancePerLifetimeScope();
        builder.RegisterType<ClientDtoFactory>().As<IClientDtoFactory>().InstancePerLifetimeScope();
        builder.RegisterType<CarDtoFactory>().As<ICarDtoFactory>().InstancePerLifetimeScope();
        builder.RegisterType<CarReceiptFormIntegrator>().Keyed<ICarReceiptFormIntegrator>(CarReceiptFormIntegrator.Type);
        builder.RegisterType<MercedesReceiptFormIntegrator>().Keyed<ICarReceiptFormIntegrator>(MercedesReceiptFormIntegrator.Type);
        builder.RegisterType<PorscheReceiptFormIntegrator>().Keyed<ICarReceiptFormIntegrator>(PorscheReceiptFormIntegrator.Type);
        builder.RegisterType<VolvoReceiptFormIntegrator>().Keyed<ICarReceiptFormIntegrator>(VolvoReceiptFormIntegrator.Type);
    });

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();