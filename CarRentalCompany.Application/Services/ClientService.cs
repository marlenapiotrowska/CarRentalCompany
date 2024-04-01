using CarRentalCompany.Application.Repositories;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services
{
    internal class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _repository.GetAllClients();
        }
    }
}
