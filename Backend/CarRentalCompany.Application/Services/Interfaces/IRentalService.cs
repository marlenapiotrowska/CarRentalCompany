using CarRentalCompany.Application.Services.Inputs;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface IRentalService
    {
        Task CreateRental(CreateRentalInput input);
    }
}
