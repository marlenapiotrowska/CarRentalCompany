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

        public async Task AddAsync(AddCarInput input)
        {
            var car = _factory.Create(input);
            await _repository.AddAsync(car);
        }

        public async Task DeleteAsync(Guid carId)
        {
            await _repository.DeleteAsync(carId);
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
