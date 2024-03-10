using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalCompany.Domain.Exceptions
{
    internal class InvalidTirePressureException : Exception
    {
        public InvalidTirePressureException(int value) : base($"Value {value} is invalid. Tire pressure must be more than 0.")
        {
        }
    }
}