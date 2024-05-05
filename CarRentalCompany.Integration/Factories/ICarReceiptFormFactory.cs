using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Factories
{
    public interface ICarReceiptFormFactory
    {
        public CarReceiptForm Apply(Guid clientId, IEnumerable<ActivityDefinition> activities);
    }
}
