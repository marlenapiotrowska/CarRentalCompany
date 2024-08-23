namespace CarRentalCompany.Application.Exceptions
{
    public class InvalidValueException : Exception
    {
        internal InvalidValueException(string message) : base(message)
        {
        }
    }
}
