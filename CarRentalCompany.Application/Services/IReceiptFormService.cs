using CarRentalCompany.Domain.Models;
using CarRentalCompany.Integration.Builders;

namespace CarRentalCompany.Application.Services
{
    public interface IReceiptFormService
    {
        void AddNewReceiptForm(CarReceiptForm receiptForm, Guid clientId);
    }
}
