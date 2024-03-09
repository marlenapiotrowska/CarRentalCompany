using CarRentalCompany.Domain.Enums;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Builders
{
    internal class TypicalReceiptFormBuilder
    {
        private ReceiptForm _receiptForm;

        public TypicalReceiptFormBuilder()
        {
            Reset();
        }

        public TypicalReceiptFormBuilder SetTirePressure(int value)
        {
            _receiptForm.SetTirePressure(value);
            return this;
        }

        public TypicalReceiptFormBuilder SetFuelLevel(FuelLevel fuelLevel)
        {
            _receiptForm.SetFuelLevel(fuelLevel);
            return this;
        }

        public TypicalReceiptFormBuilder SetCarMileage(int carMileage)
        {
            _receiptForm.SetCarMileage(carMileage);
            return this;
        }

        public TypicalReceiptFormBuilder SetIfSystemUpdated(bool isSystemUpdated)
        {
            _receiptForm.SetIfSystemUpdated(isSystemUpdated);
            return this;
        }

        public TypicalReceiptFormBuilder SetIfRefuled(bool isRefuled)
        {
            _receiptForm.SetIfRefuled(isRefuled);
            return this;
        }

        public TypicalReceiptFormBuilder SetIfWashed(bool isWashed)
        {
            _receiptForm.SetIfWashed(isWashed);
            return this;
        }

        public ReceiptForm GetResult()
        {
            return _receiptForm;
        }

        private void Reset()
        {
            _receiptForm = new ReceiptForm();
        }
    }
}
