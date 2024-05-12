using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Factories
{
    public class CarReceiptFormIntegrator : ICarReceiptFormIntegrator
    {
        public static string Type => string.Empty;

        public void Apply(CarReceiptForm form)
        {
            form.AddActivity(new ActivityInstance("Tire pressure", 1));
            form.AddActivity(new ActivityInstance("Fuel level", 2));
            form.AddActivity(new ActivityInstance("Car mileage", 3));
            form.AddActivity(new ActivityInstance("System updated", 4));
            form.AddActivity(new ActivityInstance("Refueled", 5));
            form.AddActivity(new ActivityInstance("Washed", 6));
        }
    }
}
