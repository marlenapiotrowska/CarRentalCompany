using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class ActivityDefinitionRepository : IActivityDefinitionRepository
    {
        private readonly CarRentalCompanyDbContext _context;

        public ActivityDefinitionRepository(CarRentalCompanyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ActivityDefinition> GetForType(string type)
        {
            return _context.ActivitiesDefinitions
                .Where(d => d.Type == type)
                .ToList()
                .Select(d => d.CreateViewModel())
                .ToList();
        }
    }
}
