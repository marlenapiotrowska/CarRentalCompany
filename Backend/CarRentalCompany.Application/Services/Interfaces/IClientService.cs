using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task Add(string name);
    }
}
