using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Factories
{
    public class CarReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type => string.Empty;

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
