namespace CarRentalCompany.Domain.Models
{
    public class ActivityInstance
    {
        public ActivityInstance(string name, double orderNo)
        {
            Id = Guid.NewGuid();
            Name = name;
            Payload = string.Empty;
            OrderNo = orderNo;
            IsCompleted = false;
        }

        public ActivityInstance(Guid id, string name, string payload, double orderNo, bool isCompleted)
            : this(name, orderNo)
        {
            Id = id;
            Payload = payload;
            IsCompleted = isCompleted;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Payload { get; }
        public double OrderNo { get; }
        public bool IsCompleted { get; }
    }
}
