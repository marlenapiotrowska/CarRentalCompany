using CarRentalCompany.Domain.AdditionalTypes;

namespace CarRentalCompany.Domain.Models.CarBrands
{
    public class VolvoReceiptForm : ICarReceiptForm
    {
        public Dictionary<int, string> Type
            => ReceiptFormTypes.Create(4);
        public string Payload { get; set; }
        public int TirePressure { get; set; }
        public FuelLevel FuelLevel { get; set; }
        public int CarMileage { get; set; }
        public bool SystemUpdated { get; set; }
        public bool Refuled { get; set; }
        public bool Washed { get; set; }
        public bool SteeringWheelWashedManually { get; set; }
    }
}
