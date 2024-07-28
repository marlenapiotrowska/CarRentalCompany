using CarRentalCompany.Domain.Providers;

namespace CarRentalCompany.Application.Providers
{
    internal class Clock : IClock
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
