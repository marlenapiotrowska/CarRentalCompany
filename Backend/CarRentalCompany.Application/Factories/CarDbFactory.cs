using CarRentalCompany.Application.Exceptions;
using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Providers;

namespace CarRentalCompany.Application.Factories
{
    internal class CarDbFactory : ICarDbFactory
    {
        private const int _minProductionYear = 1900;
        private readonly ITimeProvider _timeProvider;

        public CarDbFactory(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public Car Create(AddCarInput input)
        {
            if (string.IsNullOrEmpty(input.Brand))
            {
                throw new EmptyInputValueException("brand");
            }
            if (string.IsNullOrEmpty(input.Model))
            {
                throw new EmptyInputValueException("model");
            }
            if (input.ProductionYear < _minProductionYear)
            {
                throw new InvalidValueException($"Car production year must be more than {_minProductionYear}");
            }
            if (input.Value <= 0)
            {
                throw new InvalidValueException("Car value must more than 0");
            }
            if (string.IsNullOrEmpty(input.VIN))
            {
                throw new EmptyInputValueException("VIN");
            }
            if (string.IsNullOrEmpty(input.Color))
            {
                throw new EmptyInputValueException("color");
            }

            return new Car
                (Guid.NewGuid(),
                input.Brand,
                input.Model,
                input.ProductionYear,
                input.Value,
                input.VIN,
                input.Color,
                isAvailable: true,
                _timeProvider.GetTime());
        }
    }
}
