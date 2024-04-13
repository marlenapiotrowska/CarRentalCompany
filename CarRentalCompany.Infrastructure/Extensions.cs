﻿using Autofac;
using CarRentalCompany.Domain.Repositories;
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
        }
    }
}
