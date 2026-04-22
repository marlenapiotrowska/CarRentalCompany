namespace CarRentalCompany.Domain.Models
{
    public class CarReceiptForm
    {
        private readonly List<ActivityInstance> _activites = [];

        public CarReceiptForm(Car car, Guid clientId, DateTime creationDate)
        {
            Id = Guid.NewGuid();
            Car = car;
            ClientId = clientId;
            CreationDate = creationDate;
        }

        public CarReceiptForm(Guid id, Car car, Guid clientId, DateTime creationDate)
        {
            Id = id;
            Car = car;
            ClientId = clientId;
            CreationDate = creationDate;
        }

        public Guid Id { get; }
        public Car Car { get; }
        public Guid ClientId { get; }
        public DateTime CreationDate { get; set; }
        public IReadOnlyList<ActivityInstance> Activities
            => _activites;

        public void AddActivity(ActivityInstance activity)
        {
            _activites.Add(activity);
        }
    }
}
