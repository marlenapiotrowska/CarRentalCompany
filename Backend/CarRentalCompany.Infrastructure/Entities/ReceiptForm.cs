namespace CarRentalCompany.Infrastructure.Entities
{
    public class ReceiptForm
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual Car Car { get; set; }
        public Guid ClientId { get; set; }
        public Guid CarId { get; set; }
        public ICollection<ActivityInstance> Activities { get; set; }

        public static ReceiptForm Create(Guid id, Guid carId, Guid clientId)
        {
            return new ReceiptForm
            {
                Id = id,
                CarId = carId,
                ClientId = clientId
            };
        }
    }
}
