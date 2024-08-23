namespace CarRentalCompany.Domain.Models.Snapshots
{
    public class CarSnapshot
    {
        public CarSnapshot(Guid id, string brand, string model, int value)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Value = value;
        }

        public Guid Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public int Value { get; }
    }
}
