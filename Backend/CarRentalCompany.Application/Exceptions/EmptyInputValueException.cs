namespace CarRentalCompany.Application.Exceptions
{
    public class EmptyInputValueException : Exception
    {
        internal EmptyInputValueException(string valueType) : base($"Value: {valueType} can not be empty")
        {
        }
    }
}
