using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.API.Factories
{
    public interface IClientDtoFactory
    {
        IEnumerable<ClientDto> Create(IEnumerable<Client> clients); 
    }
}
