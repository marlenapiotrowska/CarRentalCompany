using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Factories
{
    public class CarReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type => string.Empty;
        private List<ActivityInstance> _activities = [];

        public CarReceiptForm Apply(CarReceiptForm form)
        {
            _activities.Add(new ActivityInstance("Tire pressure", 1));
            _activities.Add(new ActivityInstance("Fuel level", 2));
            _activities.Add(new ActivityInstance("Car mileage", 3));
            _activities.Add(new ActivityInstance("System updated", 4));
            _activities.Add(new ActivityInstance("Refueled", 5));
            _activities.Add(new ActivityInstance("Washed", 6));

            form.AddActivities(_activities);

            return form;
        }
    }
}
