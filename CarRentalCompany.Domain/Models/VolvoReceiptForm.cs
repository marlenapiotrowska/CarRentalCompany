namespace CarRentalCompany.Domain.Models
{
    public class VolvoReceiptForm : ReceiptForm
    {
        public bool SteeringWheelWashedManually { get; private set; }

        public void SetSteeringWheelWashedManually(bool isWashedManually)
        {
            SteeringWheelWashedManually = isWashedManually;
        }
    }
}
