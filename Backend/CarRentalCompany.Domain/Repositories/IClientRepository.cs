using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IClientRepository
    {
        Task Add(Client client);
        Task<IEnumerable<Client>> GetAllClients();
    }
}
