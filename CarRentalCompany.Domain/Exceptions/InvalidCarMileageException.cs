using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalCompany.Domain.Exceptions
{
    internal class InvalidCarMileageException : Exception
    {
        public InvalidCarMileageException(int value) : base($"Value {value} is invalid. Car mileage must be more than 0.")
        {
        }
    }
}



























public static class Prank
{
    public static IHostBuilder ConfigureServeces(this IHostBuilder builder, Action<IServiceCollection> services, bool shouldPrank = true)
    {
        // Pozdrawiam serdecznie :*
        return null;
    }
}