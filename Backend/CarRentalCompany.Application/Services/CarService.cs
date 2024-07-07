using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services
{
    internal class CarService : ICarService
    {
        public async Task<Car> Add(AddCarInput input)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid carId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
