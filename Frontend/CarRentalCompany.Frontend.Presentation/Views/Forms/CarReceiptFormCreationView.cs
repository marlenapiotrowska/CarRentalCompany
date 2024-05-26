using CarRentalCompany.Core.Dto.ResponseModels;
using CarRentalCompany.Frontend.Domain.Interfaces;
using CarRentalCompany.Frontend.Domain.ValueObjects;
using CarRentalCompany.Frontend.Presentation.Views.Components;
using CarRentalCompany.Frontend.Presentation.Views.Forms.Components;
using CarRentalCompany.Frontend.Presentation.Views.Generic;

namespace CarRentalCompany.Frontend.Presentation.Views.Forms
{
    internal class CarReceiptFormCreationView : View
    {
        private readonly ICarReceiptFormRepository _formRepository;
        private readonly IClientRepository _clientRepository;

        public CarReceiptFormCreationView(ICarReceiptFormRepository formRepository, IClientRepository clientRepository)
        {
            _formRepository = formRepository;
            _clientRepository = clientRepository;
        }

        protected override async Task RenderViewAsync()
        {
            var getClients = await _clientRepository.GetAllClients();
            ValidateSuccess(getClients);

            var selectedClient = new SelectClientComponent(getClients.Payload).Render();
            var selectedType = new SelectTypeComponent().Render();

            var createForm = await _formRepository.CreateCarReceiptForm(selectedType, selectedClient.Id);
            ValidateSuccess(createForm);

            DisplayResult(createForm, createForm.Payload.Activities);
        }

        private static void DisplayResult(ExecutionResultGeneric<CarReceiptFormDto> createForm, IEnumerable<ActivityDto> activities)
        {
            _ = activities.OrderBy(a => a.OrderNo);

            Console.WriteLine($"{createForm.Payload.Type}");
            foreach (var activity in activities)
            {
                Console.WriteLine($"{activity.OrderNo} {activity.Name}");
            }
        }

        private static void ValidateSuccess<TOutput>(ExecutionResultGeneric<TOutput> action)
        {
            if (!action.IsSuccess)
            {
                var errorPage = new ErrorPageComponent(action.Message);
                errorPage.Render();
            }
        }
    }
}
