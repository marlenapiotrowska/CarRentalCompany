using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task AddAsync(Car car);
    Task DeleteAsync(Guid id);
    Task<Car?> GetOrDefaultAsync(Guid carId);
}
