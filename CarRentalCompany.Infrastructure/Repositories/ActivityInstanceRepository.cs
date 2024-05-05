using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using ActivityInstanceDb = CarRentalCompany.Infrastructure.Entities.ActivityInstance;

namespace CarRentalCompany.Infrastructure.Repositories
{
    internal class ActivityInstanceRepository : IActivityInstanceRepository
    {
        private readonly CarRentalCompanyDbContext _context;

        public ActivityInstanceRepository(CarRentalCompanyDbContext context)
        {
            _context = context;
        }

        public void Add(IEnumerable<ActivityInstance> activities, Guid formId)
        {
            var activitiesDb = activities
                .Select(a => ActivityInstanceDb.Create(a, formId));

            _context.ActivitiesInstances.AddRange(activitiesDb);
            _context.SaveChanges();
        }
    }
}
