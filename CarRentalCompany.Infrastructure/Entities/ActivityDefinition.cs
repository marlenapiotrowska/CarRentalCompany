using ActivityDefinitionDomain = CarRentalCompany.Domain.Models.ActivityDefinition;

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
                Id = Guid.NewGuid(),
                Type = type,
                Name = name,
                OrderNo = orderNo,
            };
        }

        public ActivityDefinitionDomain CreateViewModel()
        {
            return new ActivityDefinitionDomain(Id, Type, Name, OrderNo);
        }
    }
}
