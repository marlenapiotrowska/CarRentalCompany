using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Domain.Repositories
{
    public interface IReceiptFormRepository
    {
        void Add(CarReceiptForm carReceiptForm, Guid clientId);
    }
}
