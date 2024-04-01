using CarRentalCompany.Application.Repositories;
using CarRentalCompany.Domain.AdditionalTypes;
using CarRentalCompany.Domain.Models.CarBrands;
using System.Text;

namespace CarRentalCompany.Application.Builders
{
    public class TypicalReceiptFormBuilder : IReceiptFormBuilder
    {
        private readonly CarReceiptForm _receiptFormType;
        private readonly StringBuilder _stringBuilder;
        private readonly ReceiptFormBuilder _baseBuilder;

        public bool IsReceiptFormType(ICarReceiptForm receiptForm)
            => receiptForm.GetType() == typeof(CarReceiptForm);

        public TypicalReceiptFormBuilder()
        {
            _receiptFormType = new CarReceiptForm();
            _stringBuilder = new StringBuilder();
            _baseBuilder = new ReceiptFormBuilder();
        }

        public IReceiptFormBuilder CreateEmpty()
        {
            _stringBuilder.AppendLine("RECEIPT FORM");
            _stringBuilder.Append(_baseBuilder.GetDefaultReceiptForm());

            return this;
        }

        public IReceiptFormBuilder SetTirePressure(int value)
        {
            _receiptFormType.TirePressure = value;
            return this;
        }

        public IReceiptFormBuilder SetFuelLevel(FuelLevel fuelLevel)
        {
            _receiptFormType.FuelLevel = fuelLevel;
            return this;
        }

        public IReceiptFormBuilder SetCarMileage(int carMileage)
        {
            _receiptFormType.CarMileage = carMileage;
            return this;
        }

        public IReceiptFormBuilder SetIfSystemUpdated(bool isSystemUpdated)
        {
            _receiptFormType.SystemUpdated = isSystemUpdated;
            return this;
        }

        public IReceiptFormBuilder SetIfRefuled(bool isRefuled)
        {
            _receiptFormType.Refuled = isRefuled;
            return this;
        }

        public IReceiptFormBuilder SetIfWashed(bool isWashed)
        {
            _receiptFormType.Washed = isWashed;
            return this;
        }

        public ICarReceiptForm SaveResult()
        {
            _baseBuilder.SaveFile(_stringBuilder);
            _receiptFormType.Payload = _stringBuilder.ToString();
            return _receiptFormType;
        }
    }
}
