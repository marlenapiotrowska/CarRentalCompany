using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Factories.Interfaces
{
    public interface ICarDbFactory
    {
        Car Create(AddCarInput input);
    }
}
