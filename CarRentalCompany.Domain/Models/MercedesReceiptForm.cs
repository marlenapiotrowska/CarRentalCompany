using CarRentalCompany.Domain.Enums;

namespace CarRentalCompany.Domain.Models
{
    public class MercedesReceiptForm : ReceiptForm
    {
        public Condition ParkingSensorCondition { get; private set; }
        public Condition WheelAlignment { get; private set; }

        public void SetParkingSensorCondition(Condition parkingSensorCondition)
        {
            ParkingSensorCondition = parkingSensorCondition;
        }

        public void SetWheelAlignment(Condition wheelAlignment)
        {
            WheelAlignment = wheelAlignment;
        }
    }
}
