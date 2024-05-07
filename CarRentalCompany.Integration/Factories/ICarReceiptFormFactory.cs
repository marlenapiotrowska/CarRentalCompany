using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Factories
{
    public interface ICarReceiptFormFactory
    {
        CarReceiptForm Apply(CarReceiptForm form);
    }
}
