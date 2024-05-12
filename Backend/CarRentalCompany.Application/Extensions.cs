using Autofac;
using CarRentalCompany.Application.Services;

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
        }
    }
}
