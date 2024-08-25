using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IClientRepository
    {
        Task Add(Client client);
        Task Delete(Guid clientId);
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client?> GetOrDefault(Guid clientId);
    }
}
