namespace CarRentalCompany.Domain.Models
{
    public class ActivityInstance
    {
        public ActivityInstance(string name, int orderNo, Guid activityDefinitionId, Guid receiptFormId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Payload = string.Empty;
            OrderNo = orderNo;
            IsCompleted = false;
            ActivityDefinitionId = activityDefinitionId;
            ReceiptFormId = receiptFormId;
        }

        public ActivityInstance(Guid id, string name, string payload, int orderNo, bool isCompleted, Guid activityDefinitionId, Guid receiptFormId) 
            : this(name, orderNo, activityDefinitionId, receiptFormId)
        {
            Id = id;
            Payload = payload;
            IsCompleted = isCompleted;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Payload { get; }
        public int OrderNo { get; }
        public bool IsCompleted { get; }
        public Guid ActivityDefinitionId { get; }
        public Guid ReceiptFormId { get; }
    }
}
