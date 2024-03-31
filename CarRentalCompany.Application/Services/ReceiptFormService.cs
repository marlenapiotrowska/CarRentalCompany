using CarRentalCompany.Application.Builders;
using CarRentalCompany.Application.Repositories;
using CarRentalCompany.Domain.Models.CarBrands;

namespace CarRentalCompany.Application.Services
{
    internal class ReceiptFormService : IReceiptFormService
    {
        private readonly IReceiptFormRepository _repository;

        public ReceiptFormService(IReceiptFormRepository repository)
        {
            _repository = repository;
        }

        public void AddNewReceiptForm(ICarReceiptForm receiptForm, Guid clientId)
        {
            _repository.Add(receiptForm, clientId);
        }

        public void CreateEmptyReceiptForm(IReceiptFormBuilder builder)
        {
            builder.CreateEmpty();
            builder.SaveResult();
        }
    }
}
