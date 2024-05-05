using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Porsche.Factories
{
    public class PorscheReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type 
            => "Porsche";

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
