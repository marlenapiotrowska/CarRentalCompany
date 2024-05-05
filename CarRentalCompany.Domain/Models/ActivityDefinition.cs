namespace CarRentalCompany.Domain.Models
{
    public class ActivityDefinition
    {
        public ActivityDefinition(string type, string name, double orderNo)
        {
            Id = Guid.NewGuid();
            Type = type;
            Name = name;
            OrderNo = orderNo;
        }

        public ActivityDefinition(Guid id, string type, string name, double orderNo) 
            : this(type, name, orderNo)
        {
            Id = id;
        }

        public Guid Id { get; }
        public string Type { get; }
        public string Name { get; }
        public double OrderNo { get; private set; }

        public ActivityInstance CreateInstance()
        {
            return new ActivityInstance(Name, OrderNo);
        }

        public void Reorder()
        {
            OrderNo++;
        }
    }
}
