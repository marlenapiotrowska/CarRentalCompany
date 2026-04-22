using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure.Exceptions;
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

        public async Task AddAsync(Rental rental)
        {
            var rentalDb = RentalDb.Create(
                rental.Id,
                rental.RentalStartDate,
                rental.RentalEndDate,
                rental.CarId,
                rental.ClientId,
                rental.ReceiptFormId,
                rental.IsEnded);

            await _context.Rentals.AddAsync(rentalDb);
            await _context.SaveChangesAsync();
        }

        public async Task<Rental?> GetOrDefaultNotEndedForCarIdAsync(Guid carId)
        {
            var rentalDb = await _context.Rentals
                .SingleOrDefaultAsync(r => r.CarId == carId && !r.IsEnded);

            return GetRental(rentalDb);
        }

        public async Task<Rental?> GetOrDefaultAsync(Guid id)
        {
            var rentalDb = await _context.Rentals
                .SingleOrDefaultAsync(r => r.Id == id);

            return GetRental(rentalDb);
        }

        public async Task UpdateAsync(Rental rental)
        {
            var rentalDb = await _context.Rentals
                .SingleOrDefaultAsync(r => r.Id == rental.Id)
                ?? throw new EntityNotFoundException("car", rental.Id);

            rentalDb.RentalEndDate = rental.RentalEndDate;
            rentalDb.CarId = rental.CarId;
            rentalDb.ClientId = rental.ClientId;
            rentalDb.ReceiptFormId = rental.ReceiptFormId;
            rentalDb.IsEnded = rental.IsEnded;

            await _context.SaveChangesAsync();
        }

        private Rental? GetRental(RentalDb? rentalDb)
        {
            return rentalDb == null
                ? null
                : _factory.Create(rentalDb);
        }
    }
}
