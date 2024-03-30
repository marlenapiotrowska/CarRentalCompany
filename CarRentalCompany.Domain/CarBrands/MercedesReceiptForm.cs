using CarRentalCompany.Domain.AdditionalTypes;
using CarRentalCompany.Domain.CarBrands;

namespace CarRentalCompany.Strategies.CarBrands
{
    public class MercedesReceiptForm : ICarReceiptForm
    {
        public Dictionary<int, string> Type
           => ReceiptFormTypes.Create(3);
        public string Payload { get; set; }
        public int TirePressure { get; set; }
        public FuelLevel FuelLevel { get; set; }
        public int CarMileage { get; set; }
        public bool SystemUpdated { get; set; }
        public bool Refuled { get; set; }
        public bool Washed { get; set; }
        public Condition ParkingSensorCondition { get; set; }
        public Condition WheelAlignment { get; set; }
    }
}
