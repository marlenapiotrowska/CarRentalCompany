namespace CarRentalCompany.Core.Dto.ResponseModels
{
    public class CarDto
    {
        public Guid Id { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; }
        public int Value { get; init; }
    }
}
