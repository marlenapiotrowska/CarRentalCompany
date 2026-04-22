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

        public async Task AddAsync(string name)
        {
            var client = _factory.Create(name);
            await _repository.AddAsync(client);
        }

        public async Task DeleteAsync(Guid clientId)
        {
            await _repository.DeleteAsync(clientId);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _repository.GetAllClientsAsync();
        }
    }
}
