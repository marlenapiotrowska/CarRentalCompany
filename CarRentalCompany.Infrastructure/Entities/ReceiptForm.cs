namespace CarRentalCompany.Infrastructure.Entities
{
    public class ReceiptForm
    {
        public Guid Id { get; set; }
        public string FormType { get; set; }
        public string Value { get; set; }
        public virtual Client Client { get; set; }
        public Guid ClientId { get; set; }
        public ICollection<ReceiptFormActivities> ReceiptFormActivities { get; set; }

        public static ReceiptForm Create(Guid id, string formType, string value, Guid clientId)
        {
            return new ReceiptForm
            {
                Id = id,
                FormType = formType,
                Value = value,
                ClientId = clientId
            };
        }
    }
}
