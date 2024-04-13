namespace CarRentalCompany.Infrastructure.Entities
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Payload { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<ReceiptFormActivities> ReceiptFormActivities { get; set; }
    }
}
