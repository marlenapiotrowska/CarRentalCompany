using CarRentalCompany.Domain.Models;

namespace CarRentalCompany.Application.Services
{
    public interface IReceiptFormService
    {
        CarReceiptForm CreateNewCarReceiptForm(string type, Guid clientId);
    }
}
