namespace CarRentalCompany.Domain.Models
{
    public class Car
    {
        private const int _highValue = 500000;

        public Car(Guid id, string brand, string model, int productionYear, int value, string vin, string color, bool isAvailable, DateTime additionDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            Value = value;
            VIN = vin;
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

        public bool IsHighValued()
        {
            return Value >= _highValue;
        }
    }
}
