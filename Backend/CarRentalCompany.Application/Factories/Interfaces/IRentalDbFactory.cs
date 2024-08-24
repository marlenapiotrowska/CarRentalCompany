using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Factories.Interfaces
{
    internal interface IRentalDbFactory
    {
        Rental Create(Guid clientId, Guid carId);
    }
}
