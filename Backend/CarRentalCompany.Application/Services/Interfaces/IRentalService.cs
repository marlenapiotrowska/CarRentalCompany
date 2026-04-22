using CarRentalCompany.Application.Services.Inputs;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface IRentalService
    {
        Task CreateAsync(CreateRentalInput input);
        Task EndAsync(Guid id);
    }
}
