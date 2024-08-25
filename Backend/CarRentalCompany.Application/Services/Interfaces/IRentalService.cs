using CarRentalCompany.Application.Services.Inputs;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface IRentalService
    {
        Task Create(CreateRentalInput input);
        Task End(Guid id);
    }
}
