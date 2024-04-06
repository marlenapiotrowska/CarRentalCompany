using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Volvo.Factories
{
    public class VolvoReceiptFormFactory : ICarReceiptFormFactory
    {
        public string Type 
            => "Volvo";

        public CarReceiptForm Apply(CarReceiptFormBuilder builder)
        {
            builder.AddActivity(new Activity("SteeringWheel washed manually"));

            return builder.Build();
        }
    }
}
