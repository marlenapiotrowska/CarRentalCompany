using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IClientRepository
    {
        void Add(Client client);
        IEnumerable<Client> GetAllClients();

    }
}
