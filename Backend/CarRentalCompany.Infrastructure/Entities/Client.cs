namespace CarRentalCompany.Infrastructure.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ReceiptForm> ReceiptForms { get; set; }
    }
}
