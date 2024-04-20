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
        private readonly IReceiptFormRepository _formRepository;
        private readonly IActivityInstanceRepository _activityInstanceRepository;
        private readonly IActivityDefinitionRepository _activityDefinitionRepository;

        public ReceiptFormService(IIndex<string, ICarReceiptFormFactory> carReceiptFormFactories, 
            IReceiptFormRepository formRepository, IActivityInstanceRepository activityInstanceRepository, 
            IActivityDefinitionRepository activityDefinitionRepository)
        {
            _carReceiptFormFactories = carReceiptFormFactories;
            _formRepository = formRepository;
            _activityInstanceRepository = activityInstanceRepository;
            _activityDefinitionRepository = activityDefinitionRepository;
        }

        public CarReceiptForm CreateNewCarReceiptForm(string brand, Guid clientId)
        {
            var builder = new CarReceiptFormBuilder(brand, clientId);
            var activities = _activityDefinitionRepository.GetForType(brand);
            var form = _carReceiptFormFactories[brand].Apply(builder, activities);

            AddNewReceiptForm(form);
            AddActivities(form.Activities);

            return form;
        }

        private void AddActivities(List<ActivityInstance> activities)
        {
            _activityInstanceRepository.Add(activities);
        }

        private void AddNewReceiptForm(CarReceiptForm receiptForm)
        {
            _formRepository.Add(receiptForm);
        }
    }
}
