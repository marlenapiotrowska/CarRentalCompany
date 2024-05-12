using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
    }
}
