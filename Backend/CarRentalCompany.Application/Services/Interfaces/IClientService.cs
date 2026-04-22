using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task AddAsync(string name);
        Task DeleteAsync(Guid clientId);
    }
}
