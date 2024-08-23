using Autofac;
using CarRentalCompany.Application.Factories;
using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Application.Providers;
using CarRentalCompany.Application.Services;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Domain.Providers;

namespace CarRentalCompany.Application
{
    public static class Extensions
    {
        public static void RegisterApplication(this ContainerBuilder builder)
        {
            builder
                .RegisterType<ClientService>()
                .As<IClientService>()
                .InstancePerLifetimeScope();

            builder
               .RegisterType<ReceiptFormService>()
               .As<IReceiptFormService>()
               .InstancePerLifetimeScope();

            builder
                .RegisterType<CarService>()
                .As<ICarService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CarDbFactory>()
                .As<ICarDbFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Clock>()
                .As<IClock>()
                .InstancePerLifetimeScope();
        }
    }
}
