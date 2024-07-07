using CarRentalCompany.API.Factories.Interfaces;
using CarRentalCompany.Application.Services.Inputs;
using CarRentalCompany.Application.Services.Interfaces;
using CarRentalCompany.Core.Dto.RequestModels;
using CarRentalCompany.Core.Dto.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalCompany.API.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;
        private readonly ICarDtoFactory _factory;

        public CarController(ICarService service, ICarDtoFactory factory)
        {
            _service = service;
            _factory = factory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetAll()
        {
            var cars = await _service.GetAll();

             return cars
                .Select(c => _factory.Create(c))
                .ToList();
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> AddCar([FromBody] AddCarRequestModel request)
        {
            var input = new AddCarInput(request.Brand, request.Model, request.ProductionYear, request.Value, request.VIN, request.Color);
            var addedCar = await _service.Add(input);

            return _factory.Create(addedCar);
        }

        [HttpDelete]
        public async Task Delete(Guid carId)
        {
            await _service.Delete(carId);
        }
    }
}
