using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Factories.Interfaces
{
    public interface IClientDbFactory
    {
        Client Create(string name); 
    }
}
