using Autofac;
using CarRentalCompany.Application.Builders;

namespace CarRentalCompany.Application
{
    public static class Extensions
    {
        public static void RegisterApplication(this ContainerBuilder builder)
        {
            builder
                .RegisterType<TypicalReceiptFormBuilder>()
                .As<IReceiptFormBuilder>()
                .SingleInstance();

            builder
               .RegisterType<PorscheReceiptFormBuilder>()
               .As<IReceiptFormBuilder>()
               .SingleInstance();

            builder
               .RegisterType<MercedesReceiptFormBuilder>()
               .As<IReceiptFormBuilder>()
               .SingleInstance();

            builder
               .RegisterType<VolvoReceiptFormBuilder>()
               .As<IReceiptFormBuilder>()
               .SingleInstance();
        }
    }
}
