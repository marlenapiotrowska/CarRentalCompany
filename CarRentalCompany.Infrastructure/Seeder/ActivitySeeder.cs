using CarRentalCompany.Infrastructure.Entities;

namespace CarRentalCompany.Infrastructure.Seeder
{
    public class ActivitySeeder
    {
        private readonly CarRentalCompanyDbContext _context;

        public ActivitySeeder(CarRentalCompanyDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.ActivitiesDefinitions.Any())
                {
                    var activities = new List<ActivityDefinition>()
                    {
                        ActivityDefinition.Create(string.Empty, "Tire pressure", 1),
                        ActivityDefinition.Create(string.Empty, "Fuel level", 2),
                        ActivityDefinition.Create(string.Empty, "Car mileage", 3),
                        ActivityDefinition.Create(string.Empty, "System updated",4),
                        ActivityDefinition.Create(string.Empty, "Refueled", 5),
                        ActivityDefinition.Create(string.Empty, "Washed", 6),
                        ActivityDefinition.Create("Mercedes", "Parking sensor condition", 4.1),
                        ActivityDefinition.Create("Mercedes", "Wheel alignment", 4.2),
                        ActivityDefinition.Create("Porsche", "Cars paint condition", 4.1),
                        ActivityDefinition.Create("Porsche", "Porsche sign condition", 4.2),
                        ActivityDefinition.Create("Volvo", "SteeringWheel washed manually", 7),
                    };

                    _context.ActivitiesDefinitions.AddRange(activities);
                    _context.SaveChanges();
                }
            }
        }
    }
}
