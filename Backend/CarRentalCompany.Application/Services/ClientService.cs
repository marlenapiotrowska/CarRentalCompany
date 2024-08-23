using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;

namespace CarRentalCompany.Application.Services
{
    internal class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IClientDbFactory _factory;

        public ClientService(IClientRepository repository, IClientDbFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task Add(string name)
        {
            var client = _factory.Create(name);
            _repository.Add(client);
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return _repository.GetAllClients();
        }
    }
}
