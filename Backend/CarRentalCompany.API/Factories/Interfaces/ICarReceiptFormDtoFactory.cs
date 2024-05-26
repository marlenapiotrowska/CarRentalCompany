using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.API.Factories.Interfaces
{
    public interface ICarReceiptFormDtoFactory
    {
        CarReceiptFormDto Create(CarReceiptForm form);
    }
}
