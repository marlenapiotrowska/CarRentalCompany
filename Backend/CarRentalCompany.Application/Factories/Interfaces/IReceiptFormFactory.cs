using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Factories.Interfaces
{
    internal interface IReceiptFormFactory
    {
        CarReceiptForm CreateNewCarReceiptForm(Car car, Guid clientId);
    }
}
