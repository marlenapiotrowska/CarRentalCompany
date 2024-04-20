namespace CarRentalCompany.Domain.Models
{
    public class ActivityDefinition
    {
        public ActivityDefinition(string type, string name, int orderNo)
        {
            Id = Guid.NewGuid();
            Type = type;
            Name = name;
            OrderNo = orderNo;
        }

        public ActivityDefinition(Guid id, string type, string name, int orderNo) 
            : this(type, name, orderNo)
        {
            Id = id;
        }

        public Guid Id { get; }
        public string Type { get; }
        public string Name { get; }
        public int OrderNo { get; }

        public ActivityInstance CreateInstance(Guid receiptFormId)
        {
            return new ActivityInstance(Name, OrderNo, Id, receiptFormId);
        }
    }
}
