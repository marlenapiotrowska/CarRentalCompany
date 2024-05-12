namespace CarRentalCompany.Infrastructure.Entities
{
    public class ReceiptForm
    {
        public Guid Id { get; set; }
        public string FormType { get; set; }
        public virtual Client Client { get; set; }
        public Guid ClientId { get; set; }
        public ICollection<ActivityInstance> Activities { get; set; }

        public static ReceiptForm Create(Guid id, string formType, Guid clientId)
        {
            return new ReceiptForm
            {
                Id = id,
                FormType = formType,
                ClientId = clientId
            };
        }
    }
}
