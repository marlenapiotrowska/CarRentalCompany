using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IActivityDefinitionRepository
    {
        IEnumerable<ActivityDefinition> GetForType(string type);
    }
}
