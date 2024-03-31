using CarRentalCompany.Application.Builders;
using CarRentalCompany.Domain.Models.CarBrands;

namespace CarRentalCompany.Application.Services
{
    public interface IReceiptFormService
    {
        void CreateEmptyReceiptForm(IReceiptFormBuilder builder);
        void AddNewReceiptForm(ICarReceiptForm receiptForm, Guid clientId);
    }
}
