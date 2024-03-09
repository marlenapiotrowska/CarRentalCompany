using CarRentalCompany.Domain.Enums;

namespace CarRentalCompany.Domain.Models
{
    public class PorscheReceiptForm : ReceiptForm
    {
        public Condition CarsPaintCondition { get; private set; }
        public Condition PorscheSignCondition { get; private set; }

        public void SetCarsPaintCondition(Condition carsPaintCondition)
        {
            CarsPaintCondition = carsPaintCondition;
        }

        public void SetPorscheSignCondition(Condition porscheSignCondition)
        {
            PorscheSignCondition = porscheSignCondition;
        }
    }
}
