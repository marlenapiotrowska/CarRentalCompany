using CarRentalCompany.Strategies.CarBrands;

namespace CarRentalCompany.Application.Repositories
{
    public interface IReceiptFormRepository
    {
        void Add(ICarReceiptForm carReceiptForm, Guid clientId);
    }
}
