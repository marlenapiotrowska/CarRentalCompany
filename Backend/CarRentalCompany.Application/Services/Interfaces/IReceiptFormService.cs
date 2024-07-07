using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services.Interfaces
{
    public interface IReceiptFormService
    {
        CarReceiptForm CreateNewCarReceiptForm(string type, Guid clientId);
    }
}
