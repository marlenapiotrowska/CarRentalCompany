namespace CarRentalCompany.API.Objects.ResponseModels
{
    public class CarReceiptFormDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public Guid ClientId { get; set; }
    }
}
