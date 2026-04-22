using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories;

public interface IClientRepository
{
    Task AddAsync(Client client);
    Task DeleteAsync(Guid clientId);
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client?> GetOrDefaultAsync(Guid clientId);
}
