using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car GetById(Guid id);
        void Add(Car car);
        void Delete(Guid id);
    }
}
