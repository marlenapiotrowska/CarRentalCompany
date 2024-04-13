using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Mercedes.Factories
{
    public class MercedesReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type
            => "Mercedes";

        public CarReceiptForm Apply(CarReceiptFormBuilder builder)
        {
            builder.AddActivity(new Activity("Parking sensor condition"));
            builder.AddActivity(new Activity("Wheel alignment"));

            return builder.Build();
        }
    }
}
