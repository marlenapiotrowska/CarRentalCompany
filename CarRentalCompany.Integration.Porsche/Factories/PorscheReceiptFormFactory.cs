using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Integration.Porsche.Factories
{
    public class PorscheReceiptFormFactory : ICarReceiptFormFactory
    {
        public static string Type 
            => "Porsche";
        private List<ActivityInstance> _activities = [];

        public CarReceiptForm Apply(CarReceiptForm form)
        {
            _activities.Add(new ActivityInstance("Cars paint condition", 4.1));
            _activities.Add(new ActivityInstance("Porsche sign condition", 4.2));

            form.AddActivities(_activities);

            return form;
        }
    }
}
