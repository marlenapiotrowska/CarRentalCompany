using CarRentalCompany.Domain.Models;
using CarRentalCompany.Infrastructure.Factories.Interfaces;
using ClientDb = CarRentalCompany.Infrastructure.Entities.Client;

namespace CarRentalCompany.Infrastructure.Factories
{
    internal class ClientFactory : IClientFactory
    {
        public Client Create(ClientDb clientDb)
        {
            return new Client
                (clientDb.Id, 
                clientDb.Name);
        }
    }
}
