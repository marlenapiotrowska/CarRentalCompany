namespace CarRentalCompany.Core.Dto.RequestModels
{
    public class AddCarReceiptFormRequestModel
    {
        public string Type { get; set; }
        public Guid ClientId { get; set; }
    }
}
