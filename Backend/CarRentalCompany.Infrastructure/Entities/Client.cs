namespace CarRentalCompany.Infrastructure.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ReceiptForm> ReceiptForms { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }

        internal static Client Create(Guid id, string name)
        {
            return new Client
            {
                Id = id,
                Name = name
            };
        }
    }
}
