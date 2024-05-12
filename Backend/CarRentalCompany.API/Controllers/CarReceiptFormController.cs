using CarRentalCompany.API.Factories;
using CarRentalCompany.Application.Services;
using CarRentalCompany.Core.Dto.RequestModels;
using CarRentalCompany.Core.Dto.ResponseModels;
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
