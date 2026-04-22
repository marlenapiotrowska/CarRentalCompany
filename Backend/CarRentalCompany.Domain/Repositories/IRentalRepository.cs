using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IRentalRepository
    {
        Task AddAsync(Rental rental);
        Task<Rental?> GetOrDefaultNotEndedForCarIdAsync(Guid carId);
        Task<Rental?> GetOrDefaultAsync(Guid id);
        Task UpdateAsync(Rental rental);
    }
}
