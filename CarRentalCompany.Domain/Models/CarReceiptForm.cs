namespace CarRentalCompany.Domain.Models
{
    public class CarReceiptForm
    {
        public CarReceiptForm(string type, Guid clientId)
        {
            Id = Guid.NewGuid();
            Type = type;
            ClientId = clientId;
            Activities = [];
        }

        public CarReceiptForm(Guid id, string type, Guid clientId)
        {
            Id = id;
            Type = type;
            ClientId = clientId;
            Activities = [];
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
