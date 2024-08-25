using CarRentalCompany.Domain.Models;
using CarRentalCompany.Infrastructure.Factories.Interfaces;
using RentalDb = CarRentalCompany.Infrastructure.Entities.Rental;

namespace CarRentalCompany.Infrastructure.Factories
{
    internal class RentalFactory : IRentalFactory
    {
        public Rental Create(RentalDb rentalDb)
        {
            return new Rental
                (rentalDb.Id,
                rentalDb.RentalStartDate,
                rentalDb.RentalEndDate,
                rentalDb.CarId,
                rentalDb.ClientId,
                rentalDb.ReceiptFormId,
                rentalDb.IsEnded);
        }
    }
}
