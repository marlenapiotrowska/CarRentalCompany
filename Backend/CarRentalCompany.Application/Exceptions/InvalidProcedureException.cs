namespace CarRentalCompany.Application.Exceptions
{
    public class InvalidProcedureException : Exception
    {
        internal InvalidProcedureException(string message) : base(message)
        {
        }
    }
}
