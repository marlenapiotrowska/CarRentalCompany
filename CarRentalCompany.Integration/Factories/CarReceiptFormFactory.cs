using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;

namespace CarRentalCompany.Integration.Factories
{
    public class CarReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type => string.Empty;
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
