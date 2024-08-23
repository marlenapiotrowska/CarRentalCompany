using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.API.Factories.Interfaces
{
    public interface ICarDtoFactory
    {
        CarDto Create(Car car);
    }
}
