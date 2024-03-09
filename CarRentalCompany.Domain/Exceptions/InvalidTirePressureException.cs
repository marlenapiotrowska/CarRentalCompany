namespace CarRentalCompany.Domain.Exceptions
{
    internal class InvalidTirePressureException : Exception
    {
        public InvalidTirePressureException(int value) : base($"Value {value} is invalid. Tire pressure must be more than 0.")
        {
        }
    }
}
