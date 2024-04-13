using Autofac.Features.Indexed;
using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Integration.Builders;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Application.Services
{
    internal class ReceiptFormService : IReceiptFormService
    {
        private readonly IIndex<string, ICarReceiptFormFactory> _carReceiptFormFactories;
        private readonly IReceiptFormRepository _repository;

        public ReceiptFormService(IIndex<string, ICarReceiptFormFactory> carReceiptFormFactories, IReceiptFormRepository repository)
        {
            _carReceiptFormFactories = carReceiptFormFactories;
            _repository = repository;
        }

        public CarReceiptForm CreateNewCarReceiptForm(string brand, Guid clientId)
        {
            var builder = new CarReceiptFormBuilder(brand, clientId);
            var form = _carReceiptFormFactories[brand].Apply(builder);

            AddNewReceiptForm(form);

            return form;
        }

        private void AddNewReceiptForm(CarReceiptForm receiptForm)
        {
            _repository.Add(receiptForm);
        }
    }
}
