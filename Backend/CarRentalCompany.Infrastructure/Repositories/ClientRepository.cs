using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using ClientDb = CarRentalCompany.Infrastructure.Entities.Client;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly CarRentalCompanyDbContext _context;

        public ClientRepository(CarRentalCompanyDbContext context)
        {
            _context = context;
        }

        public void Add(Client client)
        {
            var clientDb = ClientDb.Create
                (client.Id, 
                client.Name);

            _context.Clients.Add(clientDb);
            _context.SaveChanges();
        }

        public IEnumerable<Client> GetAllClients()
        {
            var clientsDb = _context.Clients
                .ToList();

            return clientsDb
                .Select(c => new Client(c.Id, c.Name))
                .ToList();
        }
    }
}
