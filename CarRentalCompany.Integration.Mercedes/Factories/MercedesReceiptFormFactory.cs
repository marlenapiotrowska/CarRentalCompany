using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Mercedes.Factories
{
    public class MercedesReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type
            => "Mercedes";

        public CarReceiptForm Apply(Guid clientId, IEnumerable<ActivityDefinition> activities)
        {
            var form = new CarReceiptForm(Type, clientId);
            var activitiesInstances = activities
                .OrderBy(a => a.OrderNo)
                .Select(activity => activity.CreateInstance())
                .ToList();

            form.AddActivities(activitiesInstances);

            return form;
        }
    }
}
