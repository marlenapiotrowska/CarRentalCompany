using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;

namespace CarRentalCompany.Application.Services
{
    internal class ReceiptFormService : IReceiptFormService
    {
        private readonly IReceiptFormRepository _repository;

        public ReceiptFormService(IReceiptFormRepository repository)
        {
            _repository = repository;
        }

        public void AddNewReceiptForm(CarReceiptForm receiptForm, Guid clientId)
        {
            _repository.Add(receiptForm, clientId);
        }
    }
}
