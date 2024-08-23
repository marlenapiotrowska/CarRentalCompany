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
        
        public async Task Add(Car car)
        {
            var carDb = CarDb.Create
                (car.Id,
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

        public async Task Delete(Guid id)
        {
            var carDb = await _context.Cars
                .SingleOrDefaultAsync(c => c.Id == id)
                ?? throw new EntityNotFoundException("car", id);

            _context.Cars.Remove(carDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            var cars = await _context.Cars
                .ToListAsync();

            if (cars.Count == 0)
            {
                return Enumerable.Empty<Car>();
            }

            return cars
                .Select(car => _factory.Create(car))
                .ToList();
        }

        public async Task<Car> GetById(Guid id)
        {
            var carDb = await _context.Cars
                .SingleOrDefaultAsync(c => c.Id == id)
                ?? throw new EntityNotFoundException("car", id);

            return _factory.Create(carDb);
        }
    }
}
