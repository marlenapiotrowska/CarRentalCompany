namespace CarRentalCompany.Core.Dto.RequestModels
{
    public class CreateCarReceiptFormRequestModel
    {
        public string Type { get; set; }
        public Guid ClientId { get; set; }
    }
}
