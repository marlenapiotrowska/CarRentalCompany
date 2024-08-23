namespace CarRentalCompany.Infrastructure.Entities
{
    public class Rental
    {
        public Guid Id { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public Guid CarId { get; set; }
        public Guid ClientId { get; set; }
        public Guid? ReceiptFormId { get; set; }
        public bool IsEnded { get; set; }
        public virtual Car Car { get; set; }
        public virtual Client Client { get; set; }
    }
}
