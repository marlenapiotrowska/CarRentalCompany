using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
    }
}
