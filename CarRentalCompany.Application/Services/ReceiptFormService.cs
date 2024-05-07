using Autofac.Features.Indexed;
using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Application.Services
{
    internal class ReceiptFormService : IReceiptFormService
    {
        private readonly IIndex<string, ICarReceiptFormFactory> _carReceiptFormFactories;
        private readonly IReceiptFormRepository _formRepository;
        private readonly IActivityInstanceRepository _activityInstanceRepository;

        public ReceiptFormService(
            IIndex<string, ICarReceiptFormFactory> carReceiptFormFactories, 
            IReceiptFormRepository formRepository, IActivityInstanceRepository activityInstanceRepository)
        {
            _carReceiptFormFactories = carReceiptFormFactories;
            _formRepository = formRepository;
            _activityInstanceRepository = activityInstanceRepository;
        }

        public CarReceiptForm CreateNewCarReceiptForm(string type, Guid clientId)
        {
            var form = new CarReceiptForm(type, clientId);
            var formWithDefaultActivities = _carReceiptFormFactories[string.Empty].Apply(form);
            var formWithSpecificActivities = AddSpecificActivities(type, formWithDefaultActivities);

            _formRepository.Add(formWithSpecificActivities);
            _activityInstanceRepository.Add(formWithSpecificActivities.Activities, formWithSpecificActivities.Id);

            return form;
        }

        private CarReceiptForm AddSpecificActivities(string type, CarReceiptForm formWithDefaultActivities)
        {
            if (!string.IsNullOrEmpty(type))
            {
                return _carReceiptFormFactories[type].Apply(formWithDefaultActivities);
            }

            return formWithDefaultActivities;
        }
    }
}
