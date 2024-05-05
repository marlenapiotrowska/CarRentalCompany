using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Volvo.Factories
{
    public class VolvoReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type 
            => "Volvo";

        public CarReceiptForm Apply(CarReceiptFormBuilder builder, IEnumerable<ActivityDefinition> activities)
        {
            var activitiesInstances = activities
                 .OrderBy(a => a.OrderNo)
                 .Select(activity => activity.CreateInstance(builder.GetFormId()))
                 .ToList();

            builder.AddActivities(activitiesInstances);

            return builder.Build();
        }
    }
}
