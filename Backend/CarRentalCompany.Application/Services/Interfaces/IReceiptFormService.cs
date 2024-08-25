using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services.Interfaces
{
    internal interface IReceiptFormService
    {
        CarReceiptForm CreateNewCarReceiptForm(Car car, Guid clientId);
    }
}
