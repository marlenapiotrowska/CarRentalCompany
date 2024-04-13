using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;

namespace CarRentalCompany.Integration.Factories
{
    public class CarReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type => string.Empty;
        public CarReceiptForm Apply(CarReceiptFormBuilder builder)
        {
            builder.AddActivity(new Activity("Tire pressure"));
            builder.AddActivity(new Activity("Fuel level"));
            builder.AddActivity(new Activity("Car mileage"));
            builder.AddActivity(new Activity("System updated"));
            builder.AddActivity(new Activity("Refueled"));
            builder.AddActivity(new Activity("Washed"));

            return builder.Build();
        }
    }
}
