using Autofac;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure.Factories;
using CarRentalCompany.Infrastructure.Factories.Interfaces;
using CarRentalCompany.Infrastructure.Repositories;

namespace CarRentalCompany.Infrastructure
{
    public static class Extensions
    {
        public static void RegisterInfrastructure(this ContainerBuilder builder)
        {
            builder
                .RegisterType<ClientRepository>()
                .As<IClientRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ReceiptFormRepository>()
                .As<IReceiptFormRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ActivityInstanceRepository>()
                .As<IActivityInstanceRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CarRepository>()
                .As<ICarRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CarFactory>()
                .As<ICarFactory>()
                .InstancePerLifetimeScope();
        }
    }
}
