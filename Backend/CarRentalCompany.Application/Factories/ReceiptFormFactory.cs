using Autofac.Features.Indexed;
using CarRentalCompany.Application.Factories.Interfaces;
using CarRentalCompany.Domain.Models;
using CarRentalCompany.Domain.Providers;
using CarRentalCompany.Domain.Repositories;
using CarRentalCompany.Integration.Factories;

namespace CarRentalCompany.Application.Factories
{
    internal class ReceiptFormFactory : IReceiptFormFactory
    {
        private readonly IIndex<string, ICarReceiptFormIntegrator> _carReceiptFormFactories;
        private readonly IReceiptFormRepository _formRepository;
        private readonly IActivityInstanceRepository _activityInstanceRepository;
        private readonly IClock _clock;

        public ReceiptFormFactory(
            IIndex<string, ICarReceiptFormIntegrator> carReceiptFormFactories,
            IReceiptFormRepository formRepository, 
            IActivityInstanceRepository activityInstanceRepository,
            IClock clock)
        {
            _carReceiptFormFactories = carReceiptFormFactories;
            _formRepository = formRepository;
            _activityInstanceRepository = activityInstanceRepository;
            _clock = clock;
        }

        public CarReceiptForm CreateNewCarReceiptForm(Car car, Guid clientId)
        {
            var form = new CarReceiptForm(car, clientId, _clock.GetTime());
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
