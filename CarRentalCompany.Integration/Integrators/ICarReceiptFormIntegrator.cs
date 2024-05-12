using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Factories
{
    public interface ICarReceiptFormIntegrator
    {
        void Apply(CarReceiptForm form);
    }
}
