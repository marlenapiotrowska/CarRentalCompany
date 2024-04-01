using CarRentalCompany.Domain.Models.CarBrands;

namespace CarRentalCompany.Application.Repositories
{
    public interface IReceiptFormRepository
    {
        void Add(ICarReceiptForm carReceiptForm, Guid clientId);
    }
}
