using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Mercedes.Factories
{
    public class MercedesReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type
            => "Mercedes";
        private List<ActivityInstance> _activities = [];

        public CarReceiptForm Apply(CarReceiptForm form)
        {
            _activities.Add(new ActivityInstance("Parking sensor condition", 4.1));
            _activities.Add(new ActivityInstance("Wheel alignment", 4.2));

            form.AddActivities(_activities);

            return form;
        }
    }
}
