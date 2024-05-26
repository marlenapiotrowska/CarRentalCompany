using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Frontend.Domain.ValueObjects;

namespace CarRentalCompany.Frontend.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<ExecutionResultGeneric<IEnumerable<ClientDto>>> GetAllClients();
    }
}
