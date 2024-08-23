using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure.Exceptions;
using CarRentalCompany.Infrastructure.Factories.Interfaces;
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
        
        public void Add(Car car)
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

            _context.Cars.Add(carDb);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var carDb = _context.Cars
                .SingleOrDefault(c => c.Id == id)
                ?? throw new EntityNotFoundException("car", id);

            _context.Cars.Remove(carDb);
            _context.SaveChanges();
        }

        public IEnumerable<Car> GetAll()
        {
            var cars = _context.Cars;

            if (!cars.Any())
            {
                return Enumerable.Empty<Car>();
            }

            return cars
                .Select(car => _factory.Create(car))
                .ToList();
        }

        public Car GetById(Guid id)
        {
            var carDb = _context.Cars
                .SingleOrDefault(c => c.Id == id)
                ?? throw new EntityNotFoundException("car", id);

            return _factory.Create(carDb);
        }
    }
}
