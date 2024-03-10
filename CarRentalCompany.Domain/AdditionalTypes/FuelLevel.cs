namespace CarRentalCompany.Domain.AdditionalTypes
{
    public record FuelLevel(int Level)
    {
        public static FuelLevel Reserve { get; } = new(1);
        public static FuelLevel PartlyFilled { get; } = new(2);
        public static FuelLevel Full { get; } = new(3);

        public static implicit operator string(FuelLevel level)
        {
            return level.Level switch
            {
                1 => "Reserve",
                2 => "PartlyFilled",
                3 => "Full",
                _ => throw new InvalidOperationException("Invalid fuel level"),
            };
        }
    }
}
