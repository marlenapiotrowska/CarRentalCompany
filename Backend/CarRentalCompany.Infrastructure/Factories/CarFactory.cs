using CarRentalCompany.Domain.Models;
using CarRentalCompany.Infrastructure.Factories.Interfaces;
using CarDb = CarRentalCompany.Infrastructure.Entities.Car;

namespace CarRentalCompany.Infrastructure.Factories
{
    internal class CarFactory : ICarFactory
    {
        public Car Create(CarDb car)
        {
            return new Car
                (car.Id, 
                car.Brand, 
                car.Model,
                car.ProductionYear,
                car.Value,
                car.VIN,
                car.Color,
                car.IsAvailable,
                car.AdditionDate);
        }
    }
}
