namespace CarRentalCompany.Infrastructure.Entities
{
    public class ActivityDefinition
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public ICollection<ActivityInstance> Activities { get; set; }
    
        public static ActivityDefinition Create(string type, string name, int orderNo)
        {
            return new ActivityDefinition
            {
                Type = type,
                Name = name,
                OrderNo = orderNo,
            };
        }
    }
}
