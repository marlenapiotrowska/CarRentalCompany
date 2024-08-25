using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IRentalRepository
    {
        Task Add(Rental rental);
        Task<Rental?> GetOrDefaultNotEndedForCarId(Guid carId);
        Task<Rental?> GetOrDefault(Guid id);
        Task Update(Rental rental);
    }
}
