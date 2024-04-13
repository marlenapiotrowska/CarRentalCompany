using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Porsche.Factories
{
    public class PorscheReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type 
            => "Porsche";

        public CarReceiptForm Apply(CarReceiptFormBuilder builder)
        {
            builder.AddActivity(new Activity("Cars paint condition"));
            builder.AddActivity(new Activity("Porsche sign condition"));

            return builder.Build();
        }
    }
}
