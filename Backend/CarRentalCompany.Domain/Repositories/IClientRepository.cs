using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IClientRepository
    {
        Task Add(Client client);
        Task Delete(Guid clientId);
        Task<IEnumerable<Client>> GetAllClients();
        bool CheckIfExists(Guid clientId);
    }
}
