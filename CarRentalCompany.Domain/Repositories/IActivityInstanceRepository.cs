using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IActivityInstanceRepository
    {
        void Add(IEnumerable<ActivityInstance> activity);
    }
}
