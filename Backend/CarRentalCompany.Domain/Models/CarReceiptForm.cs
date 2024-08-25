namespace CarRentalCompany.Domain.Models
{
    public class CarReceiptForm
    {
        private readonly List<ActivityInstance> _activites = [];

        public CarReceiptForm(Car car, Guid clientId)
        {
            Id = Guid.NewGuid();
            Car = car;
            ClientId = clientId;
        }

        public CarReceiptForm(Guid id, Car car, Guid clientId)
        {
            Id = id;
            Car = car;
            ClientId = clientId;
        }

        public Guid Id { get; }
        public Car Car { get; }
        public Guid ClientId { get; }
        public IReadOnlyList<ActivityInstance> Activities
            => _activites;

        public void AddActivity(ActivityInstance activity)
        {
            _activites.Add(activity);
        }
    }
}
