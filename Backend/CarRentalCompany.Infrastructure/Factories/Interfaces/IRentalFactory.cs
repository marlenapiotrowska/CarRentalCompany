using CarRentalCompany.Domain.Models;
using RentalDb = CarRentalCompany.Infrastructure.Entities.Rental;

namespace CarRentalCompany.Infrastructure.Factories.Interfaces
{
    internal interface IRentalFactory
    {
        Rental Create(RentalDb rentalDb);
    }
}
