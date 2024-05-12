using CarRentalCompany.API.Factories;
using CarRentalCompany.API.Objects.RequestModels;
using CarRentalCompany.API.Objects.ResponseModels;
using CarRentalCompany.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalCompany.API.Controllers
{
    [ApiController]
    [Route("forms")]
    public class CarReceiptFormController : ControllerBase
    {
        private readonly IReceiptFormService _service;
        private readonly ICarReceiptFormDtoFactory _formFactory;

        public CarReceiptFormController(IReceiptFormService service, ICarReceiptFormDtoFactory formFactory)
        {
            _service = service;
            _formFactory = formFactory;
        }

        [HttpPost]
        public async Task<ActionResult<CarReceiptFormDto>> AddCarReceiptForm([FromBody] AddCarReceiptFormRequestModel requestModel)
        {
            var form = _service.CreateNewCarReceiptForm(requestModel.Type, requestModel.ClientId);

            return _formFactory.Create(form);
        }
    }
}
