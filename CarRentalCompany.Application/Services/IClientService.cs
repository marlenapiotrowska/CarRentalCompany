using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
    }
}
