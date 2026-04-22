namespace CarRentalCompany.Infrastructure.Entities
{
    public class Rental
    {
        public Guid Id { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime? RentalEndDate { get; set; }
        public Guid CarId { get; set; }
        public Guid ClientId { get; set; }
        public Guid? ReceiptFormId { get; set; }
        public bool IsEnded { get; set; }
        public virtual Car Car { get; set; }
        public virtual Client Client { get; set; }

        internal static Rental Create(Guid id, DateTime rentalStartDate, DateTime? rentalEndDate, Guid carId, Guid clientId, Guid? receiptFormId, bool isEnded)
        {
            return new Rental
            {
                Id = id,
                RentalStartDate = rentalStartDate,
                RentalEndDate = rentalEndDate,
                CarId = carId,
                ClientId = clientId,
                ReceiptFormId = receiptFormId,
                IsEnded = isEnded
            };
        }
    }
}
