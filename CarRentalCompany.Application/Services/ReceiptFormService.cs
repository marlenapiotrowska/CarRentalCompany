using Autofac.Features.Indexed;
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

        public CarReceiptForm CreateNewCarReceiptForm(string type, Guid clientId)
        {
            var form = new CarReceiptForm(type, clientId);
            _carReceiptFormFactories[string.Empty].Apply(form);
            AddSpecificActivities(type, form);

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
