using CarRentalCompany.Domain.AdditionalTypes;

namespace CarRentalCompany.Strategies.CarBrands
{
    public interface ICarReceiptForm
    {
        Dictionary<int, string> Type { get; }
        string Payload { get; set; }
        int TirePressure { get; set; }
        FuelLevel FuelLevel { get; set; }
        int CarMileage { get; set; }
        bool SystemUpdated { get; set; }
        bool Refuled { get; set; }
        bool Washed { get; set; }
    }
}
