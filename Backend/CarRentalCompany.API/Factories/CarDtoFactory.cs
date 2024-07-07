using CarRentalCompany.API.Factories.Interfaces;
using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.API.Factories
{
    public class CarDtoFactory : ICarDtoFactory
    {
        public CarDto Create(Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model
            };
        }
    }
}
