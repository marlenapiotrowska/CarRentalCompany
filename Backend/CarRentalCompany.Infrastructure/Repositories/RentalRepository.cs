using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using RentalDb = CarRentalCompany.Infrastructure.Entities.Rental;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class RentalRepository : IRentalRepository
    {
        private readonly CarRentalCompanyDbContext _context;

        public RentalRepository(CarRentalCompanyDbContext context)
        {
            _context = context;
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

        public bool CheckIfExistsNotEndedForCar(Guid carId)
        {
            return _context.Rentals
                .Any(r => r.CarId == carId && !r.IsEnded);
        }
    }
}
