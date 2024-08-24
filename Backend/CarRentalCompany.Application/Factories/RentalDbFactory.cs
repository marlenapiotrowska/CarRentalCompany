using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Providers;

namespace CarRentalCompany.Application.Factories
{
    internal class RentalDbFactory : IRentalDbFactory
    {
        private readonly IClock _clock;

        public RentalDbFactory(IClock clock)
        {
            _clock = clock;
        }

        public Rental Create(Guid clientId, Guid carId)
        {
            return new Rental
                (Guid.NewGuid(),
                _clock.GetTime(),
                null,
                carId,
                clientId,
                null,
                false);
        }
    }
}
