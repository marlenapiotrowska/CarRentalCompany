using CarRentalCompany.Domain.Models;
using ClientDb = CarRentalCompany.Infrastructure.Entities.Client;

namespace CarRentalCompany.Infrastructure.Factories.Interfaces
{
    internal interface IClientFactory
    {
        Client Create(ClientDb clientDb);
    }
}
