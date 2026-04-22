using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure.Exceptions;
using CarRentalCompany.Infrastructure.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CarDb = CarRentalCompany.Infrastructure.Entities.Car;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class CarRepository : ICarRepository
    {
        private readonly CarRentalCompanyDbContext _context;
        private readonly ICarFactory _factory;

        public CarRepository(CarRentalCompanyDbContext context, ICarFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        public async Task AddAsync(Car car)
        {
            var carDb = CarDb.Create(
                car.Id,
                car.Brand,
                car.Model,
                car.ProductionYear,
                car.Value,
                car.VIN,
                car.Color,
                car.IsAvailable,
                car.AdditionDate);

            await _context.Cars.AddAsync(carDb);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var carDb = await _context.Cars
                .SingleOrDefaultAsync(c => c.Id == id)
                ?? throw new EntityNotFoundException("car", id);

            _context.Cars.Remove(carDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var cars = await _context.Cars
                .ToListAsync();

            if (cars.Count == 0)
                return [];

            return cars
                .ConvertAll(_factory.Create)
;
        }

        public async Task<Car?> GetOrDefaultAsync(Guid id)
        {
            var car = await _context.Cars
                .SingleOrDefaultAsync(c => c.Id == id);

            switch (car)
            {
                case null:
                    return null;
                default:
                    return _factory.Create(car);
            }
        }
    }
}
