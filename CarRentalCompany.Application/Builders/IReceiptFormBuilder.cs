using CarRentalCompany.Domain.AdditionalTypes;
using CarRentalCompany.Domain.Models.CarBrands;

namespace CarRentalCompany.Application.Builders
{
    public interface IReceiptFormBuilder
    {
        bool IsReceiptFormType(ICarReceiptForm receiptForm);
        IReceiptFormBuilder CreateEmpty();
        IReceiptFormBuilder SetTirePressure(int value);
        IReceiptFormBuilder SetFuelLevel(FuelLevel fuelLevel);
        IReceiptFormBuilder SetCarMileage(int carMileage);
        IReceiptFormBuilder SetIfSystemUpdated(bool isSystemUpdated);
        IReceiptFormBuilder SetIfRefuled(bool isRefuled);
        IReceiptFormBuilder SetIfWashed(bool isWashed);
        ICarReceiptForm SaveResult();
    }
}
