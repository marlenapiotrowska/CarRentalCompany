using CarRentalCompany.Domain.Models;
using CarDb = CarRentalCompany.Infrastructure.Entities.Car;

namespace CarRentalCompany.Infrastructure.Factories.Interfaces
{
    internal interface ICarFactory
    {
        Car Create(CarDb car);
    }
}
