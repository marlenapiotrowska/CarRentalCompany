using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Integrators;

namespace CarRentalCompany.Integration.Mercedes.Integrators
{
    public class MercedesReceiptFormIntegrator : ICarReceiptFormIntegrator
    {
        private const string _gClass = "G";

        public static string Type
            => BrandsNames.Mercedes;

        public void Apply(CarReceiptForm form)
        {
            form.AddActivity(new ActivityInstance("Parking sensor condition", 4.1));
            form.AddActivity(new ActivityInstance("Wheel alignment", 4.2));

            if (form.Car.Model.StartsWith(_gClass))
            {
                form.AddActivity(new ActivityInstance("Air suspension check", 4.3));
            }
        }
    }
}
