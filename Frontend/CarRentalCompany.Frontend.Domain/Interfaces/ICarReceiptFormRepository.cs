using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Frontend.Domain.ValueObjects;

namespace CarRentalCompany.Frontend.Domain.Interfaces
{
    public interface ICarReceiptFormRepository
    {
        Task<ExecutionResultGeneric<CarReceiptFormDto>> CreateCarReceiptFormAsync(string type, Guid clientId);
    }
}
