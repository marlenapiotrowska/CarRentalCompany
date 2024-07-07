using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;

namespace CarRentalCompany.Application.Services
{
    internal class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private readonly ICarDbFactory _factory;

        public CarService(ICarRepository repository, ICarDbFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task Add(AddCarInput input)
        {
            var car = _factory.Create(input);
            _repository.Add(car);
        }

        public async Task Delete(Guid carId)
        {
            _repository.GetById(carId);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
