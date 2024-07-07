namespace CarRentalCompany.Core.Dto.RequestModels
{
    public class AddCarRequestModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Value { get; set; }
        public string VIN { get; set; }
        public string Color { get; set; }
    }
}
