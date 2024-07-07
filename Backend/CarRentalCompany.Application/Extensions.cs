using Autofac;
using CarRentalCompany.Application.Services;
using CarRentalCompany.Application.Services.Interfaces;

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
        }
    }
}
