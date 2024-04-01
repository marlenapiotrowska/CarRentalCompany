using Autofac;
using Autofac.Extensions.DependencyInjection;
using CarRentalCompany.Application;
using CarRentalCompany.Infrastructure;
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
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();