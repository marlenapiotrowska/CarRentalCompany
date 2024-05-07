using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Volvo.Factories
{
    public class VolvoReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type 
            => "Volvo";
        private List<ActivityInstance> _activities = [];

        public CarReceiptForm Apply(CarReceiptForm form)
        {
            _activities.Add(new ActivityInstance("SteeringWheel washed manually", 7));
            form.AddActivities(_activities);

            return form;
        }
    }
}
