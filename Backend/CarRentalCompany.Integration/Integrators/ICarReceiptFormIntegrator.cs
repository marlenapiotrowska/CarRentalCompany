using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Integrators
{
    public interface ICarReceiptFormIntegrator
    {
        void Apply(CarReceiptForm form);
    }
}
