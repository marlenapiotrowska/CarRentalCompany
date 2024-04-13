using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;

namespace CarRentalCompany.Integration.Factories
{
    public interface ICarReceiptFormFactory
    {
        public CarReceiptForm Apply(CarReceiptFormBuilder builder);
    }
}
