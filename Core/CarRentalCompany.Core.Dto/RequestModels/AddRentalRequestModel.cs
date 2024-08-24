namespace CarRentalCompany.Core.Dto.RequestModels
{
    public class AddRentalRequestModel
    {
        public Guid ClientId { get; set; }
        public Guid CarId { get; set; }
    }
}
