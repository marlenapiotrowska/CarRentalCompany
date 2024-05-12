namespace CarRentalCompany.Domain.Models
{
    public class Client
    {
        public Client(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
