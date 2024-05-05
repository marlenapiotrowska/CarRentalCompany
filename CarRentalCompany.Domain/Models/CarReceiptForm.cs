namespace CarRentalCompany.Domain.Models
{
    public class CarReceiptForm
    {
        private readonly List<ActivityInstance> _activites = [];

        public CarReceiptForm(string type, Guid clientId)
        {
            Id = Guid.NewGuid();
            Type = type;
            ClientId = clientId;
        }

        public CarReceiptForm(Guid id, string type, Guid clientId)
        {
            Id = id;
            Type = type;
            ClientId = clientId;
        }

        public Guid Id { get; }
        public string Type { get; }
        public Guid ClientId { get; }
        public IReadOnlyList<ActivityInstance> Activities
            => _activites;

        public void AddActivities(IEnumerable<ActivityInstance> activities)
        {
            foreach (var activity in activities)
            {
                _activites.Add(activity);
            }
        }
    }
}
