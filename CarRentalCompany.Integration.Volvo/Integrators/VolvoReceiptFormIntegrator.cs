using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Volvo.Factories
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
