namespace CarRentalCompany.Infrastructure.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        internal EntityNotFoundException(string entityType, Guid id) : base($"Entity type: {entityType} with id: {id} not found")
        {
        }
    }
}
