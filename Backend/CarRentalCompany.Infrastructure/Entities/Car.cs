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

        public static Car Create(Guid id, string brand, string model, int productionYear, int value, string vin, string color, bool isAvailable, DateTime additionDate)
        {
            return new Car
            {
                Id = id,
                Brand = brand,
                Model = model,
                ProductionYear = productionYear,
                Value = value,
                VIN = vin,
                Color = color,
                IsAvailable = isAvailable,
                AdditionDate = additionDate
            };
        }
    }
}
