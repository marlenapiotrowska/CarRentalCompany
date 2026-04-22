using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Integrators;

namespace CarRentalCompany.Integration.Volvo.Integrators
{
    public class VolvoReceiptFormIntegrator : ICarReceiptFormIntegrator
    {
        public static string Type
            => "Volvo";

        public void Apply(CarReceiptForm form)
        {
            form.AddActivity(new ActivityInstance("SteeringWheel washed manually", 7));
        }
    }
}
