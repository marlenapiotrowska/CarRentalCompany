using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task AddAsync(AddCarInput input);
        Task DeleteAsync(Guid carId);
    }
}
