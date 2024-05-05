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
        private readonly IActivityDefinitionRepository _activityDefinitionRepository;

        public ReceiptFormService(
            IIndex<string, ICarReceiptFormFactory> carReceiptFormFactories, 
            IReceiptFormRepository formRepository, IActivityInstanceRepository activityInstanceRepository, 
            IActivityDefinitionRepository activityDefinitionRepository)
        {
            _carReceiptFormFactories = carReceiptFormFactories;
            _formRepository = formRepository;
            _activityInstanceRepository = activityInstanceRepository;
            _activityDefinitionRepository = activityDefinitionRepository;
        }

        public CarReceiptForm CreateNewCarReceiptForm(string type, Guid clientId)
        {
            var activities = _activityDefinitionRepository.GetForType(type);
            var form = _carReceiptFormFactories[type].Apply(clientId, activities);

            _formRepository.Add(form);
            _activityInstanceRepository.Add(form.Activities, form.Id);

            return form;
        }
    }
}
