using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IRentalRepository
    {
        Task Add(Rental rental);
        Task<Rental?> GetOrDefault(Guid carId);
    }
}
