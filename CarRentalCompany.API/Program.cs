using Autofac;
using Autofac.Extensions.DependencyInjection;
using CarRentalCompany.Infrastructure;
using CarRentalCompany.Application;
using Microsoft.EntityFrameworkCore;
using CarRentalCompany.Integration.Factories;
using CarRentalCompany.Integration.Mercedes.Factories;
using CarRentalCompany.Integration.Porsche.Factories;
using CarRentalCompany.Integration.Volvo.Factories;
using CarRentalCompany.API.Factories;
using CarRentalCompany.Infrastructure.Seeder;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DBConnection");
builder.Services
    .AddDbContext<CarRentalCompanyDbContext>(opt => opt.UseSqlServer(connection));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterApplication();
        builder.RegisterInfrastructure();
        builder.RegisterType<ActivitySeeder>().InstancePerLifetimeScope();
        builder.RegisterType<CarReceiptFormDtoFactory>().As<ICarReceiptFormDtoFactory>().InstancePerLifetimeScope();
        builder.RegisterType<CarReceiptFormFactory>().Keyed<ICarReceiptFormFactory>(CarReceiptFormFactory.Type);
        builder.RegisterType<MercedesReceiptFormFactory>().Keyed<ICarReceiptFormFactory>(MercedesReceiptFormFactory.Type);
        builder.RegisterType<PorscheReceiptFormFactory>().Keyed<ICarReceiptFormFactory>(PorscheReceiptFormFactory.Type);
        builder.RegisterType<VolvoReceiptFormFactory>().Keyed<ICarReceiptFormFactory>(VolvoReceiptFormFactory.Type);
    });

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ActivitySeeder>();
await seeder.Seed();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();