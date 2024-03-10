using CarRentalCompany.Domain.AdditionalTypes;
using CarRentalCompany.Strategies.CarBrands;
using System.Text;

namespace CarRentalCompany.Application.Builders
{
    public class VolvoReceiptFormBuilder : IReceiptFormBuilder
    {
        private readonly VolvoReceiptForm _receiptFormType;
        private readonly StringBuilder _stringBuilder;
        private readonly ReceiptFormBuilder _baseBuilder;

        public bool IsReceiptFormType(ICarReceiptForm receiptForm)
            => receiptForm.GetType() == typeof(VolvoReceiptForm);

        public VolvoReceiptFormBuilder()
        {
            _receiptFormType = new VolvoReceiptForm();
            _stringBuilder = new StringBuilder();
            _baseBuilder = new ReceiptFormBuilder();
        }

        public IReceiptFormBuilder CreateEmpty()
        {
            _stringBuilder.AppendLine("VOLVO RECEIPT FORM");
            _stringBuilder.Append(_baseBuilder.GetDefaultReceiptForm());
            _stringBuilder.AppendLine($"SteeringWheel washed manually: YES / NO");

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

        public ICarReceiptForm GetResult()
        {
            var path = @"D:\4 - Maja sie uczy\4 - My apps\CarRentalCompanyFiles\ReceiptForm.txt";
            File.WriteAllText(path, _stringBuilder.ToString());

            _receiptFormType.Payload = _stringBuilder.ToString();
            return _receiptFormType;
        }
    }
}
