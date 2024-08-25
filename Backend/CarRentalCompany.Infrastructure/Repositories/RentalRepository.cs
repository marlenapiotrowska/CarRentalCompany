using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;
using RentalDb = CarRentalCompany.Infrastructure.Entities.Rental;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class RentalRepository : IRentalRepository
    {
        private readonly CarRentalCompanyDbContext _context;
        private readonly IRentalFactory _factory;

        public RentalRepository(CarRentalCompanyDbContext context, IRentalFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        public async Task Add(Rental rental)
        {
            var rentalDb = RentalDb.Create
                (rental.Id,
                rental.RentalStartDate,
                rental.RentalEndDate,
                rental.CarId,
                rental.ClientId,
                rental.ReceiptFormId,
                rental.IsEnded);

            await _context.Rentals.AddAsync(rentalDb);
            await _context.SaveChangesAsync();
        }

        public async Task<Rental?> GetOrDefault(Guid carId)
        {
            var rentalDb = await _context.Rentals
                .SingleOrDefaultAsync(r => r.CarId == carId && !r.IsEnded);
            
            if (rentalDb == null)
            {
                return null;
            }

            return _factory.Create(rentalDb);
        }
    }
}
