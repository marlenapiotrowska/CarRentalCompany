using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.API.Factories
{
    public class ClientDtoFactory : IClientDtoFactory
    {
        public IEnumerable<ClientDto> Create(IEnumerable<Client> clients)
        {
            return clients.Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.Name,
            });
        }
    }
}
