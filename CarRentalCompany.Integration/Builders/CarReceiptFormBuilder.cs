using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Integration.Builders
{
    public class CarReceiptFormBuilder
    {
        private readonly CarReceiptForm _carReceiptForm;

        public CarReceiptFormBuilder(Guid id, string type, Guid clientId)
        {
            _carReceiptForm = new CarReceiptForm(id, type, clientId);
        }

        public void AddActivity(Activity activity)
        {
            _carReceiptForm.AddActivity(activity);
        }

        public CarReceiptForm Build()
        {
            return _carReceiptForm;
        }
    }
}
