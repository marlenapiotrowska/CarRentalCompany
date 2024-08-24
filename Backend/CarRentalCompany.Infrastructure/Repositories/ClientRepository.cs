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

        public async Task Add(Client client)
        {
            var clientDb = ClientDb.Create
                (client.Id, 
                client.Name);

            await _context.Clients.AddAsync(clientDb);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var clientDb = await _context.Clients
                .SingleOrDefaultAsync(c => c.Id == id)
                ?? throw new EntityNotFoundException("client", id);

            _context.Clients.Remove(clientDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var clientsDb = await _context.Clients
                .ToListAsync();

            return clientsDb
                .Select(c => new Client(c.Id, c.Name))
                .ToList();
        }

        public bool CheckIfExists(Guid id)
        {
            return _context.Clients
                .Any(c => c.Id == id);
        }
    }
}
