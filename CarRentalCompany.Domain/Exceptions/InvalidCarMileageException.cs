namespace CarRentalCompany.Domain.Exceptions
{
    internal class InvalidCarMileageException : Exception
    {
        public InvalidCarMileageException(int value) : base($"Value {value} is invalid. Car mileage must be more than 0.")
        {
        }
    }
}
