namespace CarRentalCompany.API.Objects.RequestModels
{
    public class AddCarReceiptFormRequestModel
    {
        public string Type { get; set; }
        public Guid ClientId { get; set; }
    }
}
