using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Mercedes.Factories
{
    public class MercedesReceiptFormIntegrator : ICarReceiptFormIntegrator
    {
        public static string Type
            => "Mercedes";

        public void Apply(CarReceiptForm form)
        {
            form.AddActivity(new ActivityInstance("Parking sensor condition", 4.1));
            form.AddActivity(new ActivityInstance("Wheel alignment", 4.2));
        }
    }
}
