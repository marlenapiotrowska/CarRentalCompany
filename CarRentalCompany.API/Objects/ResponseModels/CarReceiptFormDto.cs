namespace CarRentalCompany.API.Objects.ResponseModels
{
    public class CarReceiptFormDto
    {
        public Guid Id { get; init; }
        public string Type { get; init; }
        public Guid ClientId { get; init; }
        public IEnumerable<ActivityDto> Activities { get; init; }
    }
}
