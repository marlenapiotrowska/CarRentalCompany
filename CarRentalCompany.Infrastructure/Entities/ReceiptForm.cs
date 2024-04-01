namespace CarRentalCompany.Infrastructure.Entities
{
    public class ReceiptForm
    {
        public Guid Id { get; set; }
        public string FormType { get; set; }
        public string Value { get; set; }
        public virtual Client Client { get; set; }
        public Guid ClientId { get; set; }

        public static ReceiptForm Create(string formType, string value, Guid clientId)
        {
            return new ReceiptForm
            {
                FormType = formType,
                Value = value,
                ClientId = clientId
            };
        }
    }
}
