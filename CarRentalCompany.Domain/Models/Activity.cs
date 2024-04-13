namespace CarRentalCompany.Domain.Models
{
    public class Activity
    {
        public Activity(string name)
        {
            Name = name;
        }

        public Activity(string name, string payload)
        {
            Name = name;
            Payload = payload;
        }

        public string Name { get; }
        public string? Payload { get; }
    }
}
