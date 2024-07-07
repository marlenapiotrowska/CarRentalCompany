using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetAllClients();
    }
}
