using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Builders
{
    public class CarReceiptFormBuilder
    {
        private readonly CarReceiptForm _carReceiptForm;

        public CarReceiptFormBuilder(string type, Guid clientId)
        {
            _carReceiptForm = new CarReceiptForm(type, clientId);
        }

        public Guid GetFormId()
        {
            return _carReceiptForm.Id;
        }

        public void AddActivities(IEnumerable<ActivityInstance> activities)
        {
            foreach (var activity in activities)
            {
                _carReceiptForm.AddActivity(activity);
            }
        }

        public CarReceiptForm Build()
        {
            return _carReceiptForm;
        }
    }
}
