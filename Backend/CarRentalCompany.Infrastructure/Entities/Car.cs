namespace CarRentalCompany.Infrastructure.Entities
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Value { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime AdditionDate { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<ReceiptForm> ReceiptForms { get; set; }
    }
}
