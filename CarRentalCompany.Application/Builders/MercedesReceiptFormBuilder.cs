using CarRentalCompany.Domain.AdditionalTypes;
using CarRentalCompany.Strategies.CarBrands;
using System.Text;

namespace CarRentalCompany.Application.Builders
{
    public class MercedesReceiptFormBuilder : IReceiptFormBuilder
    {
        private readonly MercedesReceiptForm _receiptFormType;
        private readonly StringBuilder _stringBuilder;
        private readonly ReceiptFormBuilder _baseBuilder;

        public bool IsReceiptFormType(ICarReceiptForm receiptForm)
            => receiptForm.GetType() == typeof(MercedesReceiptForm);

        public MercedesReceiptFormBuilder()
        {
            _receiptFormType = new MercedesReceiptForm();
            _stringBuilder = new StringBuilder();
            _baseBuilder = new ReceiptFormBuilder();
        }

        public IReceiptFormBuilder CreateEmpty()
        {
            _stringBuilder.AppendLine("MERCEDES RECEIPT FORM");
            _stringBuilder.Append(_baseBuilder.GetDefaultReceiptForm());
            _stringBuilder.AppendLine($"Parking sensor condition: {Condition.Bad.State} / {Condition.Good} / {Condition.WithComments}: ");
            _stringBuilder.AppendLine();
            _stringBuilder.AppendLine($"Wheel alignment: {Condition.Bad} / {Condition.Good} / {Condition.WithComments}: ");
            _stringBuilder.AppendLine();

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
            _baseBuilder.SaveFile(_stringBuilder);

            _receiptFormType.Payload = _stringBuilder.ToString();
            return _receiptFormType;
        }
    }
}
