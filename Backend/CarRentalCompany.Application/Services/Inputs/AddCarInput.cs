namespace CarRentalCompany.Application.Services.Inputs
{
    public class AddCarInput
    {
        public AddCarInput(string brand, string model, int productionYear, int value, string vin, string color)
        {
            Brand = brand;
            Model = model;
            ProductionYear = productionYear;
            Value = value;
            VIN = vin;
            Color = color;
        }

        public string Brand { get; }
        public string Model { get; }
        public int ProductionYear { get; }
        public int Value { get; }
        public string VIN { get; }
        public string Color { get; }
    }
}
