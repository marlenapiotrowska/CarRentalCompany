using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IRentalRepository
    {
        Task Add(Rental rental);
        bool CheckIfExistsNotEndedForCar(Guid carId);
    }
}
