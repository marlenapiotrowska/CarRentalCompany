using CarRentalCompany.Domain.Providers;

namespace CarRentalCompany.Application.Providers
{
    internal class TimeProvider : ITimeProvider
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
