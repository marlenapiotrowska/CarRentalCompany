namespace CarRentalCompany.Infrastructure.Entities
{
    public class ReceiptFormActivities
    {
        public int Id { get; set; }
        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public Guid ReceiptFormId { get; set; }
        public virtual ReceiptForm ReceiptForm { get; set; }
    }
}
