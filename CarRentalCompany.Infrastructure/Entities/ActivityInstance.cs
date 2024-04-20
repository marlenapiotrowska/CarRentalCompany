namespace CarRentalCompany.Infrastructure.Entities
{
    public class ActivityInstance
    {
        public Guid Id { get; set; }
        public string Payload { get; set; }
        public bool IsCompleted { get; set; }
        public Guid ActivityDefinitionId { get; set; }
        public virtual ActivityDefinition ActivityDefinition { get; set; }
        public Guid ReceiptFormId { get; set; }
        public virtual ReceiptForm ReceiptForm { get; set; }
    }
}
