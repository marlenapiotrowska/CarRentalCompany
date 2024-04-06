namespace CarRentalCompany.Domain.Models
{
    public class CarReceiptForm
    {
        public CarReceiptForm(Guid id, string type, Guid clientId)
        {
            Id = id;
            Type = type;
            ClientId = clientId;
        }

        public Guid Id { get; }
        public string Type { get; }
        public Guid ClientId { get; }
        public List<Activity> Activities { get; }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }
    }
}
