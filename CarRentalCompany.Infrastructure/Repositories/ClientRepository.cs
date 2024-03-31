using CarRentalCompany.Application.Repositories;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly CarRentalCompanyDbContext _context;

        public ClientRepository(CarRentalCompanyDbContext context)
        {
            _context = context;
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
