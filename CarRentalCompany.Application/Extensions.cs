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
                .InstancePerRequest();

            builder
               .RegisterType<ReceiptFormService>()
               .As<IReceiptFormService>()
               .InstancePerRequest();
        }
    }
}
