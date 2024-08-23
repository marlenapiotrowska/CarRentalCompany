namespace CarRentalCompany.Domain.Models
{
    public class Car
    {
        public Car(Guid id, string brand, string model, int productionYear, int value, string vIN, string color, bool isAvailable, DateTime additionDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            Value = value;
            VIN = vIN;
            Color = color;
            IsAvailable = isAvailable;
            AdditionDate = additionDate;
        }

        public Guid Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public int ProductionYear { get; }
        public int Value { get; }
        public string VIN { get; }
        public string Color { get; }
        public bool IsAvailable { get; }
        public DateTime AdditionDate { get; }
    }
}
