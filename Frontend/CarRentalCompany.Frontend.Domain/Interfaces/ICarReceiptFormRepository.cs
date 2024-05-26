using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Frontend.Domain.ValueObjects;

namespace CarRentalCompany.Frontend.Domain.Interfaces
{
    public interface ICarReceiptFormRepository
    {
        Task<ExecutionResultGeneric<CarReceiptFormDto>> CreateCarReceiptForm(string type, Guid clientId);
    }
}
