using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Infrastructure.Exceptions;
using CarRentalCompany.Infrastructure.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ClientDb = CarRentalCompany.Infrastructure.Entities.Client;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly CarRentalCompanyDbContext _context;
        private readonly IClientFactory _factory;

        public ClientRepository(CarRentalCompanyDbContext context, IClientFactory factory)
        {
            _context = context;
            _factory = factory;
        }

        public async Task AddAsync(Client client)
        {
            var clientDb = ClientDb.Create(
                client.Id,
                client.Name);

            await _context.Clients.AddAsync(clientDb);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var clientDb = await _context.Clients
                .SingleOrDefaultAsync(c => c.Id == id)
                ?? throw new EntityNotFoundException("client", id);

            _context.Clients.Remove(clientDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            var clientsDb = await _context.Clients
                .ToListAsync();

            return clientsDb
                .ConvertAll(c => new Client(c.Id, c.Name))
;
        }

        public async Task<Client?> GetOrDefaultAsync(Guid id)
        {
            var client = await _context.Clients
                .SingleOrDefaultAsync(c => c.Id == id);

            return client == null
                ? null
                : _factory.Create(client);
        }
    }
}
