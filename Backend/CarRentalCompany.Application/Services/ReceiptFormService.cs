using Autofac.Features.Indexed;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Application.Services
{
    internal class ReceiptFormService : IReceiptFormService
    {
        private readonly IIndex<string, ICarReceiptFormIntegrator> _carReceiptFormFactories;
        private readonly IReceiptFormRepository _formRepository;
        private readonly IActivityInstanceRepository _activityInstanceRepository;

        public ReceiptFormService(
            IIndex<string, ICarReceiptFormIntegrator> carReceiptFormFactories, 
            IReceiptFormRepository formRepository, IActivityInstanceRepository activityInstanceRepository)
        {
            _carReceiptFormFactories = carReceiptFormFactories;
            _formRepository = formRepository;
            _activityInstanceRepository = activityInstanceRepository;
        }

        public CarReceiptForm CreateNewCarReceiptForm(Car car, Guid clientId)
        {
            var form = new CarReceiptForm(car, clientId);
            _carReceiptFormFactories[string.Empty].Apply(form);
            AddSpecificActivities(car.Brand, form);

            _formRepository.Add(form);
            _activityInstanceRepository.Add(form.Activities, form.Id);

            return form;
        }

        private CarReceiptForm AddSpecificActivities(string type, CarReceiptForm formWithDefaultActivities)
        {
            if (!string.IsNullOrEmpty(type))
            {
                _carReceiptFormFactories[type].Apply(formWithDefaultActivities);
            }

            return formWithDefaultActivities;
        }
    }
}
