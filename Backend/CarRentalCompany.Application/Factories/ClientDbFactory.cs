using CarRentalCompany.Application.Exceptions;
using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Factories
{
    internal class ClientDbFactory : IClientDbFactory
    {
        public Client Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new EmptyInputValueException("name");
            }

            return new Client
                (Guid.NewGuid(),
                name);
        }
    }
}
