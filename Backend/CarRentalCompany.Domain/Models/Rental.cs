namespace CarRentalCompany.Domain.Models
{
    public class Rental
    {
        public Rental(Guid id, DateTime rentalStartDate, DateTime? rentalEndDate, Guid carId, Guid clientId, Guid? receiptFormId, bool isEnded)
        {
            Id = id;
            RentalStartDate = rentalStartDate;
            RentalEndDate = rentalEndDate;
            CarId = carId;
            ClientId = clientId;
            ReceiptFormId = receiptFormId;
            IsEnded = isEnded;
        }

        public Guid Id { get; }
        public DateTime RentalStartDate { get; }
        public DateTime? RentalEndDate { get; private set; }
        public Guid CarId { get; }
        public Guid ClientId { get; }
        public Guid? ReceiptFormId { get; private set; }
        public bool IsEnded { get; private set; }

        public void End(DateTime rentalEndDate)
        {
            RentalEndDate = rentalEndDate;
            IsEnded = true;
        }

        public void SetReceiptForm(Guid receiptFormId)
        {
            ReceiptFormId = receiptFormId;
        }
    }
}
